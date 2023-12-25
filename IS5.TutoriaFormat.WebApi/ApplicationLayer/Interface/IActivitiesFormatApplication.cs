using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IActivitiesFormatApplication
    {
        List<string> generateQuery(ActivitiesFormatDto activitiesFormat);
    }
}
