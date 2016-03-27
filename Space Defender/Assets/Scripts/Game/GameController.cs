using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Game
{
    public class GameController : MonoBehaviour
    {
        // NOTE: all these healths/damages are temporary, will need to be balanced at some point

        public const float PlayerHealth = 100f;
        public const float PlayerLaserDamage = 5f;
        public const float PlayerMissileDamage = 40f;
        public const float PlayerRailgunDamage = 100f;
        public const float PlayerArouraBombDamage = 200f;

        public const float EnemyLaserHealth = 50f;
        public const float EnemyLanceHealth = 300f;
        public const float EnemyLaserDamage = 0.5f;
        public const float EnemyLanceDamage = 5f;

        void Awake()
        {
            Assert.IsTrue(FindObjectsOfType<GameController>().Count() == 1,
                "Scene can only have 1 " + GetType().Name);

            SubscribeToGameObjects();
        }

        private void SubscribeToGameObjects()
        {
            FindObjectOfType<Player.Player>().HitWithCurrentHealth += OnPlayerHitWithCurrentHealth;

            // find enemy
            // find enemy lasers
            // find enemy lances
            // find enemy engines
            // find other enemy things if necessary
        }

        private void OnPlayerHitWithCurrentHealth(float val)
        {
            if (val <= 0f)
            {
                // game over, call event to notify ui and prompt to retry
            }
        }
    }
}