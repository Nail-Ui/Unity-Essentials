using UnityEngine;

public class DirtCollectingAudio : MonoBehaviour
{
    private AudioClip _dirtCollectingAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& _dirtCollectingAudio != null)
        {
           AudioSource.PlayClipAtPoint(_dirtCollectingAudio, transform.position);
        }
    }

}
