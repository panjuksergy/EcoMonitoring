using System.Data.OleDb;
using OfficeOpenXml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.ShortenerService;

namespace SparkSwim.GoodsService.Controllers;

[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
public class UrlAdminController : BaseController
{
    private readonly IEcoDbContext _dbContext;
    private readonly IMonitoring _monitoring;

    public UrlAdminController(IEcoDbContext ecoDbContext, IMonitoring monitoring)
    {
        _dbContext = ecoDbContext;
        _monitoring = monitoring;
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
                MonitoringSingleStat monitoringSingleStat = new MonitoringSingleStat
                {
                    SuspendedSolidsStat = _monitoring.CalculateNonCancerRiskForSuspendedSolids(entity.SuspendedSolids),
                    SulfurDioxideStat = _monitoring.CalculateNonCancerRiskForSulfurDioxide(entity.SulfurDioxide),
                    CarbonDioxideStat = _monitoring.CalculateNonCancerRiskForCarbonDioxide(entity.CarbonDioxide),
                    NitrogenDioxideStat = _monitoring.CalculateNonCancerRiskForNitrogenDioxide(entity.NitrogenDioxide),
                    HydrogenFluorideStat = _monitoring.CalculateNonCancerRiskForHydrogenFluoride(entity.HydrogenFluoride),
                    AmmoniaStat = _monitoring.CalculateNonCancerRiskForAmmonia(entity.Ammonia),
                    FormaldehydeStat = _monitoring.CalculateNonCancerRiskForFormaldehyde(entity.Formaldehyde),
                };
                double totalNonCancerRisk = _monitoring.CalculateTotalNonCancerRisk(
                    monitoringSingleStat.SulfurDioxideStat, monitoringSingleStat.FormaldehydeStat,
                    monitoringSingleStat.CarbonDioxideStat, monitoringSingleStat.HydrogenFluorideStat,
                    monitoringSingleStat.SuspendedSolidsStat);
                monitoringSingleStat.TotalNonCancerRisk = totalNonCancerRisk;
                entity.MonitoringSingleStat = monitoringSingleStat;
                entity.MonitoringSingleStatId = Guid.NewGuid();
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