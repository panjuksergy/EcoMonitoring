using System.Data.OleDb;
using System.Globalization;
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
    private readonly IMonitoringService _monitoringService;

    public UrlAdminController(IEcoDbContext ecoDbContext, IMonitoringService monitoringService)
    {
        _dbContext = ecoDbContext;
        _monitoringService = monitoringService;
    }

    [HttpGet("writeDataFromXL")]
    public async Task<ActionResult> WriteDataToDbFromExcel()
    {
        // Отримуємо всі записи з таблиці EcoRecord
        var allRecords = _dbContext.EcoRecords.ToList();

        // Видаляємо всі записи
        _dbContext.EcoRecords.RemoveRange(allRecords);

        // Зберігаємо зміни в базі даних
        _dbContext.SaveChangesAsync(CancellationToken.None);
        
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
                };
                
                double excelDate = (double)worksheet.Cells[row, 8].Value;
                DateTime dateTime = DateTime.FromOADate(excelDate); 
                entity.CreationDate = dateTime;
                
                MonitoringSingleStat monitoringSingleStat = new MonitoringSingleStat
                {
                    SuspendedSolidsStat = _monitoringService.CalculateNonCancerRiskForSuspendedSolids(entity.SuspendedSolids),
                    SulfurDioxideStat = _monitoringService.CalculateNonCancerRiskForSulfurDioxide(entity.SulfurDioxide),
                    CarbonDioxideStat = _monitoringService.CalculateNonCancerRiskForCarbonDioxide(entity.CarbonDioxide),
                    NitrogenDioxideStat = _monitoringService.CalculateNonCancerRiskForNitrogenDioxide(entity.NitrogenDioxide),
                    HydrogenFluorideStat = _monitoringService.CalculateNonCancerRiskForHydrogenFluoride(entity.HydrogenFluoride),
                    AmmoniaStat = _monitoringService.CalculateNonCancerRiskForAmmonia(entity.Ammonia),
                    FormaldehydeStat = _monitoringService.CalculateNonCancerRiskForFormaldehyde(entity.Formaldehyde),
                    
                    SuspendedSolidsCancerStat = _monitoringService.CalculateCSFForSuspendedSolids(entity.SuspendedSolids),
                    SulfurDioxideCancerStat = _monitoringService.CalculateCSFForSulfurDioxide(entity.SulfurDioxide),
                    CarbonDioxideCancerStat = _monitoringService.CalculateCSFForCarbonDioxide(entity.CarbonDioxide),
                    NitrogenDioxideCancerStat = _monitoringService.CalculateCSFForNitrogenDioxide(entity.NitrogenDioxide),
                    HydrogenFluorideCancerStat = _monitoringService.CalculateCSFForHydrogenFluoride(entity.HydrogenFluoride),
                    AmmoniaCancerStat = _monitoringService.CalculateCSFForAmmonia(entity.Ammonia),
                    FormaldehydeCancerStat = _monitoringService.CalculateCSFForFormaldehyde(entity.Formaldehyde),
                };
                
                double totalNonCancerRisk = _monitoringService.CalculateTotalNonCancerRisk(
                    monitoringSingleStat.SulfurDioxideStat, monitoringSingleStat.FormaldehydeStat,
                    monitoringSingleStat.CarbonDioxideStat, monitoringSingleStat.HydrogenFluorideStat,
                    monitoringSingleStat.SuspendedSolidsStat);

                double totalCancerRisk = _monitoringService.CalculateTotalCancerRisk(
                    monitoringSingleStat.SulfurDioxideCancerStat, monitoringSingleStat.FormaldehydeCancerStat,
                    monitoringSingleStat.HydrogenFluorideCancerStat, monitoringSingleStat.CarbonDioxideCancerStat,
                    monitoringSingleStat.SuspendedSolidsCancerStat, monitoringSingleStat.NitrogenDioxideCancerStat,
                    monitoringSingleStat.AmmoniaCancerStat);
                
                monitoringSingleStat.TotalNonCancerRisk = totalNonCancerRisk;
                monitoringSingleStat.TotalCancerRisk = totalCancerRisk;
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