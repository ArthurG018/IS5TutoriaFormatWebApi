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
        public void generateFormat(EvidenceFormatDto evidenceFormatDto)
        {
            using(var document = DocX.Create(_reportPath + evidenceFormatDto.Professor.Dni.ToString() + "-F06.docx"))
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
                }
                document.Save();
            }
        }
    }
}
