
using Newtonsoft.Json;

namespace NFTValuations.Core.Models
{
    public partial class AbiResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }
    }

    public partial class AbiResponse
    {
        public static AbiResponse FromJson(string json) => JsonConvert.DeserializeObject<AbiResponse>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this AbiResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

}
