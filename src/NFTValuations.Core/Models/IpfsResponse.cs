using Newtonsoft.Json;
using Newtonsoft.Json;



namespace NFTValuations.Core.Models
{
    public partial class IpfsResponse
    {
        [JsonProperty("image")] public string Image { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("attributes")] public List<Attribute> Attributes { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("animation_url")] public string AnimationUrl { get; set; }

      
        public OutputResponse ToOutputResponse(IpfsResponse item)
        {
            var output = new OutputResponse
            {
                Description = item?.Description,
                ExternalUrl = item?.AnimationUrl,
                Media = item?.Image,
                Name = item?.Name,
                Properties = new List<Property>()

            };

            if (item.Attributes != null)
                foreach (var prop in item?.Attributes)
                {
                    output.Properties.Add(new Property()
                    {
                        Category = prop.TraitType,
                        PropertyProperty = prop.Value
                    });
                }

            return output;
        }


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