using UnityEngine;

public class BallBouncingAudio : MonoBehaviour
{
    private AudioSource _ballBouncingAudio;
    private AudioSource _ballHittingTowerAudio;

    [SerializeField] AudioClip _bouncingClip;
    [SerializeField] AudioClip _hittingTowerClip;
     

    private void Start()
    {
        // Bounce sesi için AudioSource oluştur
        _ballBouncingAudio = gameObject.AddComponent<AudioSource>();
        _ballBouncingAudio.clip = _bouncingClip;
        _ballBouncingAudio.volume = 0.05f;
        _ballBouncingAudio.playOnAwake = false;

        // Block çarpması için AudioSource oluştur
        _ballHittingTowerAudio = gameObject.AddComponent<AudioSource>();
        _ballHittingTowerAudio.clip = _hittingTowerClip;
        _ballHittingTowerAudio.volume = 0.05f;
        _ballBouncingAudio.playOnAwake = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")&& !_ballBouncingAudio.isPlaying)
        {
            _ballBouncingAudio.Play();
            
        }

        if (collision.gameObject.CompareTag("Tower"))
        {
           _ballHittingTowerAudio.Play();
        }
    }

}
