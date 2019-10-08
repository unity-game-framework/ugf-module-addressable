using JetBrains.Annotations;
using UGF.CustomSettings.Editor;
using UGF.Module.Addressable.Editor.Scheme;
using UnityEditor;

namespace UGF.Module.Addressable.Editor.Settings
{
    /// <summary>
    /// Represents editor settings for Addressable.
    /// </summary>
    public static class AddressableEditorSettings
    {
        /// <summary>
        /// Gets or sets value that determines whether to include asset groups with '<see cref="IncludeWithTestsGroupScheme"/>' scheme.
        /// </summary>
        /// <remarks>
        /// This property determines whether to include 'AddressableAssetGroup' with assets for testing only into build.
        ///
        /// To mark specific 'AddressableAssetGroup' as group with assets for testing, add a 'IncludeWithTestsGroupScheme' to it.
        /// </remarks>
        public static bool IncludeTestGroups
        {
            get { return m_settings.Data.IncludeTestGroups; }
            set
            {
                m_settings.Data.IncludeTestGroups = value;
                m_settings.Save();
            }
        }

        private static readonly CustomSettingsEditorPackage<AddressableEditorSettingsData> m_settings = new CustomSettingsEditorPackage<AddressableEditorSettingsData>
        (
            "UGF.Addressable",
            "AddressableEditorSettings",
            CustomSettingsEditorUtility.DefaultPackageExternalFolder
        );

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<AddressableEditorSettingsData>("Project/UGF/Addressable", m_settings, SettingsScope.Project);
        }
    }
}
