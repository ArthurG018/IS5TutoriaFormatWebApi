﻿using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace IS5.TutoriaFormat.WebApi.ApplicationLayer.Main
{
    public class FormatOneApplication:IFormatOneApplication
    {
        private Dictionary<string, string> _replacePatterns = new Dictionary<string, string>();

        private const string _templatePath = @"Modules\Templates\FORMATO 01.docx";
        private const string _reportPath = @"Modules\Reports\";

        public void generateFormat(ProfessorDto professorDto)
        {
            loadDictonary(professorDto);

            using (var document = DocX.Load(_templatePath))
            {
                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Count > 0)
                {
                    var replaceText = new FunctionReplaceTextOptions()
                    {
                        FindPattern = "<(.*?)>",
                        RegexMatchHandler = replaceFunc,
                        RegExOptions = RegexOptions.IgnoreCase
                    };
                    document.ReplaceText(replaceText);
                    document.SaveAs(_reportPath + professorDto.Dni + "-F01.docx");
                }
            }
        }

        public ResponseDto getFormat(ProfessorDto professorDto)
        {
            var response = new ResponseDto();
            using (var document = DocX.Load(_reportPath+professorDto.Dni+ "-F01.docx"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    document.SaveAs(memoryStream);
                    response.Format = memoryStream.ToArray();
                    response.Status = true;
                    response.NumberFormat = 1;
                    response.Name = professorDto.Dni + "-F01";
                }
            }
            return response;
        }

        public void loadDictonary(ProfessorDto professorDto)
        {
            _replacePatterns.Add("FullName", professorDto.FullName);
            _replacePatterns.Add("School", professorDto.School);
            _replacePatterns.Add("Semester", professorDto.Semester);
            _replacePatterns.Add("Profession", professorDto.Profession);
            _replacePatterns.Add("AcademicDegree", professorDto.AcademicDegree);
            _replacePatterns.Add("Faculty", professorDto.Faculty);
            _replacePatterns.Add("Shift", professorDto.Shift);
            _replacePatterns.Add("Phone", professorDto.Phone);
            _replacePatterns.Add("Email", professorDto.Email);
            _replacePatterns.Add("Place", professorDto.Place);
            _replacePatterns.Add("Amount", professorDto.Amount.ToString());
            _replacePatterns.Add("Schedules", getSchedules(professorDto.Schedules));

        }

        public string replaceFunc(string findKey)
        {
            if (_replacePatterns.ContainsKey(findKey))
            {
                return _replacePatterns[findKey];
            }
            return findKey;
        }
        public string getSchedules(IEnumerable<ScheduleDto> scheduleDtos)
        {
            var result = "";
            foreach (var scheduleDto in scheduleDtos)
            {
                string delim = (scheduleDto == scheduleDtos.Last()) ? "" : "\n";
                result += scheduleDto.Day + " " + scheduleDto.StartTime + " " + scheduleDto.EndTime + delim;
            }
            return result;
        }
    }
}