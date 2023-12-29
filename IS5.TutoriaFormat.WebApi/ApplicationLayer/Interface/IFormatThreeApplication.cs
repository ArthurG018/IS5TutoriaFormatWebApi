using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IFormatThreeApplication
    {
        void generateFormat(dynamic dynamic);
        ResponseDto getFormat(dynamic dynamic);
        void deleteFormat(dynamic dynamic);
    }
}
