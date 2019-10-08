using UnityEditor;
using UnityEngine;

namespace UGF.Module.Addressable.Editor.Scheme
{
    /// <summary>
    /// Represents scheme that marks specific asset group to include in build for specified platform only.
    /// </summary>
    /// <remarks>
    /// The asset group with this scheme will be included in build, if currently selected platform matched with the specified target platform.
    /// </remarks>
    public class IncludeByPlatformGroupScheme : IncludeGroupSchemeBase
    {
        [SerializeField] private BuildTarget m_platform = BuildTarget.NoTarget;

        /// <summary>
        /// Gets or sets target platform.
        /// </summary>
        public BuildTarget Platform { get { return m_platform; } set { m_platform = value; } }

        public override bool Check()
        {
            return EditorUserBuildSettings.activeBuildTarget == m_platform;
        }

        public override void OnGUI()
        {
            base.OnGUI();

            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;

            if (m_platform == activeBuildTarget)
            {
                EditorGUILayout.HelpBox("Current platform is matched: this group will be included in build.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox($"Current platform is not matched: this group will be excluded from build. (Selected:'{activeBuildTarget}')", MessageType.Warning);
            }
        }
    }
}
