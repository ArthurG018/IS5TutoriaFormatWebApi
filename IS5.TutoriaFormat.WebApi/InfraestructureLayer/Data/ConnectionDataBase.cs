using IS5.TutoriaFormat.WebApi.InfraestructureLayer.Interface;
using System.Data;
using System.Data.SqlClient;

namespace IS5.TutoriaFormat.WebApi.LayerInfraestructure.Data
{
    public class ConnectionDataBase:IConnectionDataBase
    {
        private readonly IConfiguration _configuration;

        public ConnectionDataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection { get
            {
                SqlConnection sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;
                sqlConnection.ConnectionString = _configuration.GetConnectionString("ConnectionDB");
                sqlConnection.Open();
                return sqlConnection;
            } 
        }
    }
}
