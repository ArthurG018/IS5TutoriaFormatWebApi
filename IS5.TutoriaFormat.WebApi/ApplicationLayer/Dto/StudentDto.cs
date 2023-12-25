namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class StudentDto
    {
        public int StudentRowId { get; set; }
        public string UniversityCode { get; set; }
        public string FullName { get; set; }
        public string? Dni { get; set; }
        public string? RegistrationForm { get; set; }
        public bool IsActive { get; set; }
        public bool IsRisk { get; set; }
    }
}
