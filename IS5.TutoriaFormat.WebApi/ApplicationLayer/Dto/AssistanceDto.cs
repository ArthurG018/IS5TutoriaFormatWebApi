namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class AssistanceDto
    {
        public int AssistanceRowId { get; set; }
        public bool IsPresent { get; set; }
        public int ActivityId { get; set; }
        public int StudentId { get; set; }
    }
}
