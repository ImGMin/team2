using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item" , menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public Image _UI_ChartA;
    public string _chartName;
    
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
