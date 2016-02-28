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
                // in future will get component

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