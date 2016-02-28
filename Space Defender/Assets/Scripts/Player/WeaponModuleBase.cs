using UnityEngine;

namespace Assets.Scripts.Player
{
    public abstract class WeaponModuleBase
    {
        // TODO: look at adding 'cooldown' and 'charging' logic here, as each weapon module is using these.

        protected Transform PlayerCamera;
        protected Transform Player;

        protected Vector3 CameraPosition
        {
            get { return PlayerCamera.position; }
        }

        protected Vector3 CameraForward
        {
            get { return PlayerCamera.forward; }
        }

        protected WeaponModuleBase()
        {
            PlayerCamera = Camera.main.transform;
            Player = Object.FindObjectOfType<Player>().transform;
        }

        public abstract string Name { get; }

        protected bool IsSelected { get; private set; }

        public virtual void OnSelected()
        {
            IsSelected = true;
        }

        public virtual void OnUnselected()
        {
            IsSelected = false;
        }

        /// <summary>
        /// Called every frame only if weapon is selected.
        /// </summary>
        public virtual void OnSelectedUpdate() { }

        /// <summary>
        /// Called every frame regardless if selected or not. Useful for 'cooldown' logic.
        /// </summary>
        public virtual void OnAlwaysUpdate() { }

        public virtual void OnLeftMouseButtonDown() { }
        public virtual void OnLeftMouseButton() { }
        public virtual void OnLeftMouseButtonUp() { }

        public virtual void OnRightMouseButtonDown() { }
        public virtual void OnRightMouseButton() { }
        public virtual void OnRightMouseButtonUp() { }

        public virtual void OnPausing() { }
        public virtual void OnResuming() { }
    }
}