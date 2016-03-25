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

        // Note for future. As a possible implementation could have this class subscribe to events fired on the player and enemy,
        // so even though player/enemy needs to call something when things happen, it would make this and game controller a bit simplier.
        // Its not end of the world if they need to explicity notify these, but there could be multiple things it has to call.
        // And becaues its cool.
    }
}
