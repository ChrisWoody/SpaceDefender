using System.Linq;
using Assets.Scripts.Game;
using Assets.Scripts.Player.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player.Weapon_Modules
{
    public class MissileBarrageModule : WeaponModuleBase
    {
        public override string Name
        {
            get { return "Missile Barrage"; }
        }

        private float _elapsed;
        private const float FireRate = 2f;

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
            FireMissileBarrage();
        }

        private void FireMissileBarrage()
        {
            var offsets = new float[] {-2f, -1.5f, -1f, 1f, 1.5f, 2f};

            for (var i = 0; i < offsets.Length; i++)
            {
                var offset = (Vector3.Cross(CameraForward, PlayerCamera.up) * offsets[i]) - (PlayerCamera.up * 0.5f);
                var missile = Object.Instantiate(ResourceProvider.Missile);
                missile.position = CameraPosition + offset;
                missile.up = CameraForward;
                missile.parent = PlayerCamera.transform;
                missile.GetComponent<Missile>().FireWithOrder(Mathf.Abs(offsets[i]));
            }
        }

        private void Restart()
        {
            _elapsed = 0.0f;
        }
    }
}
