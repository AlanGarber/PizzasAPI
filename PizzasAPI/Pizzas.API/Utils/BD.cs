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
    public static class BD
    {
        public static SqlConnection GetConnection(){
            SqlConnection db;
            string connectionString;

            connectionString=ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings:ConnectionString");
            db= new SqlConnection(connectionString);
            return db;
        }
    }
}
