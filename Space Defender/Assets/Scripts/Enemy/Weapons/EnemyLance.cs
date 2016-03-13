using System.Collections;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public class EnemyLance : EnemyWeaponBase
    {
        private float _cooldownElapsed;
        private const float Cooldown = 2f;

        private const float FiringAngle = 90f;
        private bool _isPlayerInFiringAngle;

        protected override void OnStart()
        {
            StartCoroutine(DetermineAngleToPlayer());
            _cooldownElapsed = Random.value * Cooldown;
        }

        protected override void OnUpdate()
        {
            _cooldownElapsed += Time.deltaTime;

            if (_cooldownElapsed >= Cooldown)
            {
                if (_isPlayerInFiringAngle)
                {
                    _cooldownElapsed = 0f;

                    var lance = Instantiate(ResourceProvider.LanceRound);

                    var dir = (Player.position - transform.position).normalized;
                    var pos = transform.position + (dir*lance.transform.lossyScale.y);

                    lance.GetComponent<EnemyLanceRound>().Fire(pos, dir);
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