using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Acme.IssueManagement.Pages;

public class IndexModel : IssueManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
