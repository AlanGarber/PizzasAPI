using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Utils
{
    public class dataBase
    {
        public static SqlConnection GetConnection(){
            SqlConnection db;
            string connectionString;
            connectionString=@"Server=A-CEO-15;DataBase:DAI-Pizzas;Trusted_Connection=True";
            db= new SqlConnection(connectionString);
            return db;
        }
    }
}
