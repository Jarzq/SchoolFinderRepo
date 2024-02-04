using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Helpers;
using SchoolFinder.Services;
using System.Net;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("/ImportExcelData")]
    public class ExcelDataController : ControllerBase
    {
        private readonly IExcelService _service;
        private readonly IConfiguration _configuration;

        public ExcelDataController(IExcelService service, IConfiguration configuration)
        {

            _service = service;
            _configuration = configuration;
        }

        [HttpPost(Name = "AddDataFromExcel")]
        public async Task<IActionResult> AddDataFromExcelWorksheet()
        {
            try
            {
                string fileName = _configuration["FileNames:SchoolsDataFilename"];
                string excelDatafilePath = Path.Combine(Directory.GetCurrentDirectory(), "Sources", fileName);

                var schoolEntities = ExcelHelper.ReadExcelFile(excelDatafilePath);

                await _service.EnsuretablesEmpty();

                await _service.AddSchoolEntities(schoolEntities);
                await _service.AddSubjects();
                await _service.AssignSubjects();
                await _service.AddSpecializations();
                await _service.AssignSpecializations();

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}