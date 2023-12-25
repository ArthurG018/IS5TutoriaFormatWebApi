using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IAssistanceApplication
    {
        string generateQueryAsistance(IEnumerable<AssistanceDto> assistances);
    }
}
