﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class OfficerPrisonerDto
    {
        [XmlAttribute("id")]
        public int PrisonerId { get; set; }
    }
}
