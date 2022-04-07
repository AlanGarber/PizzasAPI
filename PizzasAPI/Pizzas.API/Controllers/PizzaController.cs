using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.PizzaServices;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll(){
            List<Pizza> ListaPizza;
            ListaPizza=BD.GetAll();
            return Ok(ListaPizza);
        }
    
        [HttpGet("{Id}")]
        public IActionResult GetById(int id){
            Pizza MiPizza=BD.GetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(Pizza Pizza){
            BD.Create(Pizza);
            return Ok();
        }

        [HttpPut ("{id}")]
        public IActionResult Update(int Id,Pizza Pizza){
            BD.Update(Id, Pizza);
            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteById(int Id){
            BD.DeleteById(Id);
            return Ok();
        }
    }
}
