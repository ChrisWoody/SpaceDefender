using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    public class RailgunExplosion : MonoBehaviour
    {
        void Update()
        {
            Destroy(gameObject, 1f);
        }
    }
}