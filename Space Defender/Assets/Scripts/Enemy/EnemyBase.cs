using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public float Health { get; protected set; }

        protected Transform Player { get; private set; }

        void Awake()
        {
            Player = FindObjectOfType<Player.Player>().transform;
            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        void Update()
        {
            OnUpdate();
        }

        public void Hit(float damage)
        {
            if (IsEnemyShip) return;

            Health -= damage;

            if (Health <= 0f)
            {
                FireDeathEvent();
                Destroy(gameObject);
            }
        }

        protected virtual bool IsEnemyShip { get { return false; } }
        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnUpdate();

        public event VoidDelegate Death;

        protected void FireDeathEvent()
        {
            Death.SafeCallDelegate();
        }
    }
}