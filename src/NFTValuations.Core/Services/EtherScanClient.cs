using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NFTValuations.Core.Interfaces;

namespace NFTValuations.Core.Services;

public class AbiClient : IGetAbi
{
    private readonly string _apiKey;
    private readonly ILogger<AbiClient> _logger;
    public AbiClient(string apiKey, ILogger<AbiClient> logger)
    {
        _apiKey = apiKey;
        _logger = logger;
    }


    //https://api-testnet.bscscan.com/api.
    //? module=contract.
    //&action=getabi.
    //&address=0xADFb5176A09D894BeeB952e8E258272BDCdb8590.
    //&apikey=YourApiKeyToken.

    public async Task<string> GetAbi(string contractAddress)
    {
        _logger.LogTrace("GetAbi");


        try
        {

            string url = $"https://api.etherscan.io/api?module=contract&action=getabi&address={contractAddress}&apikey={_apiKey}";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    string contractABIstr = sr.ReadToEnd();
                    JObject contractABI = JObject.Parse(contractABIstr);
                    if (contractABI.SelectToken("status").ToString() == "0")
                    {
                        // Handle error...
                    }
                    //string contractResults = (string)contractABI.SelectToken("result");
                    return contractABIstr;


                }
            }


            //for some odd reason this code stopped working so I had to use webrequest one.
            //var client = new HttpClient();
            //using (client)
            //{
            //    var abiResponse = await client.GetAsync(
            //        $"https://api.etherscan.io/api?module=contract&action=getabi&address={contractAddress}&apikey={_apiKey}");
                
            //    _logger.LogTrace("End GetAbi");

            //    return await abiResponse.Content.ReadAsStringAsync();
            //}

        }
        catch (Exception e)
        {
            _logger.LogError(e.Message,e);
            throw;
        }
        
        
    }
}