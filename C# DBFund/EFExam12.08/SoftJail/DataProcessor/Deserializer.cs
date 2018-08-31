using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        private const string invalidDataMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedDepartments = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            foreach (var departmentDto in deserializedDepartments)
            {
                bool invalidCellOccurance = false;

                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(invalidDataMessage);
                    continue;
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(invalidDataMessage);
                        invalidCellOccurance = true;
                        break;
                    }
                }

                if (invalidCellOccurance)
                {
                    continue;
                }

                var department = context.Departments.FirstOrDefault(x => x.Name == departmentDto.Name);

                if (department == null)
                {
                    department = new Department
                    {
                        Name = departmentDto.Name
                    };
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        Department = department,
                        DepartmentId = department.Id,
                        HasWindow = cellDto.HasWindow
                    };

                    department.Cells.Add(cell);
                }

                context.Departments.Add(department);
                context.SaveChanges();

                sb.AppendLine($"Imported {department.Name} with {departmentDto.Cells.Count} cells");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedPrisoners = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            foreach (var prisonerDto in deserializedPrisoners)
            {
                bool invalidMailOccurence = false;

                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(invalidDataMessage);
                    continue;
                }

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(invalidDataMessage);
                        invalidMailOccurence = true;
                        break;
                    }
                }

                if (invalidMailOccurence)
                {
                    continue;
                }

                DateTime? releseDate = null;

                if (prisonerDto.ReleaseDate != null)
                {
                    releseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Sender
                    };

                    prisoner.Mails.Add(mail);
                }

                context.Prisoners.Add(prisoner);
                context.SaveChanges();

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var officers = new List<Officer>();
            var officerPrisoners = new List<OfficerPrisoner>();

            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var deserializedOfficers = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var officerDto in deserializedOfficers)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(invalidDataMessage);
                    continue;
                }

                if (!Enum.IsDefined(typeof(Position), officerDto.Position) || !Enum.IsDefined(typeof(Weapon), officerDto.Weapon))
                {
                    sb.AppendLine(invalidDataMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = (Position)Enum.Parse(typeof(Position), officerDto.Position),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon), officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId
                };

                officers.Add(officer);

                foreach (var officerPrisonerDto in officerDto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner
                    {
                        Officer = officer,
                        PrisonerId = officerPrisonerDto.PrisonerId
                    };

                    officerPrisoners.Add(officerPrisoner);
                }

                sb.AppendLine($"Imported {officer.FullName} ({officerDto.Prisoners.Length} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.OfficersPrisoners.AddRange(officerPrisoners);

            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}