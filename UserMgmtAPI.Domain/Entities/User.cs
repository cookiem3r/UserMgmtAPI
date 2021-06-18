using Newtonsoft.Json;

namespace UserMgmtAPI.Domain.Entities
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        //[JsonIgnore]
        //public List<RefreshToken> RefreshTokens { get; set; }
    }
}
