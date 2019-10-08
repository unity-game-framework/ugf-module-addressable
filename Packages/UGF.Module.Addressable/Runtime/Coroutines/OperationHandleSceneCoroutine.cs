using System;
using System.Collections;
using UGF.Coroutines.Runtime;
using UGF.Module.Scenes.Runtime;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace UGF.Module.Addressable.Runtime.Coroutines
{
    public class OperationHandleSceneCoroutine : Coroutine<Scene>, ISceneLoadCoroutine
    {
        public AsyncOperationHandle<SceneInstance> Handle { get { return m_handle; } }
        public SceneLoadParameters Parameters { get; }
        public bool AllowSceneActivation { get { return Parameters.Activate; } }

        private readonly AsyncOperationHandle<SceneInstance> m_handle;

        public OperationHandleSceneCoroutine(AsyncOperationHandle<SceneInstance> handle, SceneLoadParameters parameters)
        {
            Parameters = parameters;
            m_handle = handle;
        }

        public void ActivateScene()
        {
            if (!IsCompleted) throw new InvalidOperationException("Loading not yet completed.");

            m_handle.Result.Activate();
        }

        protected override IEnumerator Routine()
        {
            while (!m_handle.IsDone)
            {
                yield return null;
            }

            Result = m_handle.Result.Scene;

            if (Parameters.UnloadUnused)
            {
                yield return Resources.UnloadUnusedAssets();
            }
        }
    }
}
