using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using IS5.TutoriaFormat.WebApi.DomainLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatApplication:IFormatApplication
    {
        private readonly IFormatDomain _formatDomain;

        public FormatApplication(IFormatDomain formatDomain)
        {
            _formatDomain = formatDomain;
        }
        public dynamic generateFormat2(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            return _formatDomain.generateFormat2(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }
        public dynamic generateFormat3(string queryProfessor, string queryStudents, string queryIncidendes)
        {
            return _formatDomain.generateFormat3(queryProfessor, queryStudents, queryIncidendes);
        }
        public dynamic generateFormat4(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            return _formatDomain.generateFormat4(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }
        public dynamic generateFormat5(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            return _formatDomain.generateFormat5(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }
    }
}
