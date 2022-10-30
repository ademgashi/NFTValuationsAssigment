using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using NFTValuations.Core.Interfaces;
using NFTValuations.Core.Services;
using Moralis;
using Moralis.Web3Api.Models;

public static class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();
    }

    public static void ConfigureContainer(ServiceRegistry services, IConfiguration configuration)
    {
        string apiToken = configuration["Infura:ApiKey"];
        string baseUrl = configuration["Infura:BaseUrl"];
        string moralisApiKey = configuration["MoralisClient:ApiKey"];

        services.AddSingleton(_ => new Web3($"{baseUrl}{apiToken}"));

        services.AddHttpClient();
        
        services.For<IExtractNftMetaData>()
            .Use<MetaDataExtractionService>().Ctor<string>("moralisApiKey").Is(moralisApiKey)
            .Singleton();


    }
}