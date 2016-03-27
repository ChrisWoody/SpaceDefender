using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public abstract class EnemyWeaponBase : MonoBehaviour
    {
        public float Health { get; protected set; }

        protected Transform Player { get; private set; }

        void Awake()
        {
            Player = FindObjectOfType<Player.Player>().transform;
            OnAwake();
        }

        void Start ()
        {
            OnStart();
        }

        void Update ()
        {
            OnUpdate();
        }

        public void Hit(float damage)
        {
            if (IsWeapon())
                return;

            Health -= damage;
            HitWithCurrentHealth.SafeCallDelegate(Health);
        }

        protected virtual bool IsWeapon() // This has raised something that should probably be fixed, as we cant hit enemy weapon rounds, we can only hit enemy turrets/body
        {
            return false;
        }
        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnUpdate();

        public event FloatDelegate HitWithCurrentHealth;
    }
}