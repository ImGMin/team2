using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour ,   IPointerExitHandler , IPointerClickHandler, IPointerEnterHandler
{


    public Image _UI_ChartA;
    public Item item;
    public int itemCount;
    public Image itemImage;

    

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    

    

    private ItemEffectDatabase theItemEffectDatabase;
    private Rect baseRect;
    private InputNumber theInputNumber;
    private SlotToolTip theSlotToolTip;

   

    public void ShowToolTip(Item _item)
    {
        theSlotToolTip.ShowToolTip(_item, transform.position);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }
    void Start()
    
        
    {
        
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();
        baseRect = transform.parent.GetComponent<RectTransform>().rect;
        theInputNumber = FindObjectOfType<InputNumber>();
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        item._UI_ChartA = GameObject.Find("단서").transform.Find(item._chartName).GetComponent<Image>();
        if(item._UI_ChartA == null)
        {
            Debug.LogError("Null UI Chart");
        }

        if (item.itemType != Item.ItemType.Clue)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
            
        }
        SetColor(1);

    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        
        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }


    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            theItemEffectDatabase.ShowToolTop(item, transform.position);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
            theItemEffectDatabase.HideToolTip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                if(item.itemType == Item.ItemType.Clue)
                {

                     if(item._UI_ChartA.gameObject.activeSelf == false)
                    {
                        item._UI_ChartA.gameObject.SetActive(true);
                        
                    }
                   

                }
                else
                {
                    Debug.Log(item.itemName + " 를 사용했습니다.");
                    theItemEffectDatabase.UseItem(item);
                    if(item.itemType == Item.ItemType.Tool) //도구
                    SetSlotCount(-1);
                    GameObject.Find("물마시는소리").GetComponent<AudioSource>().Play();

                    
                }
                
            }
            

        }    
    }

   
   

    

   
    
}
    // Start is called before the first frame update
    
