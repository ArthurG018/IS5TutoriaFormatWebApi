using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class IncidenceApplication : IIncidenceApplication
    {
        public string generateQueryIncidence(IEnumerable<IncidenceDto> incidenceDtos)
        {
            var query = "";
            foreach (var incidence in incidenceDtos)
            {
                string delimiter = (incidence == incidenceDtos.Last()) ? ";" : ",";
                query += $"('{incidence.Reason}', '{incidence.Treatment}', '{incidence.Observation}',{incidence.ProfesorId}, {incidence.StudentId})";
            }
            return query;
        }
    }
}
