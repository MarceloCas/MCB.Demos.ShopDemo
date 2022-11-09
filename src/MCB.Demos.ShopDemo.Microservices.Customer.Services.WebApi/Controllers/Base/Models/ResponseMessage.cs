using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Enums;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Models;

public struct ResponseMessage
{
    public ResponseMessageType Type { get; }
    public string Code { get; }
    public string Description { get; }

    public ResponseMessage(
        ResponseMessageType type,
        string code,
        string description
    )
    {
        Type = type;
        Code = code;
        Description = description;
    }
}
