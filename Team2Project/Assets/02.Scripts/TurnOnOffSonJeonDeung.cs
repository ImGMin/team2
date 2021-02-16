using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffSonJeonDeung : MonoBehaviour
{
    public Flashlight_PRO flashlight;

    private void Update()
    {
        if (GameManager.canPlayerMove)
        {
            TurnOnFlashlight();
        }
    }
    private void TurnOnFlashlight()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flashlight.Switch();
            Debug.Log("Son Jeon Deung");
        }
    }
}
