using TMPro;
using UnityEngine;

public class AnimalInfoTrigger : MonoBehaviour
{
    #region Auto activate the billboard without pressing a key
    // [SerializeField] private GameObject infoTextObject;
    // [SerializeField] private Camera _mainCamera;
    // // [SerializeField] private TextMeshPro _infoTextHolder; //Necessary component for your text to follow the player
    // private bool _playerIsNear = false;


    // // private void LateUpdate() //If you want your text to face your player location all the time
    // // {
    // //     if (_mainCamera != null)
    // //     {
    // //         _infoTextHolder.transform.forward = _mainCamera.transform.forward;
    // //     }
    // // }


    // private void OnTriggerEnter(Collider other) //&& infoTextObject != null parantez içerisine alınarak kod satırı azaltılabilir.
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         _playerIsNear = true;
    //         if (infoTextObject != null)
    //         {
    //             infoTextObject.SetActive(true);
    //             //Debug.Log("Collider Entered");
    //         }
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         _playerIsNear = false;
    //         if (infoTextObject != null)
    //         {
    //             infoTextObject.SetActive(false);
    //             //Debug.Log("Collider Exitted");
    //         }
    //     }
    // }
    #endregion

    #region Pressing a button to activate/trigger billboard 
    // [SerializeField] private GameObject _infoTextObject;

    // private bool _playerIsNear = false;
    // private bool _infoIsVisible = false;

    // private void Start()  // When the game start checks the assigned object is active or not, manually deactivating the _infoTextObject is unnecessary
    // {
    //     if (_infoTextObject != null)
    //     {
    //         _infoTextObject.SetActive(false);
    //     }
    // }

    // private void Update()
    // {
    //     if (_playerIsNear && Input.GetKeyDown(KeyCode.E))
    //     {
    //         _infoIsVisible = !_infoIsVisible;
    //         _infoTextObject.SetActive(_infoIsVisible);
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         _playerIsNear = true;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         _playerIsNear = false;
    //         _infoIsVisible = false;
    //         _infoTextObject.SetActive(false);
    //     }
    // }
    #endregion

    [SerializeField] private GameObject _infoTextObject;
    [SerializeField] private AudioClip _infoSound;
    [SerializeField] private AudioSource _audioSource;
    private bool _playerIsNear = false;
    private bool _infoIsVisible = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogWarning("AudioSource not found on " + gameObject.name);
        }
    }

    private void Start()
    {

        if (_infoTextObject != null)
        {
            _infoTextObject.SetActive(false);
        }
        if (_audioSource != null && _infoSound != null)
        {
            _audioSource.clip = _infoSound;
            _audioSource.loop = true; //Bilgi penceresi açıkken sürekli oynar
        }
    }

    private void Update()
    {
        if (_playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            _infoIsVisible = !_infoIsVisible;
            if(_infoTextObject != null)
            {
                _infoTextObject.SetActive(_infoIsVisible);
            }
            if (_audioSource != null)
            {
                if (_infoIsVisible)
                {
                    _audioSource.Play();
                }
                else
                {
                    _audioSource.Stop();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsNear = false;
            _infoIsVisible = false;

            if (_infoTextObject != null)
            {
                _infoTextObject.SetActive(false);
            }
            if (_audioSource != null)
            {
                _audioSource.Stop();
            }
        }
    }
}
