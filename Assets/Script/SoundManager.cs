using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{


    [SerializeField] List<AudioClip> Listsounds;
    Dictionary<string, AudioClip> dictAudioClip;
    [SerializeField] List<AudioSource> audioSource;
    public void PlaySound(string nameClip, int index)
    {
        if (!audioSource[index].isPlaying)
        {
            audioSource[index].clip = dictAudioClip[nameClip + UnityEngine.Random.Range(1, 5)];
            audioSource[index].Play();
        }
        else
        {
            index++;
            if (index < audioSource.Count)
            {
                PlaySound(nameClip, index);
            }
        }


    }
    void Start()
    {
        dictAudioClip = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in Listsounds)
        {
            dictAudioClip.Add(clip.name, clip);
        }
        PlaySound("hurt", 0);
    }
}
