using Newtonsoft.Json;

namespace UserMgmtAPI.Domain.Entities
{
    public class SystemUser
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "saltedpassword")]
        public string SaltedPassword { get; set; }

        //[JsonIgnore]
        //public List<RefreshToken> RefreshTokens { get; set; }
    }
}
