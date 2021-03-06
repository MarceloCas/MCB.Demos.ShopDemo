using FluentValidation;
using MCB.Core.Domain.Entities.Abstractions.Specifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications.Interfaces
{
    public interface ICustomerAddressSpecifications
        : IDomainEntitySpecifications
    {
        // CustomerAddressType
        public static readonly string CustomerAddressShouldHaveCustomerAddressTypeErrorCode = nameof(CustomerAddressShouldHaveCustomerAddressTypeErrorCode);
        public static readonly string CustomerAddressShouldHaveCustomerAddressTypeMessage = nameof(CustomerAddressShouldHaveCustomerAddressTypeMessage);
        public static readonly Severity CustomerAddressShouldHaveCustomerAddressTypeSeverity = Severity.Error;

        // AddressValueObject
        public static readonly string CustomerAddressShouldHaveAddressValueObjectErrorCode = nameof(CustomerAddressShouldHaveAddressValueObjectErrorCode);
        public static readonly string CustomerAddressShouldHaveAddressValueObjectMessage = nameof(CustomerAddressShouldHaveAddressValueObjectMessage);
        public static readonly Severity CustomerAddressShouldHaveAddressValueObjectSeverity = Severity.Error;

        // Public Methods
        bool CustomerAddressShouldHaveCustomerAddressType(CustomerAddressType customerAddressType);
        bool CustomerAddressShouldHaveAddressValueObject(AddressValueObject addressValueObject);
    }
}
