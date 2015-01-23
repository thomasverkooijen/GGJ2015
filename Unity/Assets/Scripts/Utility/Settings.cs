using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Utility
{
    public class Settings : Singleton<Settings>
    {
        public float SpawnDelay = 0.31f;
        public float Stickiness = 0.8f;
        public float Bounciness = 0.0f;

        public int NumberOfLevels = 7;

        public void Load()
        {
            SpawnDelay = 1.0f;
            Stickiness = 0.4f;
            Bounciness = 0.0f;
            #if UNITY_EDITOR
            SpawnDelay = .1f;
            #endif
        }
    }
}
