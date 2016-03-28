using System;
using System.Linq;
using Assets.Scripts.Enemy.Weapons;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Game
{
    public class UiController : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        void Awake()
        {
            Assert.IsTrue(FindObjectsOfType<GameController>().Count() == 1,
                "Scene can only have 1 " + GetType().Name);

            SubscribeToGameObjects();
        }

        private void SubscribeToGameObjects()
        {
            FindObjectOfType<Player.Player>().HitWithCurrentHealth += OnPlayerHit;
            FindObjectOfType<GameController>().GameOver += OnGameOver;

            foreach (var enemyTurret in FindObjectsOfType<EnemyLaserTurret>())
            {
                enemyTurret.Death += OnEnemyLaserTurretDeath;
            }

            foreach (var enemyLances in FindObjectsOfType<EnemyLanceTurret>())
            {
                enemyLances.Death += OnEnemyLanceTurretHit;
            }
            

            // find enemy
            // find enemy lasers
            // find enemy lances
            // find enemy engines
            // find other enemy things if necessary
        }

        void Start()
        {
            LockCursor();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                    LockCursor();
                else
                    UnlockCursor();
            }
        }

        private static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private static void OnPlayerHit(float health)
        {
            //Debug.Log(string.Format("Player hit, health: {0}", health));
        }

        private static void OnEnemyLaserTurretDeath()
        {
            Debug.Log("Enemy laser turret died");
        }

        private static void OnEnemyLanceTurretHit()
        {
            Debug.Log("Enemy lance turret died");
        }

        private static void OnGameOver()
        {
            Debug.Log("Game over");
        }

        // Note for future. As a possible implementation could have this class subscribe to events fired on the player and enemy,
        // so even though player/enemy needs to call something when things happen, it would make this and game controller a bit simplier.
        // Its not end of the world if they need to explicity notify these, but there could be multiple things it has to call.
        // And becaues its cool.
    }
}
