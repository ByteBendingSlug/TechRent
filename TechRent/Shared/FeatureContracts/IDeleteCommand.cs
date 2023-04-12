using System;
using System.Threading.Tasks;

namespace TechRent.Shared.FeatureContracts
{
    public interface IDeleteCommand
    {
        Task Execute(Guid itemID);

        // TODO: Implement cannot delete on rented items. 
        // bool CanExecute(Guid itemID);
    }
}
