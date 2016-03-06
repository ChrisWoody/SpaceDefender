using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyTurretLaser : EnemyWeaponBase
    {
        private const float Speed = 60f;

        protected override void OnStart() {}
        protected override void OnUpdate() {}

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

        public void Fire(Vector3 pos, Vector3 dir)
        {
            transform.position = pos;
            transform.up = dir;
            transform.GetComponent<Rigidbody>().velocity = dir*Speed;
            Destroy(gameObject, 60f);
        }
    }
}