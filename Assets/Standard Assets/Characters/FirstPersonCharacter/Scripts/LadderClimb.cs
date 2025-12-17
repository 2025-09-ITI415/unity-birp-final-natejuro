using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class LadderClimb : MonoBehaviour
    {
        public float climbSpeed = 3.5f;

        public bool IsClimbing { get; private set; }

        public float ClimbInput => Input.GetAxis("Vertical");

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ladder"))
                IsClimbing = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ladder"))
                IsClimbing = false;
        }
    }
}