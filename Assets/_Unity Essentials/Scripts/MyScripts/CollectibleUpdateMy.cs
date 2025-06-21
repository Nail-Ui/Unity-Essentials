using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics; //TypeHandling için gerekiyor.

public class CollectibleUpdateMy : MonoBehaviour
{
    private TextMeshProUGUI _collectibleText;


    private void Start()
    {
        _collectibleText = GetComponent<TextMeshProUGUI>();

        if (_collectibleText == null)
        {
            Debug.Log("CollectibleUpdateMy script requires a TextMeshProUGUI component on the same GameObject");
            return;
        }
        UpdateCollectibleDisplay();
    }

    private void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int _totalCollectibles = 0;

        Type _collectibleType = Type.GetType("Collectible8BonusScene");
        if (_collectibleType != null)
        {
            _totalCollectibles += UnityEngine.Object.FindObjectsByType(_collectibleType, FindObjectsSortMode.None).Length;
            //FindObjectsByType(_collectibleType, FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;
        }

        _collectibleText.text = $"Collectibles Remaining: {_totalCollectibles}";
    }


}
