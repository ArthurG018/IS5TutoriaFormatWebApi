using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface
{
    public interface IFormatEvidencesApplication
    {
        void generateFormat(EvidenceFormatDto evidenceFormatDto);
        ResponseDto getFormat(EvidenceFormatDto evidenceFormatDto);
        void deleteFormat(EvidenceFormatDto evidenceFormatDto);
    }
}
