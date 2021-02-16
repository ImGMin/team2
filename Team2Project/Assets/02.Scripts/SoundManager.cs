using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour

{
    static public SoundManager instance;
    // Start is called before the first frame update

    void Awake()

    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public AudioSource[] audioSourcesEffects;
    public AudioSource audioSourceBgm;

    public string[] playSoundName;

    
    public Sound[] effctSounds;
    public Sound[] bgmSounds;
    
    public void PlaySE(string _name)
    {
        for(int i = 0; i < effctSounds.Length; i++)
        {
            if(_name == effctSounds[i].name)
            {
                for(int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    if(!audioSourcesEffects[j].isPlaying)
                    {
                        playSoundName[j] = effctSounds[i].name;
                        audioSourcesEffects[j].clip = effctSounds[i].clip;
                        audioSourcesEffects[j].Play();
                        return;
                    }
                }    
            }
        }    
    }
    public void StopAIISE()
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].Stop();
        }
    }
    public void StopSE(string _name)
    {
        for ( int i = 0; i < audioSourcesEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourcesEffects[i].Stop();
                return;
            }
        }
            }
    void OnEnable()
    {
        
    }
    void Start()
        
    {
        playSoundName = new string[audioSourcesEffects.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
