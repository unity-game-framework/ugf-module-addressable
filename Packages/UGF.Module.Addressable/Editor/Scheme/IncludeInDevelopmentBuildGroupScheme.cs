using UnityEditor;

namespace UGF.Module.Addressable.Editor.Scheme
{
    /// <summary>
    /// Represents scheme that marks specific asset group to include in development build only.
    /// </summary>
    /// <remarks>
    /// The asset group with this scheme, will be included in build, if 'Development Mode' enabled in build settings.
    /// </remarks>
    public class IncludeInDevelopmentBuildGroupScheme : IncludeGroupSchemeBase
    {
        public override bool Check()
        {
            return EditorUserBuildSettings.development;
        }

        public override void OnGUI()
        {
            base.OnGUI();

            if (EditorUserBuildSettings.development)
            {
                EditorGUILayout.HelpBox("Development mode is enabled: this group will be included in build.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("Development mode is disabled: this group will be excluded from build.", MessageType.Warning);
            }
        }
    }
}
