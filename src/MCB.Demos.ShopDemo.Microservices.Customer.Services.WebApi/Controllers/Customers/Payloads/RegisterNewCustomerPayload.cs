﻿using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Base.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Customers.Payloads;

public class RegisterNewCustomerPayload
    : PayloadBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
}
