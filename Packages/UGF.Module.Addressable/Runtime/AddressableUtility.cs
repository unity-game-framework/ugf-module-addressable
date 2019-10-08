using System.ComponentModel;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace UGF.Module.Addressable.Runtime
{
    public static class AddressableUtility
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct SceneInstanceConverter
        {
            [FieldOffset(0)] public SceneInstance SceneInstance;
            [FieldOffset(0)] public SceneInstanceInfo SceneInstanceInfo;
        }

        private struct SceneInstanceInfo
        {
            [UsedImplicitly] public Scene Scene;
            [UsedImplicitly] public AsyncOperation AsyncOperation;
        }

        public static SceneInstance GetAsSceneInstance(Scene scene)
        {
            var info = new SceneInstanceInfo { Scene = scene, AsyncOperation = null };
            var converter = new SceneInstanceConverter { SceneInstanceInfo = info };

            return converter.SceneInstance;
        }
    }
}
