using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatTwoApplication : IFormatTwoApplication
    {

        private Dictionary<string, string> _replacePatterns = new Dictionary<string, string>();
        private const string _templatePath = @"Modules\Templates\FORMATO 02.docx";
        private const string _reportPath = @"Modules\Reports\";

        public void generateFormat(dynamic dynamic)
        {
            using (var document = DocX.Load(_templatePath))
            {
                var professor = dynamic[0] as IDictionary<string, object>;
                loadDictonary(professor);

                var rows = dynamic.Count;
                var columns = professor.Count - 5;
                var table = document.AddTable(rows, columns);

                table.Alignment = Alignment.center;
                table.SetWidthsPercentage(widthColumn(columns));
                
                table.Rows[0].Cells[0].Paragraphs[0].Append("N°");
                table.Rows[0].Cells[1].Paragraphs[0].Append("Apellidos y Nombres");
                table.Rows[0].Cells[2].Paragraphs[0].Append("Código del estudiante");
                table.Rows[0].Cells[3].Paragraphs[0].Append("Correo electrónico");
                
                int professorPos = 4;
                for(int i=9; i<professor.Count; i++)
                {
                    table.Rows[0].Cells[professorPos].Paragraphs[0].Append(professor.ElementAt(i).Key.ToString()).FontSize(10);
                    professorPos++;
                }
                /*Content*/
                for (int i = 1; i<dynamic.Count; i++)
                {
                    var students = dynamic[i] as IDictionary<string, object>;
                    int studentPos = 0;
                    for (int j = 5; j<students.Count; j++)
                    {
                        
                        table.Rows[i].Cells[studentPos].Paragraphs[0].Append((students.ElementAt(j).Value != null) ? students.ElementAt(j).Value.ToString() : "");

                        studentPos++;
                    }
                }
                document.ReplaceTextWithObject("<tabla_student>", table);
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
                document.SaveAs(_reportPath+professor.ElementAt(4).Value+"-F02.docx");
            }

        }

        public ResponseDto getFormat(dynamic dynamic)
        {
            var response = new ResponseDto();
            var professor = dynamic[0] as IDictionary<string, object>;
            using (var document = DocX.Load(_reportPath + professor.ElementAt(4).Value + "-F02.docx"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    document.SaveAs(memoryStream);
                    response.Format = memoryStream.ToArray();
                    response.Status = true;
                    response.NumberFormat = 2;
                    response.Name = professor.ElementAt(4).Value + "-F02";
                }
            }
            return response;
        }

        public float[] widthColumn(int columns)
        {
            float[] widthColumn = new float[columns];
            widthColumn[0] = 5f;
            widthColumn[1] = 30f;
            widthColumn[2] = 20f;
            widthColumn[3] = 20f;
            int widthColumnPos = 4;
            for (int i = 0; i < (columns - 4); i++)
            {
                widthColumn[widthColumnPos] = (25f / (columns - 4));
                widthColumnPos++;
            }
            return widthColumn;
        }

        public void loadDictonary(IDictionary<string, object> professor)
        {
            _replacePatterns.Add("FullName", professor.ElementAt(0).Value.ToString());
            _replacePatterns.Add("School", professor.ElementAt(1).Value.ToString());
            _replacePatterns.Add("Semester", professor.ElementAt(2).Value.ToString());
        }
        public string replaceFunc(string findKey)
        {
            if (_replacePatterns.ContainsKey(findKey))
            {
                return _replacePatterns[findKey];
            }
            return findKey;
        }

        public void deleteFormat(dynamic dynamic)
        {
            var professor = dynamic[0] as IDictionary<string, object>;
            var path = _reportPath + professor.ElementAt(4).Value + "-F02.docx";
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            }
            catch
            {

            }
        }
    }
}
