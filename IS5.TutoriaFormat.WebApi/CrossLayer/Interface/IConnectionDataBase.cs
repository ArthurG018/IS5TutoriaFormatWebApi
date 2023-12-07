using System.Data;

namespace IS5.TutoriaFormat.WebApi.InfraestructureLayer.Interface
{
    public interface IConnectionDataBase
    {
        IDbConnection GetConnection { get; }
    }
}
