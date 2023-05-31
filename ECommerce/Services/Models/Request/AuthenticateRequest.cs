using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Models.Request
{
    public class AuthenticateRequest
    {
        [Required]
        [JsonPropertyName(name: "email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,3}$", ErrorMessage = "Please Enter valid email address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [JsonPropertyName(name: "password")]
        [DataType(DataType.Password)]
        [MaxLength(24, ErrorMessage = "Maximum 24 characters allowed")]
        public string Password { get; set; } = string.Empty;
    }
}
