using Microsoft.AspNetCore.Mvc;
using SchoolFinder.Helpers;
using SchoolFinder.Services;
using System.Net;

namespace SchoolFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task AddDataFromExcelWorksheet()
        {
            string fileName = _configuration["FileNames:SchoolsDataFilename"];
            string excelDatafilePath = Path.Combine(Directory.GetCurrentDirectory(), "Sources", fileName);

            var schoolEntities = ExcelHelper.ReadExcelFile(excelDatafilePath);

            //await _service.AddSchoolEntityList(schoolEntities);
             //_service.AddSubjects(schoolEntities);
             await _service.AddSchoolTypes(schoolEntities);

            Response.StatusCode = (int)HttpStatusCode.Created;
        }
    }
}