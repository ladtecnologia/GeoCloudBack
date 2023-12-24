using System.ComponentModel.DataAnnotations;

namespace GeoCloudAI.Application.Dtos
{
    public class UserDto
    {
        //Id
        [ Required(ErrorMessage = "{0} is required") ]
        public int Id { get; set; }

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

        //Email
        [ Required(ErrorMessage = "{0} is required") ]
        [ MaxLength(60, ErrorMessage = "{0} must have a maximum of 60 characters") ]
        [ EmailAddress(ErrorMessage = "{0} is not valid")]
        public string? Email { get; set; }

        //Company
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Company { get; set; }
    }
}