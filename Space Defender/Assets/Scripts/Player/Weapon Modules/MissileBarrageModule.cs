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
            var offsets = new float[] {-3, -2, -1, 1, 2, 3}; // items like -2, -1, 1, 2 etc

            for (var i = 0; i < offsets.Length; i++)
            {
                var offset = Vector3.Cross(CameraForward, PlayerCamera.up) * offsets[i];
                var missile = Object.Instantiate(ResourceProvider.Missile);
                missile.position = CameraPosition + offset;
                missile.up = CameraForward;
                missile.parent = PlayerCamera.transform;
                missile.GetComponent<Missile>().FireWithOrder(i);   
            }


            // will spawn 10 missile (5 either side), that will be told to fire after some small delay, getting larger the further it is
            // random implimentation, can give it an index (0-4) which will multiply that by some set delay, so they all fire consistently 

            // will need to be a child of component of the player, and when it fires it will remove that relationship
        }

        private void Restart()
        {
            _elapsed = 0.0f;
        }
    }
}
