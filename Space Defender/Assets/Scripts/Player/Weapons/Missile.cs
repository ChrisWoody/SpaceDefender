using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Missile : MonoBehaviour
    {
        private const float Speed = 30f;

        private float _elapsed;
        private const float Lifetime = 0.8f;

        private const float FireOffset = 0.3f;
        private float _fireTime;
        private bool _fired;

        void Awake()
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        void Update ()
        {
            if (!_fired)
                _elapsed += Time.deltaTime;

            if (!_fired && _elapsed >= _fireTime)
            {
                _fired = true;

                transform.parent = null;

                GetComponent<Renderer>().enabled = true;
                GetComponent<Collider>().enabled = true;

                GetComponent<Rigidbody>().velocity = transform.up * Speed;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag.Contains("Enemy"))
            {
                other.transform.GetComponent<EnemyBase>().Hit(GameController.PlayerMissileDamage);

                var missileExplosion = Instantiate(ResourceProvider.MissileExplosion);
                missileExplosion.position = transform.position;

                Destroy(gameObject);
            }
        }

        public void FireWithOrder(float delay)
        {
            _fireTime = delay*FireOffset;

            Destroy(gameObject, 60f);
        }
    }
}
