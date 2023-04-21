using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.dtos.Department
{
    public class DepartmentWithTicketAndNumberOFDeveloeprDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<TicketChildForDepartmentWithNumOfDevelper> Tickets { get; set; } = new HashSet<TicketChildForDepartmentWithNumOfDevelper>();
    }
}
