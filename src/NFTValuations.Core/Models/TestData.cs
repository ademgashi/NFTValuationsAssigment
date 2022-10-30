using Newtonsoft.Json;

namespace NFTValuations.Core.Models
{
   
    public partial class TestData
    {
        [JsonProperty("tokenData", NullValueHandling = NullValueHandling.Ignore)]
        public List<Token> TokenData { get; set; }
    }

    public partial class Token
    {
        [JsonProperty("TokenIndeX", NullValueHandling = NullValueHandling.Ignore)]
        public long? TokenIndeX { get; set; }

        [JsonProperty("ContractAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string ContractAddress { get; set; }
    }

    public partial class TestData
    {
        public static TestData FromJson(string json) => JsonConvert.DeserializeObject<TestData>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this TestData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    
}
