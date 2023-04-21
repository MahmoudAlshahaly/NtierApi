using N_TierArch.BLL.dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.services.Deparment
{
   public interface IDepartmentService
    {
        IEnumerable<DepartmentWithTicketAndNumberOFDeveloeprDto> GetAll();

        DepartmentWithTicketAndNumberOFDeveloeprDto GetByID(int id);
    }
}
