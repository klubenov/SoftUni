using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
