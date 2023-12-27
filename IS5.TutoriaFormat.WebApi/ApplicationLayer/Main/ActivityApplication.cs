using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class ActivityApplication : IActivityApplication
    {
        public string generateQueryActivity(IEnumerable<ActivityDto> activities)
        {
            var query = "";
            var delimiter = "";
            foreach (var activity in activities)
            {
                delimiter = (activity == activities.Last()) ? ";": ",";
                query += $"('{formatDate(activity.Date)}', '{activity.Name}', '{activity.Speaker}', '{activity.Purpose}', " +
                    $"'{activity.Result}', {getBool(activity.IsPresentation)}, {activity.ProfessorId}){delimiter}";
            }
            return query;
        }
        public string validateNull(string data)
        {
            return (data == null) ? "" : data;
        }
        public int getBool(bool data)
        {
            return (data) ? 1 : 0;
        }
       
        public string formatDate(string data)
        {
            DateTime fechaConvertida = DateTime.ParseExact(data, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string fechaFormateada = fechaConvertida.ToString("yyyy-MM-dd");
            return fechaFormateada;
        }
    }
}
