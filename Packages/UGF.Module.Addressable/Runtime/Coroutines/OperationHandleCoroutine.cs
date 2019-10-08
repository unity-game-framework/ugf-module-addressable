using System.Collections;
using UGF.Coroutines.Runtime;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UGF.Module.Addressable.Runtime.Coroutines
{
    public class OperationHandleCoroutine<TObject> : Coroutine<TObject>
    {
        public AsyncOperationHandle<TObject> Handle { get { return m_handle; } }

        private readonly AsyncOperationHandle<TObject> m_handle;

        public OperationHandleCoroutine(AsyncOperationHandle<TObject> handle)
        {
            m_handle = handle;
        }

        protected override IEnumerator Routine()
        {
            while (!m_handle.IsDone)
            {
                yield return null;
            }

            Result = m_handle.Result;
        }
    }
}
