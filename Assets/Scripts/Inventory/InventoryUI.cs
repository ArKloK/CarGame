using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel del inventario (UI)
    public GameObject messagePanel; // Panel para mostrar mensajes breves
    public TextMeshProUGUI messageText; // Texto para mostrar mensajes breves
    public List<GameObject> itemUIList; // Lista de ítems en el inventario (UI)

    void OnEnable()
    {
        InventoryItemUI.OnItemConsumed += DisplayMessage;
    }

    void OnDisable()
    {
        InventoryItemUI.OnItemConsumed -= DisplayMessage;
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        if (inventoryPanel.activeSelf)
        {
            UpdateInventoryUI();
        }
    }

    public void UpdateInventoryUI()
    {
        foreach (GameObject itemUI in itemUIList)
        {
            if (!itemUI.GetComponent<InventoryItemUI>().isConsumed)
                itemUI.SetActive(true);
        }
    }

    public void DisplayMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
        CancelInvoke(nameof(ClearMessage));
        Invoke(nameof(ClearMessage), 2f); // Limpia el mensaje después de 2 segundos
    }

    void ClearMessage()
    {
        messagePanel.SetActive(false);
        messageText.text = "";
    }
}
