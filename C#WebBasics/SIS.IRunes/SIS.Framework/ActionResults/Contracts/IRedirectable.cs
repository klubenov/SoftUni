using SIS.Framework.ActionResults.Base;

namespace SIS.Framework.ActionResults.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}
