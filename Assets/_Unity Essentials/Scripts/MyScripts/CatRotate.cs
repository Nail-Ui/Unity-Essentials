using UnityEngine;

public class CatRotate : MonoBehaviour
{
    [SerializeField] private float _catTurnSpeed;
        void Update()
    {
        transform.Rotate(0f, _catTurnSpeed, 0f * Time.deltaTime);
    }
}
