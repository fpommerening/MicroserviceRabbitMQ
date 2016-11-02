using System.Linq;
using System.Threading.Tasks;
using FP.MsRMQ.PicFlow.Contracts.Dbo;
using Marten;

namespace FP.MsRMQ.PicFlow.Authorization
{
    public class UserRepository
    {
        private IDocumentStore _store;
        private readonly string _connectionString;
        private static readonly object SyncRoot = new object();

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDocumentStore Store
        {
            get
            {
                lock (SyncRoot)
                {
                    return _store ?? (_store = DocumentStore.For(_connectionString));
                }
            }
        }

        public async Task<UserInfo> CheckUser(string username, string passwordhash)
        {
            using (var session = Store.OpenSession())
            {
                var existingUser = await session.Query<User>().Where(x => x.UserName == username && x.PasswordHash == passwordhash).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return new UserInfo();
                }
                return new UserInfo
                {
                    Id = existingUser.Id,
                    User = $"{existingUser.FirstName} {existingUser.LastName}",
                    IsValid = true
                };
            }
        }
    }
}
