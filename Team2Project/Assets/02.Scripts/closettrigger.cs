using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closettrigger : MonoBehaviour
{
    public strangeClock stclock;
    public Clock normalclock;
    public GameObject strangeclock;
    public int clockonce = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (clockonce == 0)
        {
            Debug.Log("시계가 두배로 빨라집니다");
            strangeclock = transform.Find("strangeclock").gameObject;
            strangeclock.gameObject.SetActive(true);
            normalclock.clockSpeed = 30.0f;
            clockonce = 1;
        }
    }
}
