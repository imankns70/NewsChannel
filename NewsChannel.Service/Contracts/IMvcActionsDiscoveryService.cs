using System.Collections.Generic;
using NewsChannel.ViewModel.DynamicAccess;

namespace NewsChannel.Service.Contracts
{
    public interface IMvcActionsDiscoveryService
    {
        ICollection<ControllerViewModel> GetAllSecuredControllerActionsWithPolicy(string policyName);
    }
}
