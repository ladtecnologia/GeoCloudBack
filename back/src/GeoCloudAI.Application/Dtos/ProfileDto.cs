using System.ComponentModel.DataAnnotations;
using GeoCloudAI.Domain.Classes;

namespace GeoCloudAI.Application.Dtos
{
    public class ProfileDto
    {
        //Id
        [ Required(ErrorMessage = "{0} is required") ]
        public int Id { get; set; }

        //Account
        [ Required(ErrorMessage = "{0} is required") ]
        public Account? Account { get; set; }

        //Name
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(4, ErrorMessage = "{0} must have at least 4 characters") ]
        [ MaxLength(40, ErrorMessage = "{0} must have a maximum of 40 characters") ]
        public string? Name { get; set; }
    }
}