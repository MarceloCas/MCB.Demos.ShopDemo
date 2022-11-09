using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;

public interface IUseCase<in TUseCaseInput>
    where TUseCaseInput : UseCaseInputBase
{
    Task<bool> ExecuteAsync(TUseCaseInput useCaseInput, CancellationToken cancellationToken); 
}