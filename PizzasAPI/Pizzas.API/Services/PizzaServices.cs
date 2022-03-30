using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Models
{
    public static class BD
    {
        private static string _connectionString=@"Server=A-CEO-15;DataBase=DAI-Pizzas;Trusted_Connection=True;";

        public static List<Pizza> GetAll(){
            List<Pizza> ListaPizza;
            string sql="SELECT * FROM Pizzas";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                ListaPizza=BD.Query<Pizza>(sql).ToList();
            }
            return ListaPizza;
        }
        
        public static Pizza GetById(int id){
            Pizza MiPizza=null;
            string sql="SELECT * FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiPizza=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=id});
            }
            return MiPizza;
        }

        public static Pizza Create(Pizza Pizza){
            string sql="INSERT INTO Pizzas(Nombre,LibreGluten,Importe,Descripcion) VALUES (@pNombre,@pLibreGluten,@pImporte,@pDescripcion)";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pNombre=Pizza.Nombre,pLibreGluten=Pizza.LibreGluten,pImporte=Pizza.Importe,pDescripcion=Pizza.Descripcion});
            }
            return new Pizza();
        }

        public static Pizza Update(int Id, Pizza Pizza){
            string sql="UPDATE Pizzas SET Nombre=@pNombre, LibreGluten=@pLibreGluten, Importe=@pImporte, Descripcion=@pDescripcion WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pNombre=Pizza.Nombre,pLibreGluten=Pizza.LibreGluten,pImporte=Pizza.Importe,pDescripcion=Pizza.Descripcion, pId=Id});
            }
            return new Pizza();
        }

        public static Pizza DeleteById(int Id){
            string sql="DELETE FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                BD.Execute(sql,new{pId=Id});
            }
            return new Pizza();
        }
    }
}