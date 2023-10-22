using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Controllers;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Products.Commands.DeleteProduct;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Controllers;
    
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EcoRecordAuthorizeController : BaseController
{
    private readonly IMapper _mapper;
    public EcoRecordAuthorizeController(IMapper mapper) => _mapper = mapper;

    #region EcoRecords
    [HttpGet("details/{Id}")]
    public async Task<ActionResult<EcoRecordDetailsVm>> GetProductDetails(Guid Id)
    {
        var query = new GetEcoRecordDetailsQuery
        {
            RecordId = Id,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);  
    }
    
    [HttpPost("createEcoRecord")]
    public async Task<ActionResult<CreateEcoRecordCommand>> CreateProduct([FromBody] CreateEcoRecordDto createEcoRecordDto)
    {
        createEcoRecordDto.UserId = UserId;
        var command = _mapper.Map<CreateEcoRecordCommand>(createEcoRecordDto);
        var urlTo = await Mediator.Send(command);
        return Ok(urlTo);
    }
    
    [HttpDelete("deleteEcoRecord/{Id}")]
    public async Task<ActionResult<DeleteEcoRecordCommand>> DeleteEcoRecord(Guid Id)
    {
        var command = new DeleteEcoRecordCommand
        {
            RecordId = Id,
        };
        command.UserId = UserId;
        await Mediator.Send(command);
        return Ok();
    }
    #endregion
}