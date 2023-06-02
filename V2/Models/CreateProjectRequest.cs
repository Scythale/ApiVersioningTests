using System.ComponentModel.DataAnnotations;

namespace ApiVersioningTests.V2.Models
{
    public class CreateProjectRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
