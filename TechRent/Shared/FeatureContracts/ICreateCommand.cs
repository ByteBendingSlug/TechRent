using System.Threading.Tasks;
using TechRent.Entities;

namespace TechRent.Shared.FeatureContracts
{
    public interface ICreateCommand
    {
        Task Execute(Item item);
    }
}
