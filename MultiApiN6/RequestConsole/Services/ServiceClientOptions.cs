using System.ComponentModel.DataAnnotations;

namespace RequestConsole.Services
{
    internal abstract class ServiceClientOptions
    {
        [Required]
        public virtual string? BaseServiceUrl { get; set; }

        public virtual string? UserName { get; set; }
        public virtual string? Password { get; set; }
    }
}
