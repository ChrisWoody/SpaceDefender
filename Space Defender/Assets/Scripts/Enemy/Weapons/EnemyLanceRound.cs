using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    [RequireComponent(typeof(Collider))]
    public class EnemyLanceRound : EnemyWeaponBase
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Player.GetComponent<Player.Player>().Hit(GameController.EnemyLanceDamage);

                GetComponent<Collider>().enabled = false;
            }
        }

        public void Fire(Vector3 pos, Vector3 dir)
        {
            Destroy(gameObject, 1f);

            transform.position = pos;
            transform.up = dir;
        }
    }
}