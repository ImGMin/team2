using UnityEngine;
using System.Collections;

public class strangeClock : MonoBehaviour
{

    public Clock normalclock;
    public Transform Player;
    public AudioSource breaksound;
    [SerializeField] GameObject strange;
    

    void Start()
    {
    }

    private void Update()
    {
        trashclock();
    }

    public void trashclock()
    {
        Player = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist < 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("시계없애기");
                strange.SetActive(false); 
                normalclock.clockSpeed = 12.0f;
                if (breaksound != null)
                {
                    breaksound.Play();
                }
            }
        }
    }
}
