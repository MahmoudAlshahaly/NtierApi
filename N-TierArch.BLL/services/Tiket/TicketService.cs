using AutoMapper;
using DataBase;
using N_TierArch.BLL.dtos;
using N_TierArch.DAL.Models;
using N_TierArch.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.services.Tiket
{
    public  class TicketService: ITicketService
    {
        private readonly IGenericRepository<Ticket> ticketService;
        private readonly IMapper mapper;

        public TicketService(IGenericRepository<Ticket> ticketService,IMapper mapper)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
        }

        public TicketInsertDto Add(TicketInsertDto t)
        {
            var TiketModel = mapper.Map<Ticket>(t);
            ticketService.Insert(TiketModel);
            return t;
        }

        public void Delete(int id)
        {
            ticketService.Delete(id);
        }

        public IEnumerable<TicketGetDto> GetAll()
        {
            var TiketDto = mapper.Map<IEnumerable<TicketGetDto>>(ticketService.GetAll().ToList());
           return TiketDto;
        }

        public TicketGetDto GetByID(int id)
        {
            var TiketDto = mapper.Map<TicketGetDto>(ticketService.GetAll().FirstOrDefault(a=>a.id==id));
            return TiketDto;
        }

        public void SaveChanges()
        {
            ticketService.SaveChanges();
        }

        public TicketUpdateDto Update(TicketUpdateDto t)
        {
            var TiketModel = mapper.Map<Ticket>(t);
            ticketService.Update(TiketModel);
            return t;
        }
    }
}
