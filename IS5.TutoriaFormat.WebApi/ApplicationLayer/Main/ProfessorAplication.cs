using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class ProfessorAplication : IProfessorApplication
    {
        public string generateQueryProfessor(ProfessorDto professor)
        {
            var query = $"('{professor.FullName}', '{professor.Dni}', '{professor.Phone}', " +
                        $"'{professor.Email}', '{professor.Profession}', '{professor.AcademicDegree}', " +
                        $"'{professor.School}', '{professor.Faculty}', '{professor.Section}','{professor.Semester}');";
            return query ;
        }
    }
}
