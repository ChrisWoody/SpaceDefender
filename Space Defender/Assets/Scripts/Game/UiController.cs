using UnityEngine;

namespace Assets.Scripts.Game
{
    public class UiController : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        void Start()
        {
            LockCursor();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                    LockCursor();
                else
                    UnlockCursor();
            }
        }

        private static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
