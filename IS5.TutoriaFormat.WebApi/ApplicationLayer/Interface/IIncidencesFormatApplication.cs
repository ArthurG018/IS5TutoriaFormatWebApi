using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IIncidencesFormatApplication
    {
        List<string> generateQuery(IncidencesFormatDto incidencesFormatDto);
    }
}
