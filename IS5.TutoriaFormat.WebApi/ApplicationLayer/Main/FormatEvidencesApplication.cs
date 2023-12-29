using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatEvidencesApplication : IFormatEvidencesApplication
    {
        private const string _templatePath = @"Modules\Templates\FORMATO 06.docx";
        private const string _reportPath = @"Modules\Reports\";

        public void deleteFormat(EvidenceFormatDto evidenceFormatDto)
        {
            var path = _reportPath + evidenceFormatDto.Professor.Dni.ToString() + "-F06.docx";
            try 
            { 
                if(File.Exists(path))
                {
                    File.Delete(path);
                }
                 
            } 
            catch
            {

            }
        }

        public void generateFormat(EvidenceFormatDto evidenceFormatDto)
        {
            using(var document = DocX.Load(_templatePath))
            {
                
                foreach (var imageBytes in evidenceFormatDto.Evidences)
                {
                    using (var memoryStream = new MemoryStream(Convert.FromBase64String(imageBytes)))
                    {
                        var image = document.AddImage(memoryStream);
                        Picture picture = image.CreatePicture();

                        // Ajustar el tamaño de la imagen
                        picture.Width = 300;
                        picture.Height = 200;

                        // Insertar la imagen en el documento
                        document.InsertParagraph().InsertPicture(picture);
                    }
                    //Parrafo Vacio
                    document.InsertParagraph();
                }
                document.SaveAs(_reportPath + evidenceFormatDto.Professor.Dni.ToString() + "-F06.docx");
            }
        }
        public ResponseDto getFormat(EvidenceFormatDto evidenceFormatDto)
        {
            var response = new ResponseDto();
            var professor = evidenceFormatDto.Professor;
            using (var document = DocX.Load(_reportPath + professor.Dni.ToString() + "-F06.docx"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    document.SaveAs(memoryStream);
                    response.Format = memoryStream.ToArray();
                    response.Status = true;
                    response.NumberFormat = 1;
                    response.Name = professor.Dni.ToString() + "-F06";
                }
            }
            return response;
        }
    }
}
