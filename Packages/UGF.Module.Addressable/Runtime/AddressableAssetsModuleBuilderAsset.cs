using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Runtime;
using UnityEngine;

namespace UGF.Module.Addressable.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Addressable/AddressableAssetsModuleBuilder", order = 2000)]
    public class AddressableAssetsModuleBuilderAsset : ModuleBuilderAsset<IAssetsModule>
    {
        protected override IApplicationModule OnBuild(IApplication application, IModuleBuildArguments<object> arguments)
        {
            return new AddressableAssetsModule();
        }
    }
}
