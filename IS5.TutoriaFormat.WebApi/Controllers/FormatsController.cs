using IS5.TutoriaFormat.WebApi.ApplicationLayer.Dto;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IS5.TutoriaFormat.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatApplication _formatApplication;
        private readonly IActivitiesFormatApplication _activitiesFormatApplication;
        private readonly IIncidencesFormatApplication _incidentidencesFormatApplication;
        private readonly IFormatOneApplication _formatOneApplication;
        private readonly IFormatTwoApplication _formatTwoApplication;
        private readonly IFormatThreeApplication _formatThreeApplication;
        private readonly IFormatFourApplication _formatFourApplication;
        private readonly IFormatFiveApplicationcs _formatFiveApplicationcs;

        public FormatsController(IFormatApplication formatApplication, IActivitiesFormatApplication activitiesFormatApplication, IIncidencesFormatApplication incidentidencesFormatApplication, IFormatOneApplication formatOneApplication, IFormatTwoApplication formatTwoApplication, IFormatThreeApplication formatThreeApplication, IFormatFourApplication formatFourApplication, IFormatFiveApplicationcs formatFiveApplicationcs)
        {
            _formatApplication = formatApplication;
            _activitiesFormatApplication = activitiesFormatApplication;
            _incidentidencesFormatApplication = incidentidencesFormatApplication;
            _formatOneApplication = formatOneApplication;
            _formatTwoApplication = formatTwoApplication;
            _formatThreeApplication = formatThreeApplication;
            _formatFourApplication = formatFourApplication;
            _formatFiveApplicationcs = formatFiveApplicationcs;
        }

        [HttpPost]
        [ActionName("FormatOne")]
        public IActionResult FormatOne([FromBody] ProfessorDto professorDto)
        {
            if (professorDto == null) return BadRequest();
            _formatOneApplication.generateFormat(professorDto);
            var response = _formatOneApplication.getFormat(professorDto);
            return Ok(response);

        }

        [HttpPost]
        [ActionName("FormatTwo")]
        public IActionResult FormatTwo([FromBody] ActivitiesFormatDto activitiesFormat)
        {
            if (activitiesFormat == null) return BadRequest();
            var querys = _activitiesFormatApplication.generateQuery(activitiesFormat);
            var dynamic = _formatApplication.generateFormat2(querys[0], querys[1], querys[2], querys[3]);
            _formatTwoApplication.generateFormat(dynamic);
            var response = _formatTwoApplication.getFormat(dynamic);
            
            return Ok(dynamic);


        }
        [HttpPost]
        [ActionName("FormatThree")]
        public IActionResult FormatTwo([FromBody] IncidencesFormatDto incidencesFormatDto)
        {
            if (incidencesFormatDto == null) return BadRequest();
            var querys = _incidentidencesFormatApplication.generateQuery(incidencesFormatDto);
            var dynamic = _formatApplication.generateFormat3(querys[0], querys[1], querys[2]);
            return Ok(dynamic);

        }
        [HttpPost]
        [ActionName("FormatFour")]
        public IActionResult FormatFour([FromBody] ActivitiesFormatDto activitiesFormat)
        {
            if (activitiesFormat == null) return BadRequest();
            var querys = _activitiesFormatApplication.generateQuery(activitiesFormat);
            var dynamic = _formatApplication.generateFormat5(querys[0], querys[1], querys[2], querys[3]);
           

            return Ok(dynamic);

        }


        [HttpPost]
        [ActionName("FormatFive")]
        public IActionResult FormatFive([FromBody] ActivitiesFormatDto activitiesFormat)
        {
            if (activitiesFormat == null) return BadRequest();
            var querys = _activitiesFormatApplication.generateQuery(activitiesFormat);
            var dynamic = _formatApplication.generateFormat5(querys[0], querys[1], querys[2], querys[3]);
            //_formatTwoApplication.generateFormat(dynamic);
            //var response = _formatTwoApplication.getFormat(dynamic);
            //_formatFiveApplicationcs.generateFormat(dynamic);

            return Ok(dynamic);


        }


    }

}
