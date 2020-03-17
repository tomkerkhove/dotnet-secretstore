using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DotNet.Proposal.Extensions
{
    public static class IHostBuilderExtensions
    {
        // Just to compile sample, actually doesn't work
        public static IHostBuilder ConfigureSecretStore(this IHostBuilder hostBuilder, Action<WebHostBuilderContext, IConfiguration, ISecretStoreBuilder> configureDelegate)
        {
            return hostBuilder;
        }
    }
    public static class ISecretStoreBuilderExtensions
    {
        // Just to compile sample, actually doesn't work
        public static ISecretStoreBuilder AddAzureKeyVault(this ISecretStoreBuilder hostBuilder, string vaultName)
        {
            return hostBuilder;
        }
    }

    // Just to compile sample, actually doesn't work
    public interface ISecretStoreBuilder
    {
        /// <summary>
        /// Gets the sources used to obtain secrets values
        /// </summary>
        IList<ISecretStore> Sources { get; }

        /// <summary>
        /// Adds a new configuration source.
        /// </summary>
        /// <param name="source">The configuration source to add.</param>
        /// <returns>The same <see cref="IConfigurationBuilder"/>.</returns>
        ISecretStoreBuilder Add(IConfigurationSource source);
    }
}
