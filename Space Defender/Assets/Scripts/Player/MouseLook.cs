using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof (Rigidbody))]
    public class MouseLook : MonoBehaviour
    {
        private bool _paused = false;

        void Update()
        {
            if (_paused)
                return;

            // TODO: improve this logic, just grabbed from a previous version. Has issue looking around after rotating Z

            var rotateZ = 0.0f;
            if (Input.GetKey(KeyCode.Q)) rotateZ += 1.25f;
            if (Input.GetKey(KeyCode.E)) rotateZ -= 1.25f;

            var currentAngle = GetComponent<Rigidbody>().rotation.eulerAngles;
            var newAngle = currentAngle + new Vector3(Input.GetAxis("Mouse Y") * -3.0f, Input.GetAxis("Mouse X") * 3.0f, rotateZ);
            GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(newAngle));
        }
    }
}
