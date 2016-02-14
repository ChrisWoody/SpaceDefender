using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof (Rigidbody))]
    public class Player : MonoBehaviour
    {
        public float Speed = 75.0f;

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

        private void Start()
        {

        }

        private void Update()
        {

        }
    }
}
