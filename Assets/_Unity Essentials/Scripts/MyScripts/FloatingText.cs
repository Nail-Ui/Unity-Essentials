using UnityEngine;

public class FloatingText : MonoBehaviour
{
    //Yazı objenin kendisiyle beraber dönüyor fakat aynı anda main cameraya doğru baktığı için ufak bir sallantı oluşuyor, çözmeyi unutma.
    //Transform rotate olan bir objenin değil onun parent i na script i atarsak bu sorun çözülmüş oluyor
    [SerializeField] private Camera _mainCamera;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (_mainCamera != null)
        {
            transform.forward = _mainCamera.transform.forward;    
        }
    }
}
