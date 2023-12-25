using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatThreeApplication:IFormatThreeApplication
    {
        private Dictionary<string, string> _replacePatterns = new Dictionary<string, string>();
        private const string _templatePath = @"Modules\Templates\FORMATO 03.docx";
        private const string _reportPath = @"Modules\Reports\";
        public void generateFormat(dynamic dynamic)
        {
            using (var document = DocX.Load(_templatePath))
            {
                var rows = 0;
                var columns = 6;

                var table = document.AddTable(rows, columns);
                table.Alignment = Xceed.Document.NET.Alignment.center;

                table.Rows[0].Cells[0].Paragraphs[0].Append("N°");
                table.Rows[0].Cells[1].Paragraphs[0].Append("CÓDIGO ESTUDIANTE");
                table.Rows[0].Cells[2].Paragraphs[0].Append("APELLIDOS Y NOMBRES");
                table.Rows[0].Cells[3].Paragraphs[0].Append("MOTIVO DE ATENCIÓN");
                table.Rows[0].Cells[4].Paragraphs[0].Append("TRATAMIENTO REALIZADO");
                table.Rows[0].Cells[5].Paragraphs[0].Append("OBSERVACIONES");

                for(int i=0; i<dynamic.Count; i++)
                {
                    var students = dynamic[i] as IDictionary<string, object>;
                    for (int j = 0; j<students.Count; j++)
                    {

                    }
                }

            }
        }
    }
}
