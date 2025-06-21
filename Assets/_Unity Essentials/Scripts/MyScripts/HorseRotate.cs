using UnityEngine;

public class HorseRotate : MonoBehaviour
{
    [SerializeField] private float _horseTurnSpeed = 120f;

    private void Update()
    {
        transform.Rotate(0f, _horseTurnSpeed, 0f * Time.fixedDeltaTime);
    }
}
