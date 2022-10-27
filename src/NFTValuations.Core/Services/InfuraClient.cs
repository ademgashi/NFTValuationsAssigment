using Microsoft.Extensions.Logging;
using Nethereum.Contracts;
using Nethereum.Web3;
using NFTValuations.Core.Interfaces;

namespace NFTValuations.Core.Services;

public class InfuraClient : IInfuraApi
{

    private readonly Web3 _web3;
    private readonly string _apiToken;
    private readonly string _baseUrl;

    private readonly ILogger<InfuraClient> _logger;

    public InfuraClient(string baseUrl, string apiToken, ILogger<InfuraClient> logger)
    {
        _baseUrl = baseUrl;
        _apiToken = apiToken;
        _logger = logger;
        _web3 = new Web3($"{_baseUrl}{_apiToken}");
    }

    public Contract GetContract(string abi, string contractAddress)
    {
        try
        {
            return _web3.Eth.GetContract(abi, contractAddress);

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }
}