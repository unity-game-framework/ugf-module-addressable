using UGF.Module.Addressable.Editor.Settings;
using UnityEditor;

namespace UGF.Module.Addressable.Editor.Scheme
{
    /// <summary>
    /// Represents scheme that marks specific asset group to include in test builds only.
    /// </summary>
    /// <remarks>
    /// The asset group with this scheme, will be included in build, if 'Include Test Groups' enabled in 'UGF.Addressable' project settings.
    ///
    /// Addressable project settings can be found at: "ProjectSettings/UGF/Addressable".
    /// </remarks>
    public class IncludeWithTestsGroupScheme : IncludeGroupSchemeBase
    {
        public override bool Check()
        {
            return AddressableEditorSettings.IncludeTestGroups;
        }

        public override void OnGUI()
        {
            if (AddressableEditorSettings.IncludeTestGroups)
            {
                EditorGUILayout.HelpBox("Include test groups options is enabled: this group will be included in build.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("Include test groups options is disabled: this group will be excluded from build.\nGo to ProjectSettings/UGF/Addressable to change that option.", MessageType.Warning);
            }
        }
    }
}
