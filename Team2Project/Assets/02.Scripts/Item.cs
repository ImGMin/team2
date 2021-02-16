using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item" , menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public enum ItemType
    {
        Clue,
        Tool,
        Key
    }

   

        public bool Use()
        {
            return false;
        }
    }
