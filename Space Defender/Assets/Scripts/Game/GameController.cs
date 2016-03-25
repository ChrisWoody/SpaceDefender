using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Game
{
    public class GameController : MonoBehaviour
    {
        public const float PlayerHealth = 100f;
        public const float LaserDamage = 0.5f;
        public const float LanceDamage = 5f;

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