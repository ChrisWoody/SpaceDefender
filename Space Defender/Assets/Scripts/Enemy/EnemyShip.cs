using System.Linq;
using Assets.Scripts.Enemy.Weapons;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    public class EnemyShip : EnemyBase
    {
        private const float Speed = 1f; // NOTE: the speed will change at some point, we'll have a speed scale of same kind then

        private int _totalLaserTurrets;
        private int _currentLaserTurrets;
        private int _totalLanceTurrets;
        private int _currentLanceTurrets;

        protected override void OnAwake()
        {
            Assert.IsTrue(FindObjectsOfType<EnemyShip>().Count() == 1,
                "Scene can only have 1 " + GetType().Name);

            SubscribeToGameObjects();
        }

        private void SubscribeToGameObjects()
        {
            var laserTurrets = FindObjectsOfType<EnemyLaserTurret>();
            var lanceTurrets = FindObjectsOfType<EnemyLanceTurret>();

            _totalLaserTurrets = _currentLaserTurrets = laserTurrets.Count();
            _totalLanceTurrets = _currentLanceTurrets = lanceTurrets.Count();

            foreach (var laserTurret in laserTurrets) laserTurret.Death += () => _currentLaserTurrets--;
            foreach (var lanceTurret in lanceTurrets) lanceTurret.Death += () => _currentLanceTurrets--;

            Debug.Log("Found " + _totalLaserTurrets + " laser turrets");
            Debug.Log("Found " + _totalLanceTurrets + " lance turrets");
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnUpdate()
        {
            transform.Translate(0f, 0f, -Speed*Time.deltaTime);
        }

        // This suggests i should be doing the inheritance of the EnemyBase different for the enemy ship and weapons, but is ok for now
        protected override bool IsEnemyShip { get { return true; } }
    }
}