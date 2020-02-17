using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Elements.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace UGF.Module.Addressable.Runtime
{
    public class AddressableSceneModule : SceneModuleBase, IApplicationModuleAsync
    {
        public AddressableSceneModule(IElementContext context) : base(context)
        {
        }

        public async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;

            Log.Debug($"AddressableSceneModule: runtimePath:'{Addressables.RuntimePath}'.");
        }

        protected override Scene OnLoadScene(string sceneName, SceneLoadParameters parameters)
        {
            throw new NotSupportedException("Addressable does not support immediate scene load.");
        }

        protected override async Task<Scene> OnLoadSceneAsync(string sceneName, SceneLoadParameters parameters)
        {
            SceneInstance instance = await Addressables.LoadSceneAsync(sceneName, parameters.AddMode).Task;

            return instance.Scene;
        }

        protected override void OnUnloadScene(Scene scene, SceneUnloadParameters parameters)
        {
            throw new NotSupportedException("Addressable does not support immediate scene unload.");
        }

        protected override async Task OnUnloadSceneAsync(Scene scene, SceneUnloadParameters parameters)
        {
            SceneInstance instance = AddressableUtility.GetAsSceneInstance(scene);

            await Addressables.UnloadSceneAsync(instance).Task;
        }
    }
}
