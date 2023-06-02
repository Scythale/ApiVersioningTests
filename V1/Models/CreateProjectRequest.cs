using System.ComponentModel.DataAnnotations;

namespace ApiVersioningTests.V1.Models
{
    public class CreateProjectRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
