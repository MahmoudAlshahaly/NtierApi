using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.dtos
{
    public class TicketInsertDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public int departmentid { get; set; }
    }
}
