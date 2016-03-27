using System.Collections;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public class EnemyTurret : EnemyWeaponBase
    {
        private float _cooldownElapsed;
        private const float Cooldown = 0.5f;

        private const float FiringAngle = 90f; // might change later
        private bool _isPlayerInFiringAngle;

        // TODO: show point light as laser is fired

        protected override void OnAwake()
        {
            Health = GameController.EnemyLaserHealth;
        }

        protected override void OnStart()
        {
            StartCoroutine(DetermineAngleToPlayer());
            _cooldownElapsed = Random.value*Cooldown;
        }

        protected override void OnUpdate()
        {
            _cooldownElapsed += Time.deltaTime;

            if (_cooldownElapsed >= Cooldown)
            {
                if (_isPlayerInFiringAngle)
                {
                    _cooldownElapsed = 0f;

                    var dir = (Player.position - transform.position).normalized;
                    var laser = Instantiate(ResourceProvider.TurretLaser);

                    laser.GetComponent<EnemyTurretLaser>().Fire(transform.position, dir);
                }
            }
        }

        private IEnumerator DetermineAngleToPlayer()
        {
            while (true)
            {
                _isPlayerInFiringAngle = IsPlayerInRange();
                yield return new WaitForSeconds(1f);
            }
        }

        private bool IsPlayerInRange()
        {
            var angle = Vector3.Angle(transform.forward, transform.position - Player.position);
            return angle < FiringAngle;
        }
    }
}