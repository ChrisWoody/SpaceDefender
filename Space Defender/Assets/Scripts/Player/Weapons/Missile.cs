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

        private const float FireOffset = 0.1f;
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
                // in future will get component

                // apply damage, or spawn explosion which does that
                Destroy(gameObject);
            }
        }

        public void FireWithOrder(int order) // should be 0-4
        {
            _fireTime = order*FireOffset;

            Destroy(gameObject, 60f);
        }
    }
}
