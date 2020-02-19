using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace UGF.Module.Addressable.Runtime
{
    public class AddressableSceneModule : SceneModuleBase, IApplicationModuleAsync
    {
        public async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;

            Log.Debug($"AddressableSceneModule: runtimePath:'{Addressables.RuntimePath}'.");
        }

        protected override Scene OnLoad(string sceneName, SceneLoadParameters parameters)
        {
            throw new NotSupportedException("Addressable does not support immediate scene load.");
        }

        protected override async Task<Scene> OnLoadAsync(string sceneName, SceneLoadParameters parameters)
        {
            SceneInstance instance = await Addressables.LoadSceneAsync(sceneName, parameters.AddMode).Task;

            return instance.Scene;
        }

        protected override void OnUnload(Scene scene, SceneUnloadParameters parameters)
        {
            throw new NotSupportedException("Addressable does not support immediate scene unload.");
        }

        protected override async Task OnUnloadAsync(Scene scene, SceneUnloadParameters parameters)
        {
            SceneInstance instance = AddressableUtility.GetAsSceneInstance(scene);

            await Addressables.UnloadSceneAsync(instance).Task;
        }
    }
}
