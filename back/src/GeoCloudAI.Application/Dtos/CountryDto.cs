using System.ComponentModel.DataAnnotations;

namespace GeoCloudAI.Application.Dtos
{
    public class CountryDto
    {
        //Id
        [ Required(ErrorMessage = "{0} is required") ]
        public int Id { get; set; }

        //Name
        [ Required(ErrorMessage = "{0} is required") ]
        [ MaxLength(60, ErrorMessage = "{0} must have a maximum of 60 characters") ]
        public string? Name { get; set; }

        //Acronym2
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(2, ErrorMessage = "{0} must have at least 2 characters") ]
        [ MaxLength(2, ErrorMessage = "{0} must have a maximum of 2 characters") ]
        public string? Acronym2 { get; set; }

        //Acronym3
        [ Required(ErrorMessage = "{0} is required") ]
        [ MinLength(3, ErrorMessage = "{0} must have at least 3 characters") ]
        [ MaxLength(3, ErrorMessage = "{0} must have a maximum of 3 characters") ]
        public string? Acronym3 { get; set; }
    }
}