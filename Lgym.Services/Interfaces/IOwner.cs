using Lgym.Services.Models;

namespace Lgym.Services.Interfaces
{
    public interface IOwner
    {
        User Owner { get; set; }
    }
}
