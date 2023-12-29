using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatFourApplication:IFormatFourApplication
    {
        private Dictionary<string, string> _replacePatternsM1 = new Dictionary<string, string>();
        private Dictionary<string, string> _replacePatternsM2 = new Dictionary<string, string>();
        private Dictionary<string, string> _replacePatternsM3 = new Dictionary<string, string>();
        private Dictionary<string, string> _replacePatternsM4 = new Dictionary<string, string>();
        private Dictionary<string, string> _replacePatternsT = new Dictionary<string, string>();
        private const string _templatePath = @"Modules\Templates\FORMATO 04.docx";
        private const string _reportPath = @"Modules\Reports\";
        public void generateFormat(dynamic dynamic)
        {
            using (var document = DocX.Load(_templatePath))
            {
                var professorData = dynamic[0] as IDictionary<string, object>;

                //conocer cuantas tablas:
                List<int> numTable = RowsTable(dynamic);
                List<int> listRow = new List<int>();
                for (int i = 0; i < numTable.Count; i++)
                {
                    if (numTable.ElementAt(i) == numTable.Last())
                    {

                        listRow.Add(dynamic.Count - (numTable.ElementAt(i)));

                    }
                    else 
                    {
                        
                        listRow.Add((dynamic.Count - (int) numTable.ElementAt(i)) - (dynamic.Count - (int) numTable.ElementAt(i+1)) );
                    }
                }

                if (numTable.Count > 0)
                {
                    var rows = listRow.ElementAt(0);
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();

                    int profPos = dynamic.Count;
                    int elementPos = numTable.ElementAt(0) + 1;

                    for (int i = elementPos; i < dynamic.Count; i++)
                    {
                        var students = dynamic[i] as IDictionary<string, object>;

                        if (students.ElementAt(0).Value != null || rows == 1) break;
                        int celda = 0;
                        for (int j = 5; j < students.Count; j++)
                        {
                            table.Rows[i].Cells[celda].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                            celda++;
                        }
                    }
                    var professor = dynamic[numTable.ElementAt(0)] as IDictionary<string, object>;
                    loadDictonaryM1(professor);
                    document.ReplaceTextWithObject("<table_mes1>", table);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncM1,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                else
                {
                    var rows = 2;
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();
                    document.ReplaceTextWithObject("<table_mes1>", table);
                    loadDictonaryT(1);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncT,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }

                }

                if (numTable.Count > 1)
                {
                    var rows = listRow.ElementAt(1);
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();

                    int profPos = dynamic.Count;
                    int elementPos = numTable.ElementAt(1) + 1;
                    int rowsPos = numTable.ElementAt(1);
                    int countRow = 1;
                    for (int i = elementPos; i < dynamic.Count; i++)
                    {
                        var students = dynamic[i] as IDictionary<string, object>;
                       

                        if (students.ElementAt(0).Value != null || rows == 1) break;
                        int celda = 0;
                        for (int j = 5; j < students.Count; j++)
                        {
                            table.Rows[countRow].Cells[celda].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                            celda++;
                        }
                        countRow++;
                    }
                    var professor = dynamic[numTable.ElementAt(1)] as IDictionary<string, object>;
                    loadDictonaryM2(professor);
                    document.ReplaceTextWithObject("<table_mes2>", table);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncM2,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                else
                {
                    var rows = 2;
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();
                    document.ReplaceTextWithObject("<table_mes2>", table);
                    loadDictonaryT(2);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncT,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }

                }
                if (numTable.Count > 2)
                {
                    var rows = listRow.ElementAt(2);
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();

                    int profPos = dynamic.Count;
                    int elementPos = numTable.ElementAt(2) + 1;
                    int countRow = 1;
                    for (int i = elementPos; i < dynamic.Count; i++)
                    {
                        var students = dynamic[i] as IDictionary<string, object>;

                        if (students.ElementAt(0).Value != null || rows == 1) break;
                        int celda = 0;

                        for (int j = 5; j < students.Count; j++)
                        {
                            table.Rows[countRow].Cells[celda].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                            celda++;
                        }

                        countRow++;
                    }
                    var professor = dynamic[numTable.ElementAt(2)] as IDictionary<string, object>;
                    loadDictonaryM3(professor);
                    document.ReplaceTextWithObject("<table_mes3>", table);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncM3,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                else
                {
                    var rows = 2;
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();
                    document.ReplaceTextWithObject("<table_mes3>", table);
                    loadDictonaryT(3);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncT,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                if (numTable.Count > 3)
                {
                    var rows = listRow.ElementAt(3);
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();

                    int profPos = dynamic.Count;
                    int elementPos = numTable.ElementAt(3) + 1;
                    int countRow = 1;
                    for (int i = elementPos; i < dynamic.Count; i++)
                    {
                        var students = dynamic[i] as IDictionary<string, object>;

                        if (students.ElementAt(0).Value != null || rows == 1) break;
                        int celda = 0;
                        for (int j = 5; j < students.Count; j++)
                        {
                            table.Rows[countRow].Cells[celda].Paragraphs[0].Append(students.ElementAt(j).Value.ToString());
                            celda++;
                        }

                        countRow++;
                    }
                    var professor = dynamic[numTable.ElementAt(2)] as IDictionary<string, object>;
                    loadDictonaryM4(professor);
                    document.ReplaceTextWithObject("<table_mes4>", table);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncM4,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                else
                {
                    var rows = 2;
                    var columns = 6;

                    var table = document.AddTable(rows, columns);
                    table.Alignment = Alignment.center;
                    table.SetWidthsPercentage(widthColumn());

                    table.Rows[0].Cells[0].Paragraphs[0].Append("FECHA").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("ACTIVIDAD").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("PONENTE").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("PROPÓSITO").Bold();
                    table.Rows[0].Cells[4].Paragraphs[0].Append("CANTIDAD DE ESTUDIANTES").Bold();
                    table.Rows[0].Cells[5].Paragraphs[0].Append("RESULTADO").Bold();
                    document.ReplaceTextWithObject("<table_mes4>", table);
                    loadDictonaryT(4);
                    if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                    {
                        var replaceText = new FunctionReplaceTextOptions()
                        {
                            FindPattern = "<(.*?)>",
                            RegexMatchHandler = replaceFuncT,
                            RegExOptions = RegexOptions.IgnoreCase
                        };
                        document.ReplaceText(replaceText);
                    }
                }
                
                document.SaveAs(_reportPath + professorData.ElementAt(3).Value + "-F04.docx");

            }
        }
        public ResponseDto getFormat(dynamic dynamic)
        {
            var response = new ResponseDto();
            var professor = dynamic[0] as IDictionary<string, object>;
            using (var document = DocX.Load(_reportPath + professor.ElementAt(3).Value + "-F04.docx"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    document.SaveAs(memoryStream);
                    response.Format = memoryStream.ToArray();
                    response.Status = true;
                    response.NumberFormat = 1;
                    response.Name = professor.ElementAt(3).Value + "-F04";
                }
            }
            return response;
        }
        public void loadDictonaryM1(IDictionary<string, object> professor)
        {
            _replacePatternsM1.Add("FullName", (string)professor.ElementAt(1).Value);
            _replacePatternsM1.Add("Semester", (string)professor.ElementAt(0).Value);
            _replacePatternsM1.Add("Cycle", (string)professor.ElementAt(2).Value);
            _replacePatternsM1.Add("Mes1", (string) professor.ElementAt(4).Value);
        }
        public void loadDictonaryM2(IDictionary<string, object> professor)
        {
            _replacePatternsM2.Add("Mes2", (string)professor.ElementAt(4).Value);
        }
        public void loadDictonaryM3(IDictionary<string, object> professor)
        {
            _replacePatternsM3.Add("Mes3", (string)professor.ElementAt(4).Value);
        }
        public void loadDictonaryM4(IDictionary<string, object> professor)
        {
            _replacePatternsM4.Add("Mes4", (string)professor.ElementAt(4).Value);
        }
        public void loadDictonaryT( int opc)
        {
            switch (opc)
            {
                case 1:
                    _replacePatternsT.Add("Mes1", "");
                    _replacePatternsT.Add("table_mes1", "");
                    _replacePatternsT.Add("FullName", "");
                    _replacePatternsT.Add("Semester", "");
                    _replacePatternsT.Add("Cycle", "");
                    break;
                case 2:
                    _replacePatternsT.Add("Mes2", "");
                    _replacePatternsT.Add("table_mes2", "");
                    break;
                case 3:
                    _replacePatternsT.Add("Mes3", "");
                    _replacePatternsT.Add("table_mes3", "");
                    break;
                case 4:
                    _replacePatternsT.Add("Mes4", "");
                    _replacePatternsT.Add("table_mes4", "");
                    break;
            }

        }
        public string replaceFuncM1(string findKey)
        {
            if (_replacePatternsM1.ContainsKey(findKey))
            {
                return _replacePatternsM1[findKey];
            }
            return "<" + findKey + ">";
        }
        public string replaceFuncM2(string findKey)
        {
            if (_replacePatternsM2.ContainsKey(findKey))
            {
                return _replacePatternsM2[findKey];
            }
            return "<"+findKey+">";
        }
        public string replaceFuncM3(string findKey)
        {
            if (_replacePatternsM3.ContainsKey(findKey))
            {
                return _replacePatternsM3[findKey];
            }
            return "<" + findKey + ">";
        }
        public string replaceFuncM4(string findKey)
        {
            if (_replacePatternsM4.ContainsKey(findKey))
            {
                return _replacePatternsM4[findKey];
            }
            return "<" + findKey + ">";
        }
        public string replaceFuncT(string findKey)
        {
            if (_replacePatternsT.ContainsKey(findKey))
            {
                return _replacePatternsT[findKey];
            }
            return "<" + findKey + ">";
        }
        public float[] widthColumn()
        {
            float[] widthColumn = new float[6];
            widthColumn[0] = 10f;
            widthColumn[1] = 20f;
            widthColumn[2] = 15f;
            widthColumn[3] = 15f;
            widthColumn[4] = 10f;
            widthColumn[5] = 30f;

            return widthColumn;
        }
        public IEnumerable<int> RowsTable(dynamic dynamic)
        {
            List<int> numTables = new List<int>();
            for (int i=0; i<dynamic.Count; i++)
            {
                var professor = dynamic[i] as IDictionary<string, object>;
                if (professor.ElementAt(0).Value != null)
                {
                    numTables.Add(i);
                }
            }
            return numTables;
        }

        public void deleteFormat(dynamic dynamic)
        {
            var professor = dynamic[0] as IDictionary<string, object>;
            var path = _reportPath + professor.ElementAt(3).Value + "-F04.docx";
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
