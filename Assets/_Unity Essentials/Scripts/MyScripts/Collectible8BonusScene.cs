using UnityEngine;

public class Collectible8BonusScene : MonoBehaviour
{
    [SerializeField] private float _starRotationSpeed;

    private AudioSource _starCollectionSource;

    private void Start()
    {
        _starCollectionSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0f, _starRotationSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_starCollectionSource != null && !_starCollectionSource.isPlaying)
            {
                _starCollectionSource.Play();
            }

            GetComponent<Collider>().enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;

            Destroy(gameObject, _starCollectionSource.clip.length);
        }
    }
}
