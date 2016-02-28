using UnityEngine;

namespace Assets.Scripts.Player.Weapons
{
    public class MissileExplosion : MonoBehaviour
    {
        void Update()
        {
            Destroy(gameObject, 1f);
        }
    }
}