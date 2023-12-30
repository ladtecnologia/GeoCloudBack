using System.ComponentModel.DataAnnotations;

namespace GeoCloudAI.Application.Dtos
{
    public class AccountDto
    {
        //Id
        [ Required(ErrorMessage = "{0} is required") ]
        public int Id { get; set; }

        //Name
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Name { get; set; }

        //Company
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Company { get; set; }

        //AcessMaxAttempts
        [ Required(ErrorMessage = "{0} is required") ]
        [ Range(2, 10, ErrorMessage = "{0} must have a value between 2 and 10")]
        public int? AcessMaxAttempts { get; set; }

        //ValidityUserPassword
        [ Required(ErrorMessage = "{0} is required") ]
        [ Range(10, 90, ErrorMessage = "{0} must have a value between 10 and 90")]
        public int? ValidityUserPassword { get; set; }

        //ValidInviteUser
        [ Required(ErrorMessage = "{0} is required") ]
        [ Range(2, 30, ErrorMessage = "{0} must have a value between 2 and 30")]
        public int? ValidInviteUser { get; set; }

        //ValidInviteProject
        [ Required(ErrorMessage = "{0} is required") ]
        [ Range(2, 30, ErrorMessage = "{0} must have a value between 2 and 30")]
        public int? ValidInviteProject { get; set; }
    }
}