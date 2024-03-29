﻿using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Repositories.Base;

public abstract class RepositoryBase
{
    // Properties
    protected IAdapter Adapter { get; }

    // Conscctuctors
    protected RepositoryBase(
        IAdapter adapter
    )
    {
        Adapter = adapter;
    }
}
