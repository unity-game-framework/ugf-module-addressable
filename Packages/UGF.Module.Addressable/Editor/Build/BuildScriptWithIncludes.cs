using System;
using UGF.Module.Addressable.Editor.Scheme;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace UGF.Module.Addressable.Editor.Build
{
    /// <summary>
    /// Represents extended '<see cref="BuildScriptPackedMode"/>' to additionally check '<see cref="IncludeGroupSchemeBase"/>' schemes,
    /// to determine whether to include specific asset group in build.
    /// </summary>
    /// <remarks>
    /// If an asset group contains more than one '<see cref="IncludeGroupSchemeBase"/>',
    /// than all must to pass condition check, to make this asset group to be included in build.
    /// </remarks>
    [CreateAssetMenu(fileName = "BuildScriptWithIncludes.asset", menuName = "Addressable Assets/Data Builders/Packed Mode Includes")]
    public class BuildScriptWithIncludes : BuildScriptPackedMode
    {
        public override string Name { get; } = "Packed Mode Includes";

        protected override string ProcessGroup(AddressableAssetGroup assetGroup, AddressableAssetsBuildContext aaContext)
        {
            bool include = Check(assetGroup);

            return include ? base.ProcessGroup(assetGroup, aaContext) : string.Empty;
        }

        /// <summary>
        /// Checks the specified asset group, whether to include it in build.
        /// </summary>
        /// <param name="assetGroup">The asset group to check.</param>
        protected virtual bool Check(AddressableAssetGroup assetGroup)
        {
            if (assetGroup == null) throw new ArgumentNullException(nameof(assetGroup));

            for (int i = 0; i < assetGroup.Schemas.Count; i++)
            {
                if (assetGroup.Schemas[i] is IncludeGroupSchemeBase scheme)
                {
                    if (!scheme.Check())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
