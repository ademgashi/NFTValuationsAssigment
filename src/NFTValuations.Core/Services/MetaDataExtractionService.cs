using System.Text;
using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using Newtonsoft.Json;
using NFTValuations.Core.Exceptions;
using NFTValuations.Core.Interfaces;
using NFTValuations.Core.Models;

namespace NFTValuations.Core.Services;

public class MetaDataExtractionService : IExtractNftMetaData
{
    private readonly IInfuraApi _infura;
    private readonly IGetAbi _abiClient;

    private readonly ILogger<MetaDataExtractionService> _logger;
    private readonly Web3 _web3;

    public MetaDataExtractionService(IInfuraApi infura, ILogger<MetaDataExtractionService> logger,
        IGetAbi abiClient, string infuraUrl)
    {
        //_infura = infura;
        _logger = logger;
        _abiClient = abiClient;
        _web3 = new Web3(infuraUrl);
    }


    #region Public Methods

    public async Task<IpfsResponse> GetTokenMeta(Input input)
    {

        try
        {

            _logger.LogTrace("GetTokenMeta");

            string contractAbi = await _abiClient.GetAbi(input.ContractAddress);

            var abiModel = AbiResponse.FromJson(contractAbi);

            _logger.LogDebug($"abiModel {abiModel.Result}");

            var contract = _web3.Eth.GetContract(abiModel.Result, input.ContractAddress);

            //var contract = _web3..GetContract(abiModel.Result, input.ContractAddress);

            var tokenUriFunction = contract.GetFunction("tokenURI");

            var tokenUri = await tokenUriFunction.CallAsync<string>(input.TokenIndeX);

            _logger.LogDebug($"tokenUri {tokenUri}");


            var ipfsUrl = GetIpfsAndParseUri(tokenUri);

            if (string.IsNullOrEmpty(tokenUri) || string.IsNullOrEmpty(ipfsUrl))
            {
                throw new TokeUriIsNullException("Token URI Cant be null");
            }

            _logger.LogTrace("GetTokenMeta");
            
            return await _GetMetaData(ipfsUrl);
            

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message,e);
            throw;
        }
        
    }

    #endregion


    #region Private Methods

    private string GetIpfsAndParseUri(string tokenUri)
    {
        if (IsBase64String(tokenUri))
        {
            _logger.LogDebug("tokenUri IsBase64String");

        }

        Uri uriResult;
        bool result = Uri.TryCreate($"https://ipfs.io/ipfs/{tokenUri.Replace("ipfs://", "")}", UriKind.Absolute,
                          out uriResult)
                      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (result)
        {
            _logger.LogDebug($"Successfully parsed {tokenUri} to {uriResult?.AbsoluteUri} ");
            return uriResult.AbsoluteUri;
        }

        return null;
    }

    private static bool IsBase64String(string base64)
    {
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
    }


    private async Task<IpfsResponse> _GetMetaData(string url)
    {
        try
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return IpfsResponse.FromJson(jsonString);
            }
        }
        catch (HttpRequestException) // Non success
        {
            _logger.LogError("An error occurred.");
        }
        catch (NotSupportedException) // When content type is not valid
        {
            _logger.LogError("The content type is not supported.");
        }
        catch (JsonException) // Invalid JSON
        {
            _logger.LogError("Invalid JSON.");
        }
        return null;
    }
    
    #endregion

}

