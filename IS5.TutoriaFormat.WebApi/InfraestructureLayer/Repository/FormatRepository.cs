using Dapper;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.InfraestructureLayer.Interface;
using System.Data;

namespace IS5.TutoriaFormat.WebApi.InfraestructureLayer.Repository
{
    public class FormatRepository : IFormatRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public FormatRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public dynamic generateFormat2(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            using (var db = _connectionDataBase.GetConnection)
            {
                var query = "sp_format_2";
                var parameters = new DynamicParameters();
                parameters.Add("ProfessorData", queryProfessor);
                parameters.Add("ActivityData", queryActivity);
                parameters.Add("StudentData", queryStudent);
                parameters.Add("AssistanceData", queryAssistance);

                var result = db.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
           
        }
        public dynamic generateFormat3(string queryProfessor, string queryStudents, string queryIncidendes)
        {
            using (var db = _connectionDataBase.GetConnection)
            {
                var query = "sp_format_3";
                var parameters = new DynamicParameters();
                parameters.Add("ProfessorData", queryProfessor);
                parameters.Add("@StudentData", queryStudents);
                parameters.Add("@IncidenceData", queryIncidendes);

                var result = db.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public dynamic generateFormat4(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            using (var db = _connectionDataBase.GetConnection)
            {
                var query = "sp_format_4";
                var parameters = new DynamicParameters();
                parameters.Add("ProfessorData", queryProfessor);
                parameters.Add("ActivityData", queryActivity);
                parameters.Add("StudentData", queryStudent);
                parameters.Add("AssistanceData", queryAssistance);

                var result = db.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public dynamic generateFormat5(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            using (var db = _connectionDataBase.GetConnection)
            {
                var query = "sp_format_5";
                var parameters = new DynamicParameters();
                parameters.Add("ProfessorData", queryProfessor);
                parameters.Add("ActivityData", queryActivity);
                parameters.Add("StudentData", queryStudent);
                parameters.Add("AssistanceData", queryAssistance);

                var result = db.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
