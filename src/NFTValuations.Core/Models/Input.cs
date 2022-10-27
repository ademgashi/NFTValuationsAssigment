
namespace NFTValuations.Core.Models
{
    using Newtonsoft.Json;

    public partial class Input
    {
        [JsonProperty("tokenId")]
        public long TokenId { get; set; }

        [JsonProperty("TokenIndeX")]
        public long TokenIndeX { get; set; }


        [JsonProperty("ContractAddress")]
        public string ContractAddress { get; set; }
    }

    public partial class Input
    {
        public static Input FromJson(string json) => JsonConvert.DeserializeObject<Input>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this Input self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}