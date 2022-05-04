using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Acme.IssueManagement.Web.Menus;

public class IssueManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(IssueManagementMenus.Prefix, displayName: "IssueManagement", "~/IssueManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
