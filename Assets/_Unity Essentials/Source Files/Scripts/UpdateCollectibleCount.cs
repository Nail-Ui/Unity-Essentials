using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component
    [SerializeField] private AudioSource _winAudioSource;
    [SerializeField] private GameObject _winVFX;
    [SerializeField] private Transform _winVFXSpawnPoint;

    private bool _hasWon = false;

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Update the collectible count display

        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";

        if (totalCollectibles == 0 && !_hasWon)
        {
            _hasWon = true;

            if (_winAudioSource != null)
            {
              _winAudioSource.Play();  
            }
            if (_winVFX != null && _winVFXSpawnPoint != null)
            {  
              Instantiate(_winVFX, _winVFXSpawnPoint.position, _winVFXSpawnPoint.rotation);
            }

        }

    }
}
