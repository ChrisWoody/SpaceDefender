using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Player.Weapon_Modules;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class WeaponController : MonoBehaviour
    {
        /// <summary>
        /// Key is number on keyboard.
        /// </summary>
        private IDictionary<int, WeaponModuleBase> _weaponModules;

        private WeaponModuleBase SelectedWeapon
        {
            get { return _weaponModules[_selectedWeaponNumber]; }
        }

        private int _selectedWeaponNumber = 1;

        private bool _paused;
        private bool _frameAfterPaused;

        void Start()
        {
            _weaponModules = new Dictionary<int, WeaponModuleBase>
            {
                {1, new LaserModule()},

                {3, new RailgunModule()},
            };

            //UiController.Pausing += OnPausing;
            //UiController.Resuming += OnResuming;

            //UiController.SetSelectedWeapon(SelectedWeapon.Name);
        }

        void Update()
        {
            if (_paused)
                return;

            if (_frameAfterPaused) // after resuming, the mouse button up occurs TODO: havent check this yet in new code...
            {
                _frameAfterPaused = false;
                return;
            }

            UpdateSelectedWeapon();

            foreach (var weaponModule in _weaponModules.Values)
                weaponModule.OnAlwaysUpdate();

            SelectedWeapon.OnSelectedUpdate();

            if (Input.GetMouseButtonDown(0))
                SelectedWeapon.OnLeftMouseButtonDown();
            if (Input.GetMouseButton(0))
                SelectedWeapon.OnLeftMouseButton();
            if (Input.GetMouseButtonUp(0))
                SelectedWeapon.OnLeftMouseButtonUp();

            if (Input.GetMouseButtonDown(1))
                SelectedWeapon.OnRightMouseButtonDown();
            if (Input.GetMouseButton(1))
                SelectedWeapon.OnRightMouseButton();
            if (Input.GetMouseButtonUp(1))
                SelectedWeapon.OnRightMouseButtonUp();
        }

        private void UpdateSelectedWeapon()
        {
            var previousWeaponNumber = _selectedWeaponNumber;

            foreach (var numberKeyCode in PlayerHelper.NumberKeyCodes.Where(Input.GetKeyDown))
                _selectedWeaponNumber = int.Parse(numberKeyCode.ToString().Substring(5, 1));

            if (previousWeaponNumber == _selectedWeaponNumber || !_weaponModules.ContainsKey(_selectedWeaponNumber))
            {
                _selectedWeaponNumber = previousWeaponNumber;
                return;
            }

            _weaponModules[previousWeaponNumber].OnUnselected();
            _weaponModules[_selectedWeaponNumber].OnSelected();

            //UiController.SetSelectedWeapon(SelectedWeapon.Name);
        }

        //private void OnPausing()
        //{
        //    _paused = true;
        //}

        //private void OnResuming()
        //{
        //    _paused = false;
        //    _frameAfterPaused = true;
        //}
    }

    public static class PlayerHelper
    {
        public static readonly KeyCode[] NumberKeyCodes =
        {
            KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4
        };
    }
}
