using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceTest.Entities
{
    public class Employee
    {
        [JsonPropertyName("idEmployee")]
        public int IdEmployee { get; set; }
        [JsonPropertyName("firstName"), Required]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName"), Required]
        public string LastName { get; set; }
        [JsonPropertyName("address"), Required]
        public string Address { get; set; }
        [JsonPropertyName("email"), Required]
        public string Email { get; set; }
        [JsonPropertyName("phoneNumber"), Required]
        public string PhoneNumber { get; set; }
    }
}
