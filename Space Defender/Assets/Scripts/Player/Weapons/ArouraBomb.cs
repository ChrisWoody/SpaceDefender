using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class ArouraBomb : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag.Contains("Enemy"))
            {
                other.transform.GetComponent<EnemyBase>().Hit(GameController.PlayerArouraBombDamage);

                // in future will get component, and explosion will cause damage to other enemy bits

                var arouraBombExplosion = Instantiate(ResourceProvider.ArouraBombExplosion);
                arouraBombExplosion.position = transform.position;

                Destroy(gameObject);
            }
        }

        public void Fire(Vector3 dir, Vector3 velocity)
        {
            transform.up = dir;
            GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}