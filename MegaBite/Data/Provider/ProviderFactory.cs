using MegaBite.Data.Provider.Mock;
using MegaBite.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Data.Provider
{
    public class ProviderFactory
    {
        /// <summary>
        /// Gets the Recipe provider.
        /// </summary>
        /// <param name="providerType">Type of the provider.</param>
        /// <returns></returns>
        public static IRecipeDataProvider GetRecipeProvider(ProviderType providerType)
        {
            IRecipeDataProvider provider = null;

            switch (providerType)
            {

                case ProviderType.CloudBlob:
                    break;
                case ProviderType.CloudTable:
                    break;
                case ProviderType.Entity:
                    break;
                case ProviderType.File:
                    break;
                case ProviderType.Memory:
                    break;
                case ProviderType.Mock:
                    provider = new RecipeMockProvider();
                    break;
                case ProviderType.WebAPI:
                    break;
                case ProviderType.Unknown:
                default:
                    break;
            }

            return provider;
        }
    }
}
