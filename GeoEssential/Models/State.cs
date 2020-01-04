using Newtonsoft.Json;

namespace GeoEssential.Models
{
    public class State
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("country_id")]
        public string CountryId { get; set; }
    }
}
