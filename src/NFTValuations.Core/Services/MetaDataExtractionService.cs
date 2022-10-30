using Microsoft.Extensions.Logging;
using Moralis;
using Moralis.Web3Api.Models;
using NFTValuations.Core.Interfaces;
using NFTValuations.Core.Models;


namespace NFTValuations.Core.Services;

public class MetaDataExtractionService : IExtractNftMetaData
{
    private readonly ILogger<MetaDataExtractionService> _logger;

    public MetaDataExtractionService(ILogger<MetaDataExtractionService> logger,
         string moralisApiKey)
    {
        _logger = logger;

        // Setup Moralis
        MoralisClient.ConnectionData = new Moralis.Models.ServerConnectionData()
        {
            ApiKey = moralisApiKey
        };

    }

    #region Public Methods


    public async Task<OutputResponse?> GetTokenMeta(Token input)
    {
        try
        {

            _logger.LogInformation($"GetTokenMeta Address: {input.ContractAddress} Token:{input.TokenIndeX}");

            Nft resp = await MoralisClient.Web3Api.Token.GetTokenIdMetadata(input.ContractAddress, input.TokenIndeX.ToString(), ChainList.eth);

            string tokenUri = resp.TokenUri;

            _logger.LogInformation($"tokenUri {tokenUri}");

            var output = new OutputResponse
            {
                Name = resp.Name
            };

            if (resp.Metadata != null)
            {
                var metaData = IpfsResponse.FromJson(resp.Metadata);
                output = metaData?.ToOutputResponse(metaData);
            }

            if (string.IsNullOrEmpty(tokenUri) || tokenUri.ToLower() == "invalid uri")
            {
                _logger.LogInformation($"{input.ContractAddress} Token:{input.TokenIndeX} has Invalid Uri");

            }

            if (tokenUri.Contains("data:text/plain;charset=utf-8"))
            {
                _logger.LogWarning("tokenUri unknown protocol");

            }

            return output;


        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }

    }




    #endregion
}

