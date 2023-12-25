using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IActivityApplication
    {
        string generateQueryActivity(IEnumerable<ActivityDto> activities);
    }
}
