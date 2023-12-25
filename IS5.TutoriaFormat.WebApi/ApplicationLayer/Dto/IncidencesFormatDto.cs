namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class IncidencesFormatDto
    {
        public ProfessorDto Professor { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
        public IEnumerable<IncidenceDto> Incidences { get; set; }
    }
}
