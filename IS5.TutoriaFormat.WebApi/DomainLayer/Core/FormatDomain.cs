using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.DomainLayer.Interface;
using IS5.TutoriaFormat.WebApi.InfraestructureLayer.Interface;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.DomainLayer.Core
{
    public class FormatDomain : IFormatDomain
    {
        private readonly IFormatRepository _formatRepository;

        public FormatDomain(IFormatRepository formatRepository)
        {
            _formatRepository = formatRepository;
        }

        public dynamic generateFormat2(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            return _formatRepository.generateFormat2(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }
        public dynamic generateFormat3(string queryProfessor, string queryStudents, string queryIncidendes)
        {
            return _formatRepository.generateFormat3(queryProfessor, queryStudents, queryIncidendes);
        }
        public dynamic generateFormat4(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance) { 
            return _formatRepository.generateFormat4(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }
        public dynamic generateFormat5(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance)
        {
            return _formatRepository.generateFormat5(queryProfessor, queryActivity, queryStudent, queryAssistance);
        }

    }
}
