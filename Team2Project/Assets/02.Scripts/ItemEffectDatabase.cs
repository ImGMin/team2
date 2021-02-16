using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // 아이템의 이름. (키값)
    [Tooltip("HP, POISON 만 가능합니다")]
    public string[] part; // 부위.
    public int[] num; // 수치.
}

public class ItemEffectDatabase : MonoBehaviour
{

    [SerializeField]
    private ItemEffect[] itemEffects;

    //필요한 컴포넌트
    [SerializeField]
    private StatusController thePlayerStatus;
    
    [SerializeField]
    private SlotToolTip theSlotToolTip;

    private const string HP = "HP", POISON = "POISON";

    public void ShowToolTop(Item _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

    public void UseItem(Item _item)
    {

        if (_item.itemType == Item.ItemType.Tool)
        {

            for (int x = 0; x < itemEffects.Length; x++)
            {

                if (itemEffects[x].itemName == _item.itemName)
                {

                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {

                        switch (itemEffects[x].part[y])
                        {
                            case HP:
                                thePlayerStatus.IncreaseHP(itemEffects[x].num[y]);
                                break;
                            case POISON:
                                thePlayerStatus.DecreasePOISON(itemEffects[x].num[y]);
                                break;
                            
                                
                            default:
                               
                                break;
                        }
                        Debug.Log(_item.itemName + " 을 사용했습니다");

                    }
                    return;
                }


            }
            Debug.Log("ItemEffectDatabase에 일치하는 itemName 없습니다");
        }

    }
}
