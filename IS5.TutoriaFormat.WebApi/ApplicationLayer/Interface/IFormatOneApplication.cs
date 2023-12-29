using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IFormatOneApplication
    {
        void generateFormat(ProfessorDto professorDto);
        ResponseDto getFormat(ProfessorDto professorDto);
        void deleteFormat(ProfessorDto professorDto);
    }
}
