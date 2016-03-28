using System.Linq;
using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Player.Weapon_Modules
{
    public class RailgunModule : WeaponModuleBase
    {
        public override string Name
        {
            get { return "Railgun"; }
        }

        private float _elapsed;
        private const float FireRate = 2f;

        private const float RaycastDistance = 5000f;

        // TODO: add cooldown logic, its a powerful weapon so should be used sparingly

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
            FireRailgun();
        }

        private void FireRailgun()
        {
            var otherPoint = CameraPosition + (CameraForward*RaycastDistance);

            var forwardHits = Physics.RaycastAll(CameraPosition, CameraForward, RaycastDistance);
            var backwardHits = Physics.RaycastAll(otherPoint, -CameraForward, RaycastDistance);

            // TODO: replace tag check with component of enemy base once implemented
            var hits = forwardHits.Where(x => x.transform.tag.Contains("Enemy"))
                .Concat(backwardHits.Where(x => x.transform.tag.Contains("Enemy")));

            foreach (var hit in hits)
            {
                var railgunExplosion = Object.Instantiate(ResourceProvider.RailgunExplosion);
                railgunExplosion.position = hit.point;

                // NOTE: in future need to get weapon and non/weapon class, and hit might instead come from an explosion
                railgunExplosion.transform.GetComponent<EnemyBase>().Hit(GameController.PlayerRailgunDamage);
            }
        }

        private void Restart()
        {
            _elapsed = 0.0f;
        }
    }
}
