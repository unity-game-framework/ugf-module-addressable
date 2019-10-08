using UnityEditor.AddressableAssets.Settings;

namespace UGF.Module.Addressable.Editor.Scheme
{
    /// <summary>
    /// Represents abstract base class to implement asset group scheme that determines whether to include specific asset group in build.
    /// </summary>
    public abstract class IncludeGroupSchemeBase : AddressableAssetGroupSchema
    {
        /// <summary>
        /// Checks condition of this scheme.
        /// </summary>
        public abstract bool Check();
    }
}
