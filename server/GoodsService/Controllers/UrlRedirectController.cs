using MediatR;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Controllers;

[ApiController]
public class UrlRedirectController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => 
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    // [HttpGet("sl/{hash}")]
    // public async Task<IActionResult> GetUrlWithoutDetailsById(string hash)
    // {
    //     var query = new GetEcoRecordQuery
    //     {
    //         UrlTo = $"https://localhost:5001/sl/{hash}",
    //     };
    //     var vm = await Mediator.Send(query);
    //     return Redirect(vm.UrlFrom);
    // }
}