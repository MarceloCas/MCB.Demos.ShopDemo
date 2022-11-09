namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Models;

public abstract class PayloadBase
{
    public string ExecutionUser { get; set; }
    public string SourcePlatform { get; set; }
}
