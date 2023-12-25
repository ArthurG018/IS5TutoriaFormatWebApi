using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class StudentApplication : IStudentApplication
    {
        public string generateQueryStudent(IEnumerable<StudentDto> students)
        {
            var query = "";
            var delimiter = "";
            foreach (var student in students)
            {
                delimiter = (student == students.Last()) ? ";" : ",";
                query += $"('{student.UniversityCode}', '{student.FullName}','{student.UniversityCode}@unjfsc.edu.pe', '{validateNull(student.Dni)}', " +
                    $"'{validateNull(student.RegistrationForm)}', {getBool(student.IsActive)}, {getBool(student.IsRisk)}){delimiter}";
            }
            return query;
        }
        public int getBool(bool isBool)
        {
            return (isBool) ? 1 : 0;
        }
        public string validateNull(string data)
        {
            return (data == null) ? "": data;
        }
    }
}
