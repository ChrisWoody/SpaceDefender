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
            Health -= damage;
            HitWithCurrentHealth.SafeCallDelegate(Health);
        }

        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnUpdate();

        public event FloatDelegate HitWithCurrentHealth;
    }
}