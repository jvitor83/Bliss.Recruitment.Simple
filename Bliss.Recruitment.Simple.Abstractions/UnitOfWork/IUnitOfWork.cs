using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}