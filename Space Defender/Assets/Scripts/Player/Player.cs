using System.Linq;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof (Rigidbody))]
    public class Player : MonoBehaviour
    {
        public float Speed = 75.0f;

        public float Health { get; private set; }

        private bool _paused;

        void LateUpdate()
        {
            if (_paused)
                return;

            var speedCalc = Speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W)) AddForceInDirection(transform.forward, speedCalc);
            if (Input.GetKey(KeyCode.S)) AddForceInDirection(-transform.forward, speedCalc);
            if (Input.GetKey(KeyCode.A)) AddForceInDirection(-transform.right, speedCalc);
            if (Input.GetKey(KeyCode.D)) AddForceInDirection(transform.right, speedCalc);
        }

        private void AddForceInDirection(Vector3 dir, float speed)
        {
            GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Force);
        }

        private void Awake()
        {
            Assert.IsTrue(FindObjectsOfType<GameController>().Count() == 1,
                "Scene can only have 1 " + GetType().Name);

            Health = GameController.PlayerHealth;
        }

        public void Hit(float damage)
        {
            Health -= damage;
            UpdatePlayerAfterHit();
        }

        private void UpdatePlayerAfterHit()
        {
            HitWithCurrentHealth.SafeCallDelegate(Health);
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        public event FloatDelegate HitWithCurrentHealth;
    }
}
