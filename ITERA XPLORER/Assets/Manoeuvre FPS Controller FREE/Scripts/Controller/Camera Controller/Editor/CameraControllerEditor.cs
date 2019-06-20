using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Manoeuvre
{
    [CustomEditor(typeof(CameraController))]
    public class CameraControllerEditor : Editor
    {
        CameraController _cameraController;
        bool _showBobProperties;

        private void OnEnable()
        {
            _cameraController = (CameraController)target;
        }

        public override void OnInspectorGUI()
        {
            //Controller texture
            Texture t = (Texture)Resources.Load("EditorContent/Camera-icon");
            GUILayout.Box(t, GUILayout.ExpandWidth(true));

            DrawCameraController();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            DrawPlayerStateBasedBobbing();

         //   DrawDefaultInspector();
        }

        void DrawCameraController()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Change the below Camera Controller properties to suit your needs accordingly!", MessageType.Info);

            float LookSensitivity = EditorGUILayout.Slider("Look Sensitivity", _cameraController.lookSensitivity, 1f, 15f);
            float LookSmooth = EditorGUILayout.Slider("Look Smoothing", _cameraController.lookSmoth, 0.05f, 1f);


            float minAngle = EditorGUILayout.Slider("Minimum Angle", _cameraController.MinMaxAngle.x, -360, 360);
            float maxAngle = EditorGUILayout.Slider("Maximum Angle", _cameraController.MinMaxAngle.y, -360, 360);


            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "camera controller");

                _cameraController.lookSensitivity = LookSensitivity;
                _cameraController.lookSmoth = LookSmooth;
                _cameraController.MinMaxAngle.x = minAngle;
                _cameraController.MinMaxAngle.y = maxAngle;

            }
        }

        void DrawPlayerStateBasedBobbing()
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Camera Headbob states based on the Current Player State : \n" +
                                    "> Idle  \n" +
                                    "> Crouching  \n" +
                                    "> Walking  \n" +
                                    "> Running ", MessageType.Info);

            EditorGUILayout.EndVertical();

            if (_showBobProperties)
                if (GUILayout.Button("Hide"))
                    _showBobProperties = false;

            if (!_showBobProperties)
            {
                if (GUILayout.Button("Show"))
                    _showBobProperties = true;

                return;
            }

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Dynamic Camera Bobbing is a full version feature!", MessageType.Info);

            if (GUILayout.Button("Get Full Version"))
                Application.OpenURL("http://u3d.as/14Cy");

            EditorGUILayout.EndVertical();
        }

        

    }
}