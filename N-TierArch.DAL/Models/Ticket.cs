using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.DAL.Models
{
   public class Ticket
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public int Departmentid { get; set; }
        public Department Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();

    }
}
