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
                List<int> numTables = getTables(dynamic);
                             
                var professor = dynamic[0] as IDictionary<string, object>;
                var rows = dynamic.Count - numTables.Count + 1 ;
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
                int posInitialMegre = 1;
                /*llenar primera fila del merge*/
                table.Rows[1].Cells[0].Paragraphs[0].Append(professor.ElementAt(0).Value.ToString());
                table.Rows[1].Cells[1].Paragraphs[0].Append(professor.ElementAt(1).Value.ToString());
                table.Rows[1].Cells[2].Paragraphs[0].Append(professor.ElementAt(2).Value.ToString());
                table.Rows[1].Cells[3].Paragraphs[0].Append(professor.ElementAt(5).Value.ToString());

                List<int> joinRows = new List<int>();
                joinRows.Add(1);

                for (int i=1; i < dynamic.Count; i++)
                {
                    var students = dynamic[i] as IDictionary<string, object>;
                    if (students.ElementAt(0).Value == null)
                    {
                        int studentsPos = 4;
                        for (int j = 6; j < students.Count; j++)
                        {
                            table.Rows[i].Cells[studentsPos].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                            studentsPos++;
                            mergeCells = i;
                        }
                    }
                    else
                    {
                        table.Rows[i].Cells[0].Paragraphs[0].Append(students.ElementAt(0).Value.ToString());
                        table.Rows[i].Cells[1].Paragraphs[0].Append(students.ElementAt(1).Value.ToString());
                        table.Rows[i].Cells[2].Paragraphs[0].Append(students.ElementAt(2).Value.ToString());
                        table.Rows[i].Cells[3].Paragraphs[0].Append(students.ElementAt(5).Value.ToString());
                        posInitialMegre = i;

                        joinRows.Add(i-1);
                    }
                }
               
                for(int i = 0; i < joinRows.Count; i++)
                {
                    if (i + 1 < joinRows.Count)
                    {
                        table.MergeCellsInColumn(0, joinRows.ElementAt(i), joinRows.ElementAt(i + 1));
                        table.MergeCellsInColumn(1, joinRows.ElementAt(i), joinRows.ElementAt(i + 1));
                        table.MergeCellsInColumn(2, joinRows.ElementAt(i), joinRows.ElementAt(i + 1));
                        table.MergeCellsInColumn(3, joinRows.ElementAt(i), joinRows.ElementAt(i + 1));
                    }
                    else
                    {
                        table.MergeCellsInColumn(0, joinRows.ElementAt(i),mergeCells);
                        table.MergeCellsInColumn(1, joinRows.ElementAt(i),mergeCells);
                        table.MergeCellsInColumn(2, joinRows.ElementAt(i),mergeCells);
                        table.MergeCellsInColumn(3, joinRows.ElementAt(i),mergeCells);
                    }
                }


                document.ReplaceTextWithObject("<table_student>", table);

                document.SaveAs(_reportPath + professor.ElementAt(4).Value + "-F05.docx");

            }
        }
        
        public IEnumerable<int> getTables(dynamic dynamic)
        {
            List<int> numTables = new List<int>();
            for (int i = 0; i < dynamic.Count; i++)
            {
                var professor = dynamic[i] as IDictionary<string, object>;
                if (professor.ElementAt(0).Value != null)
                {
                    numTables.Add(i);
                }
            }
            return numTables;
        }
    }
}
