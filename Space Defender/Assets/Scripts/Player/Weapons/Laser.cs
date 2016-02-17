using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour
    {
        private float _elapsed;
        private const float Lifetime = 0.8f;
        private const float StartWidth = 0.1f;

        void Update ()
        {
            _elapsed += Time.deltaTime;

            var ratio = _elapsed/Lifetime;
            var newWidth = ((-ratio) + 1f)*StartWidth;
            GetComponent<LineRenderer>().SetWidth(newWidth, newWidth);
        }

        public void SetLaserPositionsAndFire(Vector3 start, Vector3 end)
        {
            GetComponent<LineRenderer>().SetPosition(0, start);
            GetComponent<LineRenderer>().SetPosition(1, end);

            Destroy(gameObject, Lifetime);
        }
    }
}
