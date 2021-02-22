using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{

    // 체력
    [SerializeField]
    private int hp;
    private int currentHp;

    [SerializeField]
    private int hpDecreaseTime;
    private int currentHpDecreaseTime;
    // 독
    [SerializeField]
    private int poison;
    private int currentPoison;

    [SerializeField]
    private int poisonDecreaseTime;
    private int currentPoisonDecreaseTime;

    // 필요한 이미지
    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, POISON = 1;

    
    // Use this for initialization
    void Start()
    {
        currentHp = hp;
        currentPoison = poison;
        
    }

    // Update is called once per frame
    void Update()
    {
        Poison();
        GaugeUpdate();
    }


   public void GameOver()
    {
        if(currentHp <= 30)
        {
            print("HP : " + currentHp);
           LoadingSceneManager.LoadScene("Fail");
            Debug.Log("사망하였습니다.");
        }
    }

    private void Poison()
    {
        if (currentPoison > 0)
        {
            if (currentPoisonDecreaseTime <= poisonDecreaseTime)
                currentPoisonDecreaseTime++;
            else
            {
                currentPoison--;
                currentPoisonDecreaseTime = 0;
            }
        }


        if (currentPoison > 0)
        {
            if (currentHpDecreaseTime <= hpDecreaseTime)
                currentHpDecreaseTime++;
            else
            {
                currentHp--;
                currentHpDecreaseTime = 0;
            }
        }
    }

    

    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHp / hp;
        
        images_Gauge[POISON].fillAmount = (float)currentPoison / poison;
      
    }

    public void IncreaseHP(int _count)
    {
        if (currentHp + _count < hp)
            currentHp += _count;
        else
            currentHp = hp;

    }
    public void DecreaseHP(int _count)
    {
        if (currentHp - _count < 0)
            currentHp = 0;
        else
            currentHp -= _count;
        
    }
    public void DecreasePOISON(int _count)
    {
        if (currentPoison - _count < 0)
            currentPoison = 0;
        else
            currentPoison -= _count;
    }

}
