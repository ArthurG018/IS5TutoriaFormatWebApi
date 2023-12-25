namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class IncidenceDto
    {
        public string Reason { get; set; }
        public string Treatment { get; set; }
        public string Observation { get; set; }
        public int ProfesorId { get; set; }
        public int StudentId { get; set; }
        public string StudentFullName { get; set; }
    }
}
