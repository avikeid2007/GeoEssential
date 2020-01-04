using Newtonsoft.Json;

namespace GeoEssential.Models
{
    public class Country
    {
        [JsonProperty("id")]
        public string Id { get; set; }
      
        [JsonProperty("sortname")]
        public string SortName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phonecode")]
        public int PhoneCode { get; set; }
    }
}
