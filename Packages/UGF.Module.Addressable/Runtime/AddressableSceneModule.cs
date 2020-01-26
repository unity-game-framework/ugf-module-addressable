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
    public class AddressableSceneModule : ApplicationModuleBase, ISceneModule, IApplicationModuleAsync
    {
        public async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;

            Log.Debug($"AddressableSceneModule: runtimePath:'{Addressables.RuntimePath}'.");
        }

        public void LoadScene(string sceneName, LoadSceneParameters parameters)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            Addressables.LoadSceneAsync(sceneName, parameters.loadSceneMode);
        }

        public async Task<Scene> LoadSceneAsync(string sceneName, LoadSceneParameters parameters)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            SceneInstance instance = await Addressables.LoadSceneAsync(sceneName, parameters.loadSceneMode).Task;

            return instance.Scene;
        }

        public void UnloadScene(Scene scene, UnloadSceneOptions unloadOptions)
        {
            if (!scene.IsValid()) throw new ArgumentException("The specified scene is invalid.", nameof(scene));

            SceneInstance instance = AddressableUtility.GetAsSceneInstance(scene);

            Addressables.UnloadSceneAsync(instance);
        }

        public async Task UnloadSceneAsync(Scene scene, UnloadSceneOptions unloadOptions)
        {
            if (!scene.IsValid()) throw new ArgumentException("The specified scene is invalid.", nameof(scene));

            SceneInstance instance = AddressableUtility.GetAsSceneInstance(scene);

            await Addressables.UnloadSceneAsync(instance).Task;
        }
    }
}
