using UnityEngine;


namespace KMK
{
    public class LockCursor : MonoBehaviour
    {
        public bool lockCursor = false;


        /**/


        private void Awake()
        {
            if(lockCursor) Cursor.lockState = CursorLockMode.Locked;
        }
    }
}