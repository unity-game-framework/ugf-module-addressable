using UnityEngine;

namespace UGF.Module.Addressable.Editor.Settings
{
    internal class AddressableEditorSettingsData : ScriptableObject
    {
        [Tooltip("Determines whether to include asset groups marked with test group scheme.")]
        [SerializeField] private bool m_includeTestGroups;

        public bool IncludeTestGroups { get { return m_includeTestGroups; } set { m_includeTestGroups = value; } }
    }
}
