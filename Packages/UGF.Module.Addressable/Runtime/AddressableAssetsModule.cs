using System;
using System.Collections;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Addressable.Runtime.Coroutines;
using UGF.Module.Assets.Runtime;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UGF.Module.Addressable.Runtime
{
    public class AddressableAssetsModule : ApplicationModuleBaseAsync, IAssetsModule
    {
        protected override IEnumerator OnInitializeAsync()
        {
            AsyncOperationHandle<IResourceLocator> operation = Addressables.InitializeAsync();

            while (!operation.IsDone)
            {
                yield return null;
            }

            Log.Debug($"AddressableAssetsModule initialized: locators:'{Addressables.ResourceLocators.Count}', runtimePath:'{Addressables.RuntimePath}'.");
        }

        public ICoroutine<T> LoadAsync<T>(string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            AsyncOperationHandle<T> handler = Addressables.LoadAssetAsync<T>(assetName);

            return new OperationHandleCoroutine<T>(handler);
        }

        public ICoroutine<object> LoadAsync(string assetName, Type assetType)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));
            if (assetType == null) throw new ArgumentNullException(nameof(assetType));

            AsyncOperationHandle<object> handler = Addressables.LoadAssetAsync<object>(assetName);

            return new OperationHandleCoroutine<object>(handler);
        }

        public void Release<T>(T asset)
        {
            Addressables.Release(asset);
        }

        public void Release(object asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            Addressables.Release(asset);
        }
    }
}
