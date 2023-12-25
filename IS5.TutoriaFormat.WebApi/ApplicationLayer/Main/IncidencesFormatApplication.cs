using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class IncidencesFormatApplication:IIncidencesFormatApplication
    {
        private readonly IProfessorApplication _professorApplication;
        private readonly IStudentApplication _studentApplication;
        private readonly IIncidenceApplication _incidentApplication;

        public IncidencesFormatApplication(IProfessorApplication professorApplication, IStudentApplication studentApplication, IIncidenceApplication incidentApplication)
        {
            _professorApplication = professorApplication;
            _studentApplication = studentApplication;
            _incidentApplication = incidentApplication;
        }

        public List<string> generateQuery(IncidencesFormatDto incidencesFormatDto)
        {
            var query = new List<string>();
            query.Add(_professorApplication.generateQueryProfessor(incidencesFormatDto.Professor));
            query.Add(_studentApplication.generateQueryStudent(incidencesFormatDto.Students));
            query.Add(_incidentApplication.generateQueryIncidence(incidencesFormatDto.Incidences));
            return query;
        }
    }
}
