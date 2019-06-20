using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manoeuvre
{
    public class gc_StateManager : MonoBehaviour
    {
        public PlayerStates currentPlayerState;

        [HideInInspector]
        public GameObject sensorCollider;
        [Range(0f, 30f)]
        [HideInInspector]
        public float sensorRadius = 5f;

        [HideInInspector]
        public float radiusWhileRunning;
        [HideInInspector]
        public float radiusWhileShooting;

        public static gc_StateManager Instance;
        GameObject Player;

        // Use this for initialization
        void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            Instance = this;

        }

    }
}