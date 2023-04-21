using AutoMapper;
using N_TierArch.BLL.dtos;
using N_TierArch.BLL.dtos.Department;
using N_TierArch.BLL.dtos.DeveloperDto;
using N_TierArch.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.MappingDomain
{
    public class DomainProfie:Profile
    {
        public DomainProfie()
        {
            CreateMap<Ticket, TicketGetDto>().ReverseMap();
            CreateMap<Ticket, TicketInsertDto>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDto>().ReverseMap();
            CreateMap<Department, DepartmentWithTicketAndNumberOFDeveloeprDto>().ReverseMap();
            CreateMap<Ticket, DepartmentWithTicketAndNumberOFDeveloeprDto>().ReverseMap();
        }
    }
}
