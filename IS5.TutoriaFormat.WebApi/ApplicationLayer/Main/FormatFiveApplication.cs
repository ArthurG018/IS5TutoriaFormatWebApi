using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatFiveApplication : IFormatFiveApplicationcs
    {

        private Dictionary<string, string> _replacePatterns = new Dictionary<string, string>();
        private const string _templatePath = @"Modules\Templates\FORMATO 05.docx";
        private const string _reportPath = @"Modules\Reports\";

        public void generateFormat(dynamic dynamic)
        {
            using( var document = DocX.Load(_templatePath))
            {

                             
                var professor = dynamic[0] as IDictionary<string, object>;
                var rows = dynamic.Count;
                var columns = 6;

                var table = document.AddTable(rows, columns);
                table.Alignment = Alignment.center;

                table.Rows[0].Cells[0].Paragraphs[0].Append("PROGRAMA DE ESTUDIOS");
                table.Rows[0].Cells[1].Paragraphs[0].Append("TUTOR");
                table.Rows[0].Cells[2].Paragraphs[0].Append("CICLO");
                table.Rows[0].Cells[3].Paragraphs[0].Append("CURSO");
                table.Rows[0].Cells[4].Paragraphs[0].Append("CÓDIGO UNIVERSITARIO");
                table.Rows[0].Cells[5].Paragraphs[0].Append("NOMBRE DEL ESTUDIANTE ATENDIDO");

                int mergeCells = 0;
                for(int i=1; i < dynamic.Count; i++)
                {
                    var students = dynamic[i] as IDictionary<string, object>;
                    int studentsPos = 4;
                    for(int j=6; j < students.Count; j++)
                    {
                        table.Rows[mergeCells + 1].Cells[studentsPos].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                        studentsPos++;
                    }
                    table.Rows[1].Cells[0].Merge(table.Rows[mergeCells+2].Cells[0]);
                    table.Rows[1].Cells[1].Merge(table.Rows[mergeCells+2].Cells[1]);
                    table.Rows[1].Cells[2].Merge(table.Rows[mergeCells+2].Cells[2]);
                    table.Rows[1].Cells[3].Merge(table.Rows[mergeCells+2].Cells[3]);
                    mergeCells++;
                }
                table.Rows[1].Cells[0].Paragraphs[0].Append(professor.ElementAt(0).Value.ToString());
                table.Rows[1].Cells[1].Paragraphs[0].Append(professor.ElementAt(1).Value.ToString());
                table.Rows[1].Cells[2].Paragraphs[0].Append(professor.ElementAt(2).Value.ToString());
                table.Rows[1].Cells[3].Paragraphs[0].Append(professor.ElementAt(5).Value.ToString());

                document.ReplaceTextWithObject("<table_student>", table);

                document.SaveAs(_reportPath + professor.ElementAt(4).Value + "-F05.docx");

            }
        }
        public IEnumerable<int> getTables(dynamic dynamic)
        {
            var tables = new List<int>();

            for (int i = 0; i < dynamic.Count; i++)
            {
                var professor = dynamic[i] as IDictionary<string, object>;
                if (professor.ElementAt(0).Value != null)
                {
                    tables.Add(i);
                }
            }
            //leng - 1 = cant tablas
            //contenido= alumnos, 0...
            return tables;
        }
    }
}
