using System;
using System.Threading.Tasks;
using Wp8Pass.Store.Bootstrap;

namespace Wp8Pass.Store.Services
{
    [Singleton]
    public interface IDatabaseManager
    {
        /// <summary>
        /// Gets all the registered databases.
        /// </summary>
        /// <returns>Hot task that returns all registered databases.</returns>
        Task<DatabaseRegistration[]> GetDatabases();
    }
}