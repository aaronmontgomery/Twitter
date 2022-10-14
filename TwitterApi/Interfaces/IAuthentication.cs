using System.Threading.Tasks;

namespace TwitterApi
{
    public partial class Interfaces
    {
        internal interface IAuthentication
        {
            Task<Models.TwitterApi.Token> GetTokenAsync();
        }
    }
}
