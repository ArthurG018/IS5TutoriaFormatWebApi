using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class AssistanceApplication : IAssistanceApplication
    {
        public string generateQueryAsistance(IEnumerable<AssistanceDto> assistances)
        {
            var query = "";
            var delimiter = "";
            foreach (var assistance in assistances)
            {
                delimiter = (assistance == assistances.Last()) ? ";" : ",";
                query += $"({getIsPresent(assistance.IsPresent) }, {assistance.ActivityId}, {assistance.StudentId}){delimiter}";
            }
            return query;
        }
        public int getIsPresent(bool isPresent)
        {
            return (isPresent) ? 1 : 0;
        }
    }
}
