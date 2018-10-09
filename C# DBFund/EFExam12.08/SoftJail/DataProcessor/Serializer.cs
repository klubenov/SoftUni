using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(p => ids.Contains(p.Id) && p.CellId != 0).Select(x => new
            {
                Id = x.Id,
                Name = x.FullName,
                CellNumber = x.Cell.CellNumber,
                Officers = x.PrisonerOfficers.Select(op => new
                {
                    OfficerName = op.Officer.FullName,
                    Department = op.Officer.Department.Name
                })
                .OrderBy(o => o.OfficerName)
                .ToArray(),
                TotalOfficerSalary = Math.Round(x.PrisonerOfficers.Sum(op => op.Officer.Salary), 2)
            })
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Id)
            .ToArray();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            throw new NotImplementedException();
        }
    }
}