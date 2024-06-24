using System.ComponentModel.DataAnnotations;

namespace Pet_Project.WebApi.Contracts.URLs
{
    public record GetURLResponse
    (
        [Required] string LongURL,
        [Required] string ShortURL
    );
}
