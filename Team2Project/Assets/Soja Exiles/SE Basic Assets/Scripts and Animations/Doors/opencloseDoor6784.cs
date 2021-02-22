using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor6784 : MonoBehaviour
{

	public Animator openandclose1;
	public bool open;
	public Transform Player;
	public LockControl6784 _lock;
	public AudioSource audio;
	public AudioClip _openSound;
	public AudioClip _closeSound;


	void Start()
	{
		open = false;

		Player = GameObject.FindWithTag("Player").transform;
		audio = GetComponent<AudioSource>();

		if (Player == null)
		{
			Debug.LogError("플레이어 찾지 못함.");
		}

	}

	void OnMouseOver()
	{
		{
			if (Player)
			{
				float dist = Vector3.Distance(Player.position, transform.position);
				if (dist < 3)
				{
					if (open == false && _lock.isOpened == true)
					{
						if (Input.GetMouseButtonDown(0))
						{
							StartCoroutine(opening());
							audio.clip = _openSound;
							audio.Play();
						}
						else Debug.Log("문잠김 ");
					}
					else
					{
						if (open == true)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(closing());
								audio.clip = _closeSound;
								audio.Play();
							}
						}

					}

				}
			}

		}

	}

	IEnumerator opening()
	{
		print("you are opening the door");
		openandclose1.Play("Opening 1");
		open = true;
		yield return new WaitForSeconds(.5f);
	}

	IEnumerator closing()
	{
		print("you are closing the door");
		openandclose1.Play("Closing 1");
		open = false;
		yield return new WaitForSeconds(.5f);
	}


}

