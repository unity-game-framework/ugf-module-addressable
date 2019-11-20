using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Assets.Runtime;
using UnityEngine.AddressableAssets;

namespace UGF.Module.Addressable.Runtime
{
    public class AddressableAssetsModule : ApplicationModuleBaseAsync, IAssetsModule
    {
        public override async Task InitializeAsync()
        {
            await Addressables.InitializeAsync().Task;

            Log.Debug($"AddressableSceneModule: runtimePath:'{Addressables.RuntimePath}'.");
        }

        public T Load<T>(string assetName)
        {
            throw new NotSupportedException("Loading assets synchronously not supported by Addressables.");
        }

        public object Load(string assetName, Type assetType)
        {
            throw new NotSupportedException("Loading assets synchronously not supported by Addressables.");
        }

        public async Task<T> LoadAsync<T>(string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            return await Addressables.LoadAssetAsync<T>(assetName).Task;
        }

        public async Task<object> LoadAsync(string assetName, Type assetType)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));
            if (assetType == null) throw new ArgumentNullException(nameof(assetType));

            return await Addressables.LoadAssetAsync<object>(assetName).Task;
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
