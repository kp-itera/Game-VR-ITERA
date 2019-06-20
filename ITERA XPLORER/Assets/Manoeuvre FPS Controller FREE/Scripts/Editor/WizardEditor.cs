using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Manoeuvre
{
    public class WizardEditor : EditorWindow
    {
        int wizardTabCount;
        int pickupTabCount;
        int pickupQuantity_powerup;
        int pickupQuantity_weapon;

        Transform _weaponObject;

        Texture[] toolbarTextures = new Texture[3];

        string weaponName;
        GameObject weaponObj;

        [MenuItem("Manoeuvre/Wizard")]
        public static void OpenWizard()
        {
            GetWindow<WizardEditor>("Manoeuvre Wizard");
            GetWindow<WizardEditor>("Manoeuvre Wizard").maxSize = new Vector2(680, 600);
            GetWindow<WizardEditor>("Manoeuvre Wizard").minSize = new Vector2(679, 599);
        }

        private void OnGUI()
        {
            //YouTube texture
            Texture t0 = (Texture)Resources.Load("EditorContent/Logo");

            //tut button
            if (GUILayout.Button(t0))
            {
                Application.OpenURL("http://u3d.as/14Cy");
            }

            EditorGUILayout.BeginHorizontal("box");

            switch (wizardTabCount)
            {
                //controller
                case 0:
                    EditorGUILayout.HelpBox("Create Manoeuvre Controller.", MessageType.Info);
                    break;

                case 01:
                    EditorGUILayout.HelpBox("Create Weapon.", MessageType.Info);
                    break;

                case 02:
                    EditorGUILayout.HelpBox("Create Pickups for Manoeuvre Controller and Weapon.", MessageType.Info);
                    break;

            }

            //YouTube texture
            Texture t4 = (Texture)Resources.Load("EditorContent/YouTube-icon");

            //tut button
            if (GUILayout.Button(t4, GUILayout.Width(40), GUILayout.Height(38)))
            {
                Application.OpenURL("https://www.youtube.com/channel/UCpX1xXvpG6uYiHq18Ju0R6g?view_as=subscriber");
            }

            EditorGUILayout.EndHorizontal();

            //controller texture
            Texture t1 = (Texture)Resources.Load("EditorContent/Controller-icon");
            toolbarTextures[0] = t1;

            //weapon texture
            Texture t2 = (Texture)Resources.Load("EditorContent/Weapon-icon");
            toolbarTextures[1] = t2;

            //pickups texture
            Texture t3 = (Texture)Resources.Load("EditorContent/Pickups-icon");
            toolbarTextures[2] = t3;

            EditorGUILayout.BeginHorizontal("box");

            wizardTabCount = GUILayout.Toolbar(wizardTabCount, toolbarTextures);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            switch (wizardTabCount)
            {
                case 0:
                    OpenControllerCreationDialog();
                    break;

                case 01:
                    OpenWeaponCreationDialog();
                    break;

                case 02:
                    OpenPickupsCreationDialog();
                    break;

            }

        }

        void OpenControllerCreationDialog()
        {

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Clicking the Create Button below will Add Manoeuvre FPS Rig, UI, and Game Controller. " +
                "Please make sure you are doing this in an Empty Scene.", MessageType.Info);

            if(GUILayout.Button("Create Controller"))
            {
                CreateController();
            }

            EditorGUILayout.EndVertical();
        }

        void CreateController()
        {
            //Controller GameObject
            GameObject _controller = Instantiate(Resources.Load("EditorContent/Controller/Manoeuvre FPS Rig")) as GameObject;
            _controller.name = "Manoeuvre FPS Rig";
            _controller.transform.position = Vector3.zero;

            //UI
            GameObject _UI = Instantiate(Resources.Load("EditorContent/Controller/UICamera")) as GameObject;
            _UI.name = "UICamera";

            //Game Controller
            GameObject _gameController = Instantiate(Resources.Load("EditorContent/Controller/GameController")) as GameObject;
            _gameController.name = "GameController";

            Debug.Log("Conroller Created");

        }

        void OpenWeaponCreationDialog()
        {

            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Available in the Paid Version!", MessageType.Info);

            if (GUILayout.Button("Get Full Version"))
                Application.OpenURL("http://u3d.as/14Cy");

            EditorGUILayout.EndVertical();

        }


        void OpenPickupsCreationDialog()
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.HelpBox("Available in the Paid Version!", MessageType.Info);

            if (GUILayout.Button("Get Full Version"))
                Application.OpenURL("http://u3d.as/14Cy");

            EditorGUILayout.EndVertical();
        }

        
    }
}