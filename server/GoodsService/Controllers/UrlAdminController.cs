using System.Data.OleDb;
using OfficeOpenXml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Controllers;

[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
public class UrlAdminController : BaseController
{
    private readonly IEcoDbContext _dbContext;

    public UrlAdminController(IEcoDbContext ecoDbContext)
    {
        _dbContext = ecoDbContext;
    }

    [AllowAnonymous]
    [HttpGet("writeDataFromXL")]
    public async Task<ActionResult> WriteDataToDbFromExcel()
    {
        string path = Directory.GetCurrentDirectory();
            
        path = Directory.GetParent(path).ToString();
        var excelFilePath = $"{path}/data.xlsx";
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 1; row <= rowCount; row++)
            {
                EcoRecord entity = new EcoRecord()
                {
                    RecordId = Guid.NewGuid(),
                    SuspendedSolids = Convert.ToDouble(worksheet.Cells[row, 1].Value),
                    SulfurDioxide = Convert.ToDouble(worksheet.Cells[row, 2].Value),
                    CarbonDioxide = Convert.ToDouble(worksheet.Cells[row, 3].Value),
                    NitrogenDioxide = Convert.ToDouble(worksheet.Cells[row, 4].Value),
                    HydrogenFluoride = Convert.ToDouble(worksheet.Cells[row, 5].Value),
                    Ammonia = Convert.ToDouble(worksheet.Cells[row, 6].Value),
                    Formaldehyde = Convert.ToDouble(worksheet.Cells[row, 7].Value),  
                    CreationDate = DateTime.Now,
                };
                _dbContext.EcoRecords.Add(entity);
            }
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }
        return Ok();
    }

    [HttpGet("writeAbout/{newText}")]
    public async Task<ActionResult<string>> WriteAbout(string newText)
    {
        string fileContents = "null";
        string filePath = @$"{Directory.GetCurrentDirectory()}/about.txt";
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(newText);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error while write to file, in UrlAdminController" + e.Message);
        }
        return fileContents;
    }
}