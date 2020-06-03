using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LicentaPrototip.Models
{
    [DataContract]
    public class TemperatureGraphModel
    {
        [DataMember(Name = "y")]
        public double? TemperatureValue { get; set; }

        [DataMember(Name = "x")]
        public DateTime? DateLogged { get; set; }
    }
}