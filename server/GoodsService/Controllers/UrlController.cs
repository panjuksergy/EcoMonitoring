using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Controllers;

[AllowAnonymous]
public class UrlController : BaseController
{
    [HttpPost("getAllEcoRecords")]
    public async Task<ActionResult<EcoRecordsListVm>> GetAllProducts([FromBody] GetEcoRecordsListQuery request)
    {
        var query = new GetEcoRecordsListQuery
        {
            // NumberFromToSkip = request.NumberFromToSkip,
            // CountToGet = request.CountToGet,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("getAbout")]
    public async Task<ActionResult<string>> GetAbout()
    {
        string fileContents = "null";
        string filePath = @$"{Directory.GetCurrentDirectory()}/about.txt";
        try
        {
            {
            using (StreamReader reader = new StreamReader(filePath))
                fileContents = reader.ReadToEnd();
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error reading file in UrlAdminController" + e.Message);
        }
        

        return Ok(new
        {
            data = fileContents
        });
    }
}