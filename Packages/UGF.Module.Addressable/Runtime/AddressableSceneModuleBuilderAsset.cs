using UGF.Application.Runtime;
using UGF.Module.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine;

namespace UGF.Module.Addressable.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Addressable/AddressableSceneModuleBuilder", order = 2000)]
    public class AddressableSceneModuleBuilderAsset : ModuleBuilderAsset<ISceneModule>
    {
        protected override IApplicationModule OnBuild(IApplication application, IModuleBuildArguments<object> arguments)
        {
            return new AddressableSceneModule();
        }
    }
}
