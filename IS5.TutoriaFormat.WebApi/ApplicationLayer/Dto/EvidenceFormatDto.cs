namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto
{
    public class EvidenceFormatDto
    {
        public ProfessorDto Professor { get; set; }
        public List<byte[]> Evidences { get; set; }
    }
}
