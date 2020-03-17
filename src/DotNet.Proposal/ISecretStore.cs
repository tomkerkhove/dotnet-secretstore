using System.Threading.Tasks;

namespace DotNet.Proposal
{
    public interface ISecretStore
    {
        Task<string> Get(string secretName);
    }
}
