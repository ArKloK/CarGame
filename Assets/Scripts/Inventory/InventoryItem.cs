using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CarGame/NewInventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
}