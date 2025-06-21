using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _doorAnimator != null)
        {
            _doorAnimator.SetBool("PlayerProximity0", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _doorAnimator != null)
        {
           _doorAnimator.SetBool("PlayerProximity0", false);
        }
    }

}
