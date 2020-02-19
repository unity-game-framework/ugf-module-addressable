using UGF.Application.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine;

namespace UGF.Module.Addressable.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Addressable/AddressableSceneModuleInfo", order = 2000)]
    public class AddressableSceneModuleInfoAsset : ApplicationModuleInfoAsset<ISceneModule>
    {
        protected override IApplicationModule OnBuild(IApplication application)
        {
            return new AddressableSceneModule();
        }
    }
}
