using System.ComponentModel.DataAnnotations;

namespace GeoCloudAI.Application.Dtos
{
    public class UserDto
    {
        //Id
        [ Required(ErrorMessage = "{0} is required") ]
        public int Id { get; set; }

        //Profile
        [ Required(ErrorMessage = "{0} is required") ]
        public ProfileDto? Profile { get; set; }

        //FirstName
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? FirstName { get; set; }

        //LastName
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? LastName { get; set; }

        //Phone
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Phone { get; set; }
   
        //Email
        [ Required(ErrorMessage = "{0} is required") ]
        [ MaxLength(60, ErrorMessage = "{0} must have a maximum of 60 characters") ]
        [ EmailAddress(ErrorMessage = "{0} is not valid")]
        public string? Email { get; set; }

        //Password
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(8, ErrorMessage = "{0} must have at least 8 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Password { get; set; }
      
        //Country
        [ Required(ErrorMessage = "{0} is required") ]
        public CountryDto? Country { get; set; }
    
        //State
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(2, ErrorMessage = "{0} must have at least 2 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? State { get; set; }
    
        //City
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? City { get; set; }
    
        //Access
        [ Required(ErrorMessage = "{0} is required") ]
        public DateTime? Access { get; set; }
    
        //Attempts
        [ Required(ErrorMessage = "{0} is required") ]
        public int? Attempts { get; set; }
    
        //Blocked
        [ Required(ErrorMessage = "{0} is required") ]
        public bool? Blocked { get; set; }
    
        //Register
        [ Required(ErrorMessage = "{0} is required") ]
        public DateTime? Register { get; set; }
    }
}