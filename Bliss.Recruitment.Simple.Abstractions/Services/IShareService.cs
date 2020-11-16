using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Core.Services
{
    public interface IShareService
    {
        Task ShareByEmail(string to, string body, string subject = null, string from = null);
    }
}