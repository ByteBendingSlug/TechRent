using System.Threading.Tasks;
using TechRent.Entities;

namespace TechRent.Shared.FeatureContracts
{
    public interface IUpdateCommand
    {
        Task Execute(Item item);
    }
}
