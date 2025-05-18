using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using ShoppingLists.Core;

namespace ShoppingLists.Data;

public static class TypeRegistrations
{
    private const string StorageAccountName = "mftwebdevuks";
    
    public static void AddAzureShoppingListRepositorys(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddAzureClients(x =>
        {
            x.AddBlobServiceClient(new Uri($"https://{StorageAccountName}.blob.core.windows.net"));
            x.UseCredential(new DefaultAzureCredential());
        });
        servicesCollection.AddTransient< IShoppingListRepository, AzureBlobShoppingListRepository>();
        // servicesCollection.AddTransient<IFoodDiaryRepository, AzureBlobFoodDiaryRepository>();
    }
    
}