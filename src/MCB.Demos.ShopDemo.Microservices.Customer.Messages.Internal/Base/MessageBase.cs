﻿namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.Base;

public abstract record MessageBase
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public DateTime Timestamp { get; set; }
    public string ExecutionUser { get; set; }
    public string SourcePlatform { get; set; }

    public MessageBase()
    {
        ExecutionUser = string.Empty;
        SourcePlatform = string.Empty;
    }
}