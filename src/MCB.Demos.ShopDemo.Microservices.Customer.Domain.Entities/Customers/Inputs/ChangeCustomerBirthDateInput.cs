using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record ChangeCustomerBirthDateInput
        : InputBase
    {
        public DateOnly BirthDate { get; }

        public ChangeCustomerBirthDateInput(
            Guid tenantId,
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            BirthDate = birthDate;
        }
    }
}
