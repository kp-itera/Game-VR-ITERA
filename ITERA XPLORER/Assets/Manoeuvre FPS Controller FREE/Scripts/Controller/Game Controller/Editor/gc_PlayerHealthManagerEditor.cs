using UnityEditor;
using UnityEngine;

namespace Manoeuvre
{
    [CustomEditor(typeof(gc_PlayerHealthManager))]
    public class gc_PlayerHealthManagerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            Texture t = (Texture)Resources.Load("EditorContent/Health-icon");
            GUILayout.Box(t, GUILayout.ExpandWidth(true));

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("This script manages the circular Health Slider HUD in accordance with the Player's Maximum and Current Health. ", MessageType.Info);

            base.OnInspectorGUI();
            EditorGUILayout.EndVertical();
        }
    }
}