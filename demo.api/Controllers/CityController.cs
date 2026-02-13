using demo.api.Models;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly StudentDbContext _context;

        public CityController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAllCities")]
        public IActionResult getAllCityList()
        {
            var list = _context.CityMasters.ToList(); 
            return Ok(list);
        }

        [HttpPost("CreateNewCity")]
        public IActionResult AddNewCity(CityMaster obj)
        {
            var isCityExist = _context.CityMasters.SingleOrDefault(x => x.cityName == obj.cityName);
            // select * from tbl whwree cityName= 
            if(isCityExist == null)
            {
                _context.CityMasters.Add(obj);
                _context.SaveChanges();
                return Created("City Created", obj);
            } else
            {
                return BadRequest("City Name Already Exist");
            }
        }

        [HttpPost("BulkUploadCity")]
        public IActionResult AddBulkCity(List<CityMaster> objList)
        {
            foreach (var obj in objList)
            {
                if (obj.cityId != 0)
                {
                    var oldCityData = _context.CityMasters.SingleOrDefault(x => x.cityId == obj.cityId);
                    if (oldCityData != null)
                    {
                        oldCityData.cityName = obj.cityName;
                        _context.CityMasters.Update(oldCityData);
                    }
                }
                else
                {
                    var isCityExist = _context.CityMasters.SingleOrDefault(x => x.cityName == obj.cityName);
                    if (isCityExist == null)
                    {
                        _context.CityMasters.Add(obj);
                    }
                }

            }
            _context.SaveChanges();
            return Created("Bulk City Created", objList);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            List<string> cityNames;
            using (var stream = file.OpenReadStream())
            {
                cityNames = ReadCityNames(stream);
            }

            foreach (var cityName in cityNames)
            {
                var isCityExist = _context.CityMasters.SingleOrDefault(x => x.cityName == cityName);
                if (isCityExist == null)
                {
                    CityMaster obj = new CityMaster
                    {
                        cityName = cityName
                    };
                    _context.CityMasters.Add(obj);
                }
            }
            await _context.SaveChangesAsync();
            return Ok("Cities imported successfully.");
        }

        private List<string> ReadCityNames(Stream excelStream)
        {
            var cityNames = new List<string>();
            using (var document = SpreadsheetDocument.Open(excelStream, false))
            {
                var workbookPart = document.WorkbookPart;
                var sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Get header row to find cityName column index
                var headerRow = sheetData.Elements<Row>().First();
                int cityNameColIndex = -1;
                int colIdx = 0;
                foreach (Cell cell in headerRow.Elements<Cell>())
                {
                    string header = GetCellValue(cell, workbookPart);
                    if (header == "cityName")
                    {
                        cityNameColIndex = colIdx;
                        break;
                    }
                    colIdx++;
                }
                if (cityNameColIndex == -1)
                    return cityNames; // cityName column not found

                // Read data rows
                foreach (Row row in sheetData.Elements<Row>().Skip(1))
                {
                    var cells = row.Elements<Cell>().ToList();
                    if (cityNameColIndex < cells.Count)
                    {
                        string cityName = GetCellValue(cells[cityNameColIndex], workbookPart);
                        if (!string.IsNullOrWhiteSpace(cityName))
                            cityNames.Add(cityName);
                    }
                }
            }
            return cityNames;
        }

        private string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            string value = cell.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                var stringTable = workbookPart.SharedStringTablePart.SharedStringTable;
                value = stringTable.ElementAt(int.Parse(value)).InnerText;
            }
            return value;
        }


    }
}

