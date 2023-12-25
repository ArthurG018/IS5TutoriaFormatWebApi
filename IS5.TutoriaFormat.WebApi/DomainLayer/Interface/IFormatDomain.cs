﻿using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;

namespace IS5.TutoriaFormat.WebApi.DomainLayer.Interface
{
    public interface IFormatDomain
    {
        dynamic generateFormat2(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance);
        dynamic generateFormat3(string queryProfessor, string queryStudents, string queryIncidendes);
        dynamic generateFormat4(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance);

        dynamic generateFormat5(string queryProfessor, string queryActivity, string queryStudent, string queryAssistance);
    }
}