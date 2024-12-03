using System;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour
{
    public InventoryItem item; // Ítem asociado a este UI
    public bool isConsumed; // Indica si el ítem fue consumido
    public static event Action<string> OnItemConsumed;

    public void OnPointerClick()
    {
        gameObject.SetActive(false);
        isConsumed = true;
        OnItemConsumed?.Invoke(item.itemName + " has been consumed!");
    }
}
