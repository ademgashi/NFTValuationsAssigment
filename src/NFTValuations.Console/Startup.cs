using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFTValuations.Core.Interfaces;
using NFTValuations.Core.Services;

public static class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging();
    }

    public static void ConfigureContainer(ServiceRegistry services, IConfiguration configuration)
    {
        string apiToken = configuration["Infura:ApiKey"];
        string baseUrl = configuration["Infura:BaseUrl"];

        string apiKeyAbi = configuration["AbiClient:ApiKey"];
        string apiEtherScanKey = configuration["EtherScan:ApiKey"];

        
        services.For<IInfuraApi>()
            .Use<InfuraClient>()
            .Ctor<string>("baseUrl").Is(baseUrl)
            .Ctor<string>("apiToken").Is(apiToken)
            .Singleton();

        services.For<IGetAbi>()
            .Use<AbiClient>()
            .Ctor<string>("apiKey").Is(apiEtherScanKey)
            .Singleton();


        services.For<IExtractNftMetaData>()
            .Use<MetaDataExtractionService>()
            .Ctor<string>("infuraUrl").Is($"{baseUrl}{apiToken}")
            .Singleton();


    }
}