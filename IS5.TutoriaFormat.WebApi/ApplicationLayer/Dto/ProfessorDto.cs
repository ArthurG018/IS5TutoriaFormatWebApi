namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class ProfessorDto
    {
        public int ProfessorRowId { get; set; }
        public string FullName { get; set; }
        public string Dni { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string AcademicDegree { get; set; }
        public string School { get; set; }
        public string Faculty { get; set; }
        public string Semester { get; set; }
        public string Shift { get; set; }
        public string Place {  get; set; }
        public int Amount { get; set; }
        public string Section { get; set; }
        public IEnumerable<ScheduleDto> Schedules { get; set; }
    }
}
