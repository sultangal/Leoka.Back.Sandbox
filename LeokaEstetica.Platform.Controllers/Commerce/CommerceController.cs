using AutoMapper;
using LeokaEstetica.Platform.Base;
using LeokaEstetica.Platform.Core.Filters;
using LeokaEstetica.Platform.Models.Dto.Input.Commerce.PayMaster;
using LeokaEstetica.Platform.Models.Dto.Output.Commerce.PayMaster;
using LeokaEstetica.Platform.Processing.Abstractions.PayMaster;
using Microsoft.AspNetCore.Mvc;

namespace LeokaEstetica.Platform.Controllers.Commerce;

/// <summary>
/// Контроллер работы с коммерцией (платежной системой, платежами, чеками и т.д).
/// </summary>
[AuthFilter]
[ApiController]
[Route("commercial")]
public class CommerceController : BaseController
{
    private readonly IPayMasterService _payMasterService;
    private readonly IMapper _mapper;
    
    /// <inheritdoc />
    public CommerceController(IPayMasterService payMasterService, 
        IMapper mapper)
    {
        _payMasterService = payMasterService;
        _mapper = mapper;
    }

    /// <summary>
    /// Метод создает заказ.
    /// </summary>
    /// <param name="createOrderInput">Входная модель.</param>
    /// <returns>Данные платежа.</returns>
    [HttpPost]
    [Route("payments")]
    [ProducesResponseType(200, Type = typeof(CreateOrderOutput))]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]
    [ProducesResponseType(404)]
    public async Task<CreateOrderOutput> CreateOrderAsync([FromBody] CreateOrderInput createOrderInput)
    {
        var order = await _payMasterService.CreateOrderAsync(createOrderInput, GetUserName());
        var result = _mapper.Map<CreateOrderOutput>(order);

        return result;
    }
}