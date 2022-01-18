using UnityEngine;

namespace CollisionSample
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform target;

        private void LateUpdate()
        {
            transform.position = target.position;
        }

        void OnGUI()
        {
            for (int i = (int)KeyCode.Joystick1Button0; i <= (int)KeyCode.Joystick2Button19; i++)
            {
                if (Input.GetKey((KeyCode)i)) GUILayout.Label(((KeyCode)i).ToString() + " is pressed.");
            }
        }
    }
}