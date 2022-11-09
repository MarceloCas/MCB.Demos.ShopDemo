namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;

public abstract record UseCaseInputBase
{
    // Properties
    public Guid TenantId { get; set; }
    public string? ExecutionUser { get; set; }
    public string? SourcePlatform { get; set; }
}