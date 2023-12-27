using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
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
                var professor = dynamic[0] as IDictionary<string, object>;
                loadDictonary(professor);

                var rows = dynamic.Count;
                var columns = 6;

                var table = document.AddTable(rows, columns);
                table.Alignment = Alignment.center;
                table.SetWidthsPercentage(widthColumn());

                table.Rows[0].Cells[0].Paragraphs[0].Append("N°").Bold();
                table.Rows[0].Cells[1].Paragraphs[0].Append("CÓDIGO ESTUDIANTE").Bold();
                table.Rows[0].Cells[2].Paragraphs[0].Append("APELLIDOS Y NOMBRES").Bold();
                table.Rows[0].Cells[3].Paragraphs[0].Append("MOTIVO DE ATENCIÓN").Bold();
                table.Rows[0].Cells[4].Paragraphs[0].Append("TRATAMIENTO REALIZADO").Bold();
                table.Rows[0].Cells[5].Paragraphs[0].Append("OBSERVACIONES").Bold();

                for (int i=1; i<dynamic.Count; i++)
                {
                    var students = dynamic[i] as IDictionary<string, object>;
                    int celda = 0;
                    for (int j = 4; j<students.Count; j++)
                    {
                        table.Rows[i].Cells[celda].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                        celda++;
                    }
                }
                document.ReplaceTextWithObject("<table_students>", table);
                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                {
                    var replaceText = new FunctionReplaceTextOptions()
                    {
                        FindPattern = "<(.*?)>",
                        RegexMatchHandler = replaceFunc,
                        RegExOptions = RegexOptions.IgnoreCase
                    };
                    document.ReplaceText(replaceText);
                }
                document.SaveAs(_reportPath + professor.ElementAt(3).Value + "-F03.docx");
                //GenerateFormatAsHtml((string)professor.ElementAt(4).Value);

            }
            
        }
        public void loadDictonary(IDictionary<string, object> professor)
        {
            _replacePatterns.Add("FullName", (string) professor.ElementAt(1).Value);
            _replacePatterns.Add("School", (string) professor.ElementAt(0).Value);
            _replacePatterns.Add("Cycle", (string) professor.ElementAt(2).Value);
        }
        public string replaceFunc(string findKey)
        {
            if (_replacePatterns.ContainsKey(findKey))
            {
                return _replacePatterns[findKey];
            }
            return findKey;
        }
        public float[] widthColumn()
        {
            float[] widthColumn = new float[6];
            widthColumn[0] = 5f;
            widthColumn[1] = 15f;
            widthColumn[2] = 20f;
            widthColumn[3] = 15f;
            widthColumn[4] = 15f;
            widthColumn[5] = 30f;

            return widthColumn;
        }
    }
}
