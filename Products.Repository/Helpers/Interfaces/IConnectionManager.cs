using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Repository.Helpers.Interfaces
{
    public interface IConnectionManager
    {
        SqlConnection CreateConnection();
    }
}
