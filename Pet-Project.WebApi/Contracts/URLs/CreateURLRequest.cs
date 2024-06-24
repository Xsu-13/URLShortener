using System.ComponentModel.DataAnnotations;

namespace Pet_Project.WebApi.Contracts.URLs
{
    public record CreateURLRequest
    (
        [Required] string LongURL
    );
}
