using UGF.Application.Runtime;
using UGF.Module.Elements.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine;

namespace UGF.Module.Addressable.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Addressable/AddressableSceneModuleInfo", order = 2000)]
    public class AddressableSceneModuleInfoAsset : ApplicationModuleInfoAsset<ISceneModule>
    {
        protected override IApplicationModule OnBuild(IApplication application)
        {
            var elementModule = application.GetModule<IElementModule>();

            return new AddressableSceneModule(elementModule.Context);
        }
    }
}
