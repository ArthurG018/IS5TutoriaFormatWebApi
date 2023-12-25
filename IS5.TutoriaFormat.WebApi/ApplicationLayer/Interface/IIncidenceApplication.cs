using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IIncidenceApplication
    {
        string generateQueryIncidence(IEnumerable<IncidenceDto> incidenceDtos);
    }
}
