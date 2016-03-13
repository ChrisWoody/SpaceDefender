using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    [RequireComponent(typeof(Collider))]
    public class EnemyLanceRound : EnemyWeaponBase
    {
        protected override void OnStart() {}

        protected override void OnUpdate() {}

        public void Fire(Vector3 pos, Vector3 dir)
        {
            Destroy(gameObject, 1f);

            transform.position = pos;
            transform.up = dir;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                // ATM we'll just do one hit against the player, could try a constant damage in the future
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}