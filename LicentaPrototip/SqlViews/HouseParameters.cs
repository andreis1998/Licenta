using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LicentaPrototip.SqlViews
{
    public class HouseParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid ParameterId { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string Details { get; set; }
    }
}