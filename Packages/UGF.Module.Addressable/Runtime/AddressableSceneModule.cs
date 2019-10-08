using System;
using System.Collections;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Addressable.Runtime.Coroutines;
using UGF.Module.Scenes.Runtime;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace UGF.Module.Addressable.Runtime
{
    public class AddressableSceneModule : ApplicationModuleBaseAsync, ISceneModule
    {
        protected override IEnumerator OnInitializeAsync()
        {
            AsyncOperationHandle<IResourceLocator> operation = Addressables.InitializeAsync();

            while (!operation.IsDone)
            {
                yield return null;
            }

            Log.Debug($"AddressableSceneModule initialized: locators:'{Addressables.ResourceLocators.Count}', runtimePath:'{Addressables.RuntimePath}'.");
        }

        public ISceneLoadCoroutine LoadSceneAsync(string sceneName, SceneLoadParameters parameters)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            AsyncOperationHandle<SceneInstance> handler = Addressables.LoadSceneAsync(sceneName, parameters.Mode, parameters.Activate);

            return new OperationHandleSceneCoroutine(handler, parameters);
        }

        public ICoroutine UnloadSceneAsync(Scene scene, SceneUnloadParameters parameters)
        {
            if (!scene.IsValid()) throw new ArgumentException("The specified scene is invalid.", nameof(scene));

            SceneInstance sceneInstance = AddressableUtility.GetAsSceneInstance(scene);
            AsyncOperationHandle<SceneInstance> handler = Addressables.UnloadSceneAsync(sceneInstance);

            return new OperationHandleCoroutine<SceneInstance>(handler);
        }
    }
}
