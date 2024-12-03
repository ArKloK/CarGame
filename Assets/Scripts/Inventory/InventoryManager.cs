using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryUI inventoryPanel; // Panel del inventario (UI)

    // Update is called once per frame
    void Update()
    {
        // Abre o cierra el inventario al presionar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.ToggleInventory();
        }
    }
}
