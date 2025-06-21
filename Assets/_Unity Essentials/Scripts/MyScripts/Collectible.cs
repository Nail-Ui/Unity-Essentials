using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float _dirtTurnSpeed;
    [SerializeField] private GameObject _onCollectEffect;


    private AudioSource _dirtAudioSource;

    private void Start()
    {
        _dirtAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0f, _dirtTurnSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (_dirtAudioSource != null && !_dirtAudioSource.isPlaying)
            {
                _dirtAudioSource.Play();
            }
            // Instantiate the particle effect (Hangi objeyi, hangi pozisyonda, hangi rotasyonda);
            Instantiate(_onCollectEffect, transform.position, transform.rotation);

            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            // Destroy the collectible
            Destroy(gameObject, _dirtAudioSource.clip.length);
        }
    }

}
