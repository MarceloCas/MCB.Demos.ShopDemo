using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Enums;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Models;

public abstract class ResponseBase
{
    public string ExecutionUser { get; set; }
    public string SourcePlatform { get; set; }
    public ExecutionStatus ExecutionStatus { get; set; }
    public IEnumerable<ResponseMessage> ResponseMessageCollection { get; set; }
}
public abstract class ResponseBase<TData>
    : ResponseBase
{
    public TData Data { get; set; }
}
