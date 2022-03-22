using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pizza> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(0,1).Select(index => new Pizza
            {
                Descripcion = "Con salsa de tomate y queso",
                Id = 1,
                Importe = 300,
                LibreGluten = false,
                Nombre = "Muzza Individual"
            })
            .ToArray();
        }
    
        [HttpGet("{Id}")]
        public Pizza GetById(int id){
            Pizza MiPizza=BD.GetById(id);
            return MiPizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza){

        }
    }
}
