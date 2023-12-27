namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class ActivityDto
    {
        public int ActivityRowId { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string? Speaker {  get; set; }
        public string? Purpose { get; set; }
        public string? Result { get; set; }
        public bool IsPresentation { get; set; }
        public int ProfessorId { get; set; }
    }
}
