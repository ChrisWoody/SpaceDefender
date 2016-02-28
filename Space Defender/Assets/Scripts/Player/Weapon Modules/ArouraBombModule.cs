using Assets.Scripts.Game;
using Assets.Scripts.Player.Weapons;
using UnityEngine;

namespace Assets.Scripts.Player.Weapon_Modules
{
    public class ArouraBombModule : WeaponModuleBase
    {
        public override string Name
        {
            get { return "Aroura Bomb"; }
        }

        private const float CanFireSpeed = 5f;
        private bool _canFire;

        private const float Cooldown = 2f; // probably 10 or mater later
        private float _cooldownElapsed;
        private bool _coolingDown;

        public override void OnAlwaysUpdate()
        {
            if (_coolingDown)
            {
                _cooldownElapsed += Time.deltaTime;
                if (_cooldownElapsed >= Cooldown)
                {
                    _coolingDown = false;
                    _cooldownElapsed = 0f;
                }
            }
        }

        public override void OnSelectedUpdate()
        {
            if (_coolingDown) return;

            var speed = Player.GetComponent<Rigidbody>().velocity.magnitude;
            Debug.Log(speed);

            _canFire = speed > CanFireSpeed;
        }

        public override void OnLeftMouseButton()
        {
            if (!_canFire) return;

            _coolingDown = true;
            _canFire = false;

            FireArouraBomb();
        }

        private void FireArouraBomb()
        {
            var arouraBomb = Object.Instantiate(ResourceProvider.ArouraBomb);
            arouraBomb.position = CameraPosition - (PlayerCamera.up * 1.25f);
            arouraBomb.GetComponent<ArouraBomb>().Fire(CameraForward, Player.GetComponent<Rigidbody>().velocity);
        }
    }
}