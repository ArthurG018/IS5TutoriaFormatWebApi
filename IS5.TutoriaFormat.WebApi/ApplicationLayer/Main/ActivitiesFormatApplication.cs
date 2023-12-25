using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class ActivitiesFormatApplication:IActivitiesFormatApplication
    {
        private readonly IActivityApplication _activityApplication;
        private readonly IAssistanceApplication _assistanceApplication;
        private readonly IProfessorApplication _professorApplication;
        private readonly IStudentApplication _studentApplication;

        public ActivitiesFormatApplication(IActivityApplication activityApplication, IAssistanceApplication assistanceApplication, IProfessorApplication professorApplication, IStudentApplication studentApplication)
        {
            _activityApplication = activityApplication;
            _assistanceApplication = assistanceApplication;
            _professorApplication = professorApplication;
            _studentApplication = studentApplication;
        }

        public List<string> generateQuery(ActivitiesFormatDto activitiesFormat)
        {
            List<string> query = new List<string>();
            query.Add(_professorApplication.generateQueryProfessor(activitiesFormat.Professor));
            query.Add(_activityApplication.generateQueryActivity(activitiesFormat.Activities));
            query.Add(_studentApplication.generateQueryStudent(activitiesFormat.Students));
            query.Add(_assistanceApplication.generateQueryAsistance(activitiesFormat.Assistances));
            return query;
        }
        
    }
}
