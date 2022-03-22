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
        private static string _connectionString=@"Server=A-LUM-18;DataBase=DAI-Pizzas;Trusted_Connection=True;";

        public static Pizza GetById(int id){
            Pizza MiPizza=null;
            string sql="SELECT * FROM Pizzas WHERE Id=@pId";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiPizza=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=id});
            }
            return MiPizza;
        }

        public static Pizza Create(Pizza pizza){
            string sql="INSERT INTO Pizzas VALUES ("","")";
            using(SqlConnection BD=new SqlConnection(_connectionString)){
                MiPizza=BD.QueryFirstOrDefault<Pizza>(sql,new{pId=id});
            }
            return MiPizza;
        }
    }
}
