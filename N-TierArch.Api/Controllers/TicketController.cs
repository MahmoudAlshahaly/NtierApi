using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_TierArch.BLL.dtos;
using N_TierArch.BLL.services.Tiket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_TierArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ticketService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            //var A = User.Identity.IsAuthenticated;
            //var S = Request.Cookies["nameDDD"];

            
            var Tic = ticketService.GetByID(id);
            if(Tic is null)
            {
                return NotFound();
            }
            return Ok(Tic);
        }
        [HttpPost]
        public IActionResult Insert(TicketInsertDto ticketInsertDto)
        {
            ticketService.Add(ticketInsertDto);
            ticketService.SaveChanges();
            return CreatedAtAction("GetByID", new { id = ticketInsertDto.id }, ticketInsertDto);
           // return Ok(ticketService.Add(ticketInsertDto));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,TicketUpdateDto ticketUpdateDto)
        {
            if(id!=ticketUpdateDto.id)
            {
                return NotFound();
            }
            ticketService.Update(ticketUpdateDto);
            ticketService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ticketService.Delete(id);
            ticketService.SaveChanges();
            return Ok();
        }
    }
}
