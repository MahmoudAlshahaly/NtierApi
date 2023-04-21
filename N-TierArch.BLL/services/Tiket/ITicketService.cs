using N_TierArch.BLL.dtos;
using N_TierArch.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.services.Tiket
{
    public interface ITicketService
    {
        IEnumerable<TicketGetDto> GetAll();
        TicketGetDto GetByID(int id);
        TicketInsertDto Add(TicketInsertDto t);
        TicketUpdateDto Update(TicketUpdateDto t);
        void Delete(int id);
        void SaveChanges();
    }
}
