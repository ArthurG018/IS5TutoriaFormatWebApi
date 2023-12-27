using System.Collections;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class ActivitiesFormatDto
    {
        public ProfessorDto Professor { get; set; } 
        public IEnumerable<StudentDto> Students { get; set; } 
        public IEnumerable<ActivityDto>? Activities { get; set; } 
        public IEnumerable<AssistanceDto> Assistances { get; set; } 
    }
}
