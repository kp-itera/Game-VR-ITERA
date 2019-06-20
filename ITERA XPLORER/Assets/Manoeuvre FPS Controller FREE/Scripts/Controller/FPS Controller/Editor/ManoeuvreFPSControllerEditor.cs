using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Manoeuvre
{

    [CustomEditor(typeof(ManoeuvreFPSController))]
    public class ManoeuvreFPSControllerEditor : Editor
    {
        ManoeuvreFPSController _Controller;

        List<AudioClip> FootStepSounds_Slow = new List<AudioClip>();
        List<AudioClip> FootStepSounds_Fast = new List<AudioClip>();
        
        List<AudioClip> HitSounds = new List<AudioClip>();
        List<AudioClip> DeathSounds = new List<AudioClip>();

        private void OnEnable()
        {
             _Controller = (ManoeuvreFPSController) target;
        }

        public override void OnInspectorGUI()
        {

            //Controller texture
            Texture t = (Texture)Resources.Load("EditorContent/Controller-icon");

            GUILayout.Box(t, GUILayout.ExpandWidth(true));

             DrawPropertyTabs();

        }

        void DrawPropertyTabs()
        {
            _Controller.propertyTab = GUILayout.Toolbar(_Controller.propertyTab, new string[] { "Inputs", "Locomotion", "Health" });

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            switch (_Controller.propertyTab)
            {
                case 0:

                    DrawInputsProperties();
                    break;
                case 1:
                    DrawLocomotionProperties();
                    break;
                case 2:
                    DrawHealthProperties();
                    break;
            }

            //EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            //DrawDefaultInspector();
        }

        void DrawInputsProperties()
        {

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.HelpBox("Make Sure you have set these buttons exactly same in Input.\n" +
                                    "Edit > Project Settings > Input", MessageType.Info);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Axis Inputs", EditorStyles.centeredGreyMiniLabel);

            string Horizontal = EditorGUILayout.TextField("Horizontal Axis ", _Controller.inputs.Horizontal);
            string Vertical = EditorGUILayout.TextField("Vertical Axis ", _Controller.inputs.Vertical);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Jump Inputs", EditorStyles.centeredGreyMiniLabel);

            string jumpButton = EditorGUILayout.TextField("Jump Button ", _Controller.inputs.jumpButton);
            KeyCode jumpKey = (KeyCode) EditorGUILayout.EnumPopup("Jump Key ", _Controller.inputs.jumpKey );

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Crouch Inputs", EditorStyles.centeredGreyMiniLabel);

            string crouchButton = EditorGUILayout.TextField("Crouch Button ", _Controller.inputs.crouchButton);
            KeyCode crouchKey = (KeyCode)EditorGUILayout.EnumPopup("Crouch Key ", _Controller.inputs.crouchKey);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Run Inputs", EditorStyles.centeredGreyMiniLabel);

            string runButton = EditorGUILayout.TextField("Run Button ", _Controller.inputs.runButton);
            KeyCode runKey = (KeyCode)EditorGUILayout.EnumPopup("Run Key ", _Controller.inputs.runKey);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Weapon Inputs", EditorStyles.centeredGreyMiniLabel);

            string shootButton = EditorGUILayout.TextField("Shoot Button ", _Controller.inputs.shootButton);
            KeyCode shootKey = (KeyCode)EditorGUILayout.EnumPopup("Shoot Key ", _Controller.inputs.shootKey);
            KeyCode ironSightInputKey = (KeyCode)EditorGUILayout.EnumPopup("Ironsight Key ", _Controller.inputs.ironSightInputKey);

            string ReloadButton = EditorGUILayout.TextField("Reload Button", _Controller.inputs.ReloadButton);
            KeyCode ReloadKey = (KeyCode)EditorGUILayout.EnumPopup("Reload Key ", _Controller.inputs.ReloadKey);

            string NextWeaponButton = EditorGUILayout.TextField("Next Weapon Button", _Controller.inputs.NextWeaponButton);
            KeyCode NextWeaponKey = (KeyCode)EditorGUILayout.EnumPopup("Next Weapon Key ", _Controller.inputs.NextWeaponKey);

            string PreviousWeaponButton = EditorGUILayout.TextField("Previous Weapon Button", _Controller.inputs.PreviousWeaponButton);
            KeyCode PreviousWeaponKey = (KeyCode)EditorGUILayout.EnumPopup("Previous Weapon Key ", _Controller.inputs.PreviousWeaponKey);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Inventory Input", EditorStyles.centeredGreyMiniLabel);

            string InventoryButton = EditorGUILayout.TextField("Inventory Button ", _Controller.inputs.InventoryButton);
            KeyCode InventoryKey = (KeyCode)EditorGUILayout.EnumPopup("Inventory Key ", _Controller.inputs.InventoryKey);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Minimap Input", EditorStyles.centeredGreyMiniLabel);

            string ZoomInButton = EditorGUILayout.TextField("Zoom In Button ", _Controller.inputs.ZoomInButton);
            KeyCode ZoomInKey = (KeyCode)EditorGUILayout.EnumPopup("Zoom In Key ", _Controller.inputs.ZoomInKey);
            string ZoomOutButton = EditorGUILayout.TextField("Zoom Out Button ", _Controller.inputs.ZoomOutButton);
            KeyCode ZoomOutKey = (KeyCode)EditorGUILayout.EnumPopup("Zoom Out Key ", _Controller.inputs.ZoomOutKey);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "inputs");

                _Controller.inputs.Horizontal = Horizontal;
                _Controller.inputs.Vertical = Vertical;
                _Controller.inputs.jumpButton = jumpButton;
                _Controller.inputs.jumpKey = jumpKey;
                _Controller.inputs.crouchButton = crouchButton;
                _Controller.inputs.crouchKey = crouchKey;
                _Controller.inputs.runButton = runButton;
                _Controller.inputs.runKey = runKey;

                _Controller.inputs.shootButton = shootButton;
                _Controller.inputs.shootKey = shootKey;
                _Controller.inputs.ironSightInputKey = ironSightInputKey;
                _Controller.inputs.ReloadButton = ReloadButton;
                _Controller.inputs.ReloadKey = ReloadKey;
                _Controller.inputs.NextWeaponButton = NextWeaponButton;
                _Controller.inputs.NextWeaponKey = NextWeaponKey;
                _Controller.inputs.PreviousWeaponButton = PreviousWeaponButton;
                _Controller.inputs.PreviousWeaponKey = PreviousWeaponKey;
                _Controller.inputs.InventoryButton = InventoryButton;
                _Controller.inputs.InventoryKey = InventoryKey;
                _Controller.inputs.ZoomInButton = ZoomInButton;
                _Controller.inputs.ZoomInKey = ZoomInKey;
                _Controller.inputs.ZoomOutButton = ZoomOutButton;
                _Controller.inputs.ZoomOutKey = ZoomOutKey;


            }

        }

        void DrawLocomotionProperties()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.HelpBox("Tweak Manoeuvre Properties of the Controller.", MessageType.Info);

            float walkSpeed = EditorGUILayout.Slider("Walk Speed ", _Controller.Locomotion.walkSpeed, 0.1f,5f);
            float crouchSpeed = EditorGUILayout.Slider("Crouch Speed ", _Controller.Locomotion.crouchSpeed, 0.1f,5f);
            float runSpeed = EditorGUILayout.Slider("Run Speed ", _Controller.Locomotion.runSpeed, 0.1f,15f);
            float jumpSpeed = EditorGUILayout.Slider("Jump Speed ", _Controller.Locomotion.jumpSpeed, 0.1f,15f);
            float fallSpeed = EditorGUILayout.Slider("Fall Speed ", _Controller.Locomotion.fallSpeed, 0.1f,15f);
            float gravityEffector = EditorGUILayout.Slider("Gravity Speed ", _Controller.Locomotion.gravityEffector, 0.1f,15f);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.HelpBox("Controller Height while crouching and while normal walk / run Manoeuvre.", MessageType.Info);

            float crouchHeight = EditorGUILayout.Slider("Crouch Height", _Controller.Locomotion.crouchHeight, 0.1f, 2f);
            float normalHeight = EditorGUILayout.Slider("Normal Height", _Controller.Locomotion.normalHeight, 0.1f, 5f);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.HelpBox("The range within which zombies can hear you while running.", MessageType.Info);

            float hearRange = EditorGUILayout.Slider("Hear Range", _Controller.Locomotion.HearRange, 1, 15);

            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            //draw foot steps list
            DrawFootStepsList_Walk();

            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            //draw foot steps list
            DrawFootStepsList_Run();

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "speeds");
                _Controller.Locomotion.walkSpeed = walkSpeed;
                _Controller.Locomotion.crouchSpeed = crouchSpeed;
                _Controller.Locomotion.runSpeed = runSpeed;
                _Controller.Locomotion.jumpSpeed = jumpSpeed;
                _Controller.Locomotion.fallSpeed = fallSpeed;
                _Controller.Locomotion.gravityEffector = gravityEffector;

                _Controller.Locomotion.crouchHeight = crouchHeight;
                _Controller.Locomotion.normalHeight = normalHeight;

                _Controller.Locomotion.HearRange = hearRange;

                _Controller.Locomotion.FootStepSounds_Slow = FootStepSounds_Slow;
                _Controller.Locomotion.FootStepSounds_Fast = FootStepSounds_Fast;

            }
        }

        void DrawFootStepsList_Walk()
        {
            FootStepSounds_Slow = _Controller.Locomotion.FootStepSounds_Slow;
            
            EditorGUILayout.HelpBox("Add Audio Clips for Walk Manoeuvre.", MessageType.Info);

            if (FootStepSounds_Slow.Count == 0)
                EditorGUILayout.HelpBox("Add At least 1 AudioClip.", MessageType.Error);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add New"))
            {
                AudioClip newAC = null;

                FootStepSounds_Slow.Add(newAC);
            }

            if (GUILayout.Button("Clear"))
            {
                FootStepSounds_Slow.Clear();
            }

            EditorGUILayout.EndHorizontal();

            for (int i =0; i < FootStepSounds_Slow.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("box");

                FootStepSounds_Slow[i] = (AudioClip)EditorGUILayout.ObjectField(FootStepSounds_Slow[i], typeof(AudioClip));

                if (GUILayout.Button("X"))
                {
                    FootStepSounds_Slow.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();

            }
        }

        void DrawFootStepsList_Run()
        {

            FootStepSounds_Fast = _Controller.Locomotion.FootStepSounds_Fast;

            EditorGUILayout.HelpBox("Add Audio Clips for Run Manoeuvre.", MessageType.Info);

            if(FootStepSounds_Fast.Count == 0)
                EditorGUILayout.HelpBox("Add At least 1 AudioClip.", MessageType.Error);


            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add New"))
            {
                AudioClip newAC = null;

                FootStepSounds_Fast.Add(newAC);
            }

            if (GUILayout.Button("Clear"))
            {
                FootStepSounds_Fast.Clear();
            }

            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < FootStepSounds_Fast.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("box");

                FootStepSounds_Fast[i] = (AudioClip)EditorGUILayout.ObjectField(FootStepSounds_Fast[i], typeof(AudioClip));

                if (GUILayout.Button("X"))
                {
                    FootStepSounds_Fast.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();

            }

        }

        void DrawHealthProperties()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.HelpBox("Manoeuvre Controller Health.", MessageType.Info);

            int Health = EditorGUILayout.IntSlider("Health ", _Controller.Health.Health, 1, 200);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.HelpBox("Manoeuvre Controller Camera Shake on getting Damage.", MessageType.Info);

            float ShakeDuration = EditorGUILayout.Slider("Shake Duration", _Controller.Health.ShakeDuration, 0.01f, 0.5f);
            float ShakeAmount = EditorGUILayout.Slider("Shake Amount", _Controller.Health.ShakeAmount, 0.01f, 0.1f);

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.HelpBox("Duration of Damage Vignette which will appear on getting hit.", MessageType.Info);

            float DamageVignetteDuration = EditorGUILayout.Slider("Damage Vignette Duration", _Controller.Health.DamageVignetteDuration, 0.1f , 2f);

            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            //draw hit audio
            DrawHitAudio();

            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            //draw death audio
            DrawDeathAudio();

            EditorGUILayout.EndVertical();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.HelpBox("Procedural Death Manoeuvre when health reaches zero.", MessageType.Info);

            Vector3 cameraPositionOffset = EditorGUILayout.Vector3Field("Camera Position Offset", _Controller.Health.deathManoeuvre.cameraPositionOffset);
            Vector3 cameraRotationOffset = EditorGUILayout.Vector3Field("Camera Rotation Offset", _Controller.Health.deathManoeuvre.cameraRotationOffset);

            float deathDuration = EditorGUILayout.Slider("Death Duration", _Controller.Health.deathManoeuvre.deathDuration, 0.5f, 10f);
            float WeaponDismembermentForce = EditorGUILayout.Slider("Weapon Dismemberment Force", _Controller.Health.deathManoeuvre.WeaponDismembermentForce, 1f, 25f);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Health");

                _Controller.Health.Health = Health;
                _Controller.Health.ShakeDuration = ShakeDuration;
                _Controller.Health.ShakeAmount = ShakeAmount;
                _Controller.Health.DamageVignetteDuration = DamageVignetteDuration;

                _Controller.Health.HitSounds = HitSounds;
                _Controller.Health.DeathSounds = DeathSounds;

                _Controller.Health.deathManoeuvre.cameraPositionOffset = cameraPositionOffset;
                _Controller.Health.deathManoeuvre.cameraRotationOffset = cameraRotationOffset;
                _Controller.Health.deathManoeuvre.deathDuration = deathDuration;
                _Controller.Health.deathManoeuvre.WeaponDismembermentForce = WeaponDismembermentForce;
            }
        }

        void DrawHitAudio()
        {
            HitSounds = _Controller.Health.HitSounds;

            EditorGUILayout.HelpBox("Add Audio Clips for Hit Sound Effect.", MessageType.Info);

            if (HitSounds.Count == 0)
                EditorGUILayout.HelpBox("Add At least 1 AudioClip.", MessageType.Error);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add New"))
            {
                AudioClip newAC = null;
                HitSounds.Add(newAC);
            }

            if (GUILayout.Button("Clear"))
            {
                HitSounds.Clear();
            }

            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < HitSounds.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("box");

                HitSounds[i] = (AudioClip)EditorGUILayout.ObjectField(HitSounds[i], typeof(AudioClip));

                if (GUILayout.Button("X"))
                {
                    HitSounds.RemoveAt(i);
                }

                EditorGUILayout.EndHorizontal();

            }
        }

        void DrawDeathAudio()
        {
            DeathSounds = _Controller.Health.DeathSounds;

            EditorGUILayout.HelpBox("Add Audio Clips for Death Sound Effect.", MessageType.Info);

            if (DeathSounds.Count == 0)
                EditorGUILayout.HelpBox("Add At least 1 AudioClip.", MessageType.Error);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add New"))
            {
                AudioClip newAC = null;

                DeathSounds.Add(newAC);
            }

            if (GUILayout.Button("Clear"))
            {
                DeathSounds.Clear();
            }

            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < DeathSounds.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("box");

                DeathSounds[i] = (AudioClip)EditorGUILayout.ObjectField(DeathSounds[i], typeof(AudioClip));

                if (GUILayout.Button("X"))
                {
                    DeathSounds.RemoveAt(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();

            }
        }

    }
}