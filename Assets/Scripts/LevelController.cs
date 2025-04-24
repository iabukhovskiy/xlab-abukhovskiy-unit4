using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        private float m_delay = 0.5f;
        public float delayMax = 2f;
        public float delayMin = 0f;
        public float delayStep = 0.1f;
        private float m_lastSpawnedTime;
        public void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
            //GameEvents.onStickHit += OnStickHit;
            //score = 0;

        }

        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
            //GameEvents.onStickHit -= OnStickHit;
        }

        private void GameOver()
        {
            Debug.Log("Game Over!");
            enabled = false;
        }

        public void RefreshDelay()
        { 
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                /*var stone = */spawner.Spawn();
                //m_stones.Add(stone);
                m_lastSpawnedTime = Time.time;
                RefreshDelay();
            }
        }
    }
}
