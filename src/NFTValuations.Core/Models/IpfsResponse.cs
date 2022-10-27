using Newtonsoft.Json;
using NFTValuations.Core.Models;



namespace NFTValuations.Core.Models
{
    public partial class IpfsResponse
    {
        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("attributes")] public List<Attribute> Attributes { get; set; }
    }

    public partial class Attribute
    {
        [JsonProperty("trait_type")] public string TraitType { get; set; }

        [JsonProperty("value")] public string Value { get; set; }
    }

    public partial class IpfsResponse
    {
        public static IpfsResponse? FromJson(string json) =>
            JsonConvert.DeserializeObject<IpfsResponse>(json, Converter.Settings);
    }

}