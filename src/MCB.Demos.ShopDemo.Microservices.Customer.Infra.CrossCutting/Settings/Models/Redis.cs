namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings.Models;

public class Redis
{
    public string ConnectionString { get; set; }

	public Redis()
	{
		ConnectionString= string.Empty;
	}
}
