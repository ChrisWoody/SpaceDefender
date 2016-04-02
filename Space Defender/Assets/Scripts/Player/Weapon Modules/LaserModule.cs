using Assets.Scripts.Enemy;
using Assets.Scripts.Game;
using Assets.Scripts.Player.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player.Weapon_Modules
{
    public class LaserModule : WeaponModuleBase
    {
        public override string Name
        {
            get { return "Laser"; }
        }

        private float _elapsed;
        private const float FireRate = 0.5f;

        public override void OnUnselected()
        {
            Restart();
            base.OnUnselected();
        }

        public override void OnLeftMouseButtonUp()
        {
            Restart();
        }

        public override void OnLeftMouseButton()
        {
            _elapsed += Time.deltaTime;
            if (_elapsed < FireRate) return;

            Restart();
            FireLasers();
        }

        private void FireLasers() // TODO will update this since a lot of duplication, down/left/right logic doesn't work where player is looking
        {
            RaycastHit left;
            RaycastHit right;

            var down = Vector3.down*0.25f;

            if (Physics.Raycast(PlayerCamera.position-Vector3.left+down, CameraForward, out left))
            {
                FireLaserThatHitSomething(left);
            }
            else
            {
                var laser = Object.Instantiate(ResourceProvider.Laser);
                laser.GetComponent<Laser>().SetLaserPositionsAndFire(PlayerCamera.position - Vector3.left + down, PlayerCamera.position + (CameraForward*1000f));
            }

            if (Physics.Raycast(PlayerCamera.position+Vector3.left + down, CameraForward, out right))
            {
                FireLaserThatHitSomething(right);
            }
            else
            {
                var laser = Object.Instantiate(ResourceProvider.Laser);
                laser.GetComponent<Laser>().SetLaserPositionsAndFire(PlayerCamera.position + Vector3.left + down, PlayerCamera.position + (CameraForward * 1000f));
            }
        }

        private void FireLaserThatHitSomething(RaycastHit hit)
        {
            var laser = Object.Instantiate(ResourceProvider.Laser);
            laser.GetComponent<Laser>().SetLaserPositionsAndFire(PlayerCamera.position, hit.point);
            var laserExplosion = Object.Instantiate(ResourceProvider.LaserExplosion);
            laserExplosion.position = hit.point;
            var enemy = hit.transform.GetComponent<EnemyBase>();
            if (enemy != null)
                enemy.Hit(GameController.PlayerLaserDamage);
        }

        private void Restart()
        {
            _elapsed = 0.0f;
        }
    }
}
