using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public abstract class EnemyWeaponBase : MonoBehaviour
    {
        protected Transform Player { get; private set; }

        void Awake()
        {
            Player = FindObjectOfType<Player.Player>().transform;
        }

        void Start ()
        {
            OnStart();
        }

        void Update ()
        {
            OnUpdate();
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate();
    }
}