using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Customers.Payloads;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Customers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Customers;

[Route("api/Tenants/{tenantId}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class CustomersController
    : CustomControllerBase
{
    // Fields
    private readonly IRegisterNewCustomerUseCase _registerNewCustomerUseCase;

    // Constructors
    public CustomersController(
        IRegisterNewCustomerUseCase registerNewCustomerUseCase
    )
    {
        _registerNewCustomerUseCase = registerNewCustomerUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterNewCustomerResponse))]
    public async Task<IActionResult> RegisterNewCustomerAsync(
        [FromRoute] Guid tenantId,
        [FromBody]RegisterNewCustomerPayload payload, 
        CancellationToken cancellationToken
    )
    {
        await Task.Delay(1);
        return Ok();
    }
}
