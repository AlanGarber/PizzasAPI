using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Controllers;

namespace Pizzas.API.Models
{
    public static class BD
    {
        public static List<Pizza> GetAll(){
            List<Pizza> ListaPizza;
            string sp="sp_GetAll";
            using(SqlConnection BD=BD.GetConnection()){
                ListaPizza=BD.Query<Pizza>(sp, commandType:commandType.StoredProcedure).ToList();
            }
            return ListaPizza;
        }
        
        public static Pizza GetById(int id){
            Pizza MiPizza=null;
            string sp="sp_GetAll";
            using(SqlConnection BD=BD.GetConnection()){
                MiPizza=BD.QueryFirstOrDefault<Pizza>(sp,new {IdPizza=id} ,commandType:commandType.StoredProcedure);
            }
            return MiPizza;
        }

        public static Pizza Create(Pizza Pizza){
            string sp="sp_Create";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Nombre=Pizza.Nombre,LibreGluten=Pizza.LibreGluten,Importe=Pizza.Importe,Descripcion=Pizza.Descripcion},commandType:commandType.StoredProcedure);
            }
            return new Pizza();
        }

        public static Pizza Update(int Id, Pizza Pizza){
            string sp="sp_Update";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Nombre=Pizza.Nombre,LibreGluten=Pizza.LibreGluten,Importe=Pizza.Importe,Descripcion=Pizza.Descripcion,IdPizza=Id}, commandType:commandType.StoredProcedure);
            }
            return new Pizza();
        }

        public static Pizza DeleteById(int Id){
            string sp="sp_DeleteById";
            using(SqlConnection BD=BD.GetConnection()){
                BD.Execute(sp,new{Id=Id},commandType:commandType.StoredProcedure);
            }
            return new Pizza();
        }
    }
}