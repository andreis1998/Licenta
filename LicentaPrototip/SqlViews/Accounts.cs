using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LicentaPrototip.SqlViews
{
    public class Accounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid AccountId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string Email { get; set; }

        [Index(IsUnique = true)]
        public bool IsAdmin { get; set; }

        public bool IsAdultAccount { get; set; }

        public string Password { get; set; }
    }
}