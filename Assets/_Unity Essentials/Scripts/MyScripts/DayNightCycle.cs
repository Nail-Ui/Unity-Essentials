using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float _sunRotationSpeed;


    private void Update()
    {
        transform.Rotate(0f, _sunRotationSpeed, 0f * Time.fixedDeltaTime);
    }
}

