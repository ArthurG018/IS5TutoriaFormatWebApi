using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.DomainLayer.Entity;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IFormatTwoApplication
    {
        void generateFormat(dynamic dynamic);
        ResponseDto getFormat(dynamic dynamic);
        void deleteFormat(dynamic dynamic);
    }
}
