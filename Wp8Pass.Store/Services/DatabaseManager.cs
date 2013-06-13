using System;
using System.Threading.Tasks;

namespace Wp8Pass.Store.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        public Task<DatabaseRegistration[]> GetDatabases()
        {
            return Task.Run(() => new[]
            {
                new DatabaseRegistration
                {
                    Name = "Passwords",
                    Path = @"d:\Van\Dropbox\Passwords.kdbx",
                }
            });
        }
    }
}