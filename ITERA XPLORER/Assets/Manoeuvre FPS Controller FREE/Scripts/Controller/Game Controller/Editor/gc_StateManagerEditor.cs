using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Manoeuvre
{
    [CustomEditor(typeof(gc_StateManager))]
    public class gc_StateManagerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            Texture t = (Texture)Resources.Load("EditorContent/StateManager-icon");
            GUILayout.Box(t, GUILayout.ExpandWidth(true));

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("This script Looks at Player's and Weapon's current State.\n"
                                  + "This script also adds and manages the sensor trigger around the Player which is used by Zombies for Detection.", MessageType.Info);
            base.OnInspectorGUI();
            EditorGUILayout.EndVertical();
        }
    }
}