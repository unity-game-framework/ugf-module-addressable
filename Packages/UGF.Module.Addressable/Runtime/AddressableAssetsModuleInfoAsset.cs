using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UnityEngine;

namespace UGF.Module.Addressable.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Addressable/AddressableAssetsModuleInfo", order = 2000)]
    public class AddressableAssetsModuleInfoAsset : ApplicationModuleInfoAsset<IAssetsModule>
    {
        protected override IApplicationModule OnBuild(IApplication application)
        {
            return new AddressableAssetsModule();
        }
    }
}
