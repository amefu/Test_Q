using ApiRest.Data.Access;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Data.Repository
{
    public abstract class BaseRepository
    {
        private readonly IOptions<Settings> _settings;
        protected BaseRepository(IOptions<Settings> settings)
        {
           _settings = settings;
        }
        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_settings.Value.DefaultConnection);
        }
    }
}
