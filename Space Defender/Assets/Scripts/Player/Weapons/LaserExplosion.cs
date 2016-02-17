using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    public class LaserExplosion : MonoBehaviour
    {
        void Update ()
        {
            Destroy(gameObject, 1f);
        }
    }
}
