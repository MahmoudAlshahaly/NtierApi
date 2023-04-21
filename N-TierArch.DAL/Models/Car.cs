using N_TierArch.DAL.CustomValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.DAL.Models
{
    public class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }
        public string Color { get; set; }

        [PastDate(ErrorMessage = "Date Must Be In The Past")]
        public DateTime ProductionDate { get; set; }
        public string? Type { get; set; }
    }
}
