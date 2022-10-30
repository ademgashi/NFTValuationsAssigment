using Newtonsoft.Json;

namespace NFTValuations.Core.Models
{
    public partial class OutputResponse
    {
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("ExternalUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalUrl { get; set; }

        [JsonProperty("Media", NullValueHandling = NullValueHandling.Ignore)]
        public string Media { get; set; }

        [JsonProperty("Properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        [JsonProperty("Property", NullValueHandling = NullValueHandling.Ignore)]
        public string PropertyProperty { get; set; }
    }

    public partial class OutputResponse
    {
        public static OutputResponse FromJson(string json) => JsonConvert.DeserializeObject<OutputResponse>(json, Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this OutputResponse? self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    

}
