using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_TierArch.BLL.dtos;
using N_TierArch.BLL.dtos.Department;
using N_TierArch.BLL.dtos.DeveloperDto;
using N_TierArch.DAL.Models;
using N_TierArch.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.services.Deparment
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> departmentService;
        private readonly IMapper mapper;

        public DepartmentService(IGenericRepository<Department> departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        public IEnumerable<DepartmentWithTicketAndNumberOFDeveloeprDto> GetAll()
        {
            var Departmentmodel = departmentService.GetAll().ToList();
                //.Include(t => t.Tickets)
                //.ThenInclude(d => d.Developers).ToList();
            var automappToDto = mapper.Map<List<DepartmentWithTicketAndNumberOFDeveloeprDto>>(Departmentmodel);
            return automappToDto;
        }

        public DepartmentWithTicketAndNumberOFDeveloeprDto GetByID(int id)
        {
            var DepartmentDto = departmentService.GetAll()
                .Select(d =>
                    new DepartmentWithTicketAndNumberOFDeveloeprDto
                    {
                        id = d.id,
                        name = d.name,
                        Tickets = d.Tickets.Select(t =>
                         new TicketChildForDepartmentWithNumOfDevelper
                         {
                             id = t.id,
                             title = t.title,
                             description = t.description,
                             NumOfDeveloper = t.Developers.Count()
                         }).ToList()
                    }).FirstOrDefault(d=>d.id==id);


            
            //var Departmentmodel = departmentService.GetAll()
            //    .Include(t => t.Tickets)
            //    .ThenInclude(d => d.Developers.Count()).FirstOrDefault(d=>d.id==id);
            //var automappToDto = mapper.Map<DepartmentWithTicketAndNumberOFDeveloeprDto>(Departmentmodel);
            return DepartmentDto;
        }
    }
}
