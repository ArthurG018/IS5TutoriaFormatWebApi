using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IStudentApplication
    {
        string generateQueryStudent(IEnumerable<StudentDto> students);
    }
}
