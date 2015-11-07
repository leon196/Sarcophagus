using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> soundsShort = new List<AudioClip>();
    public List<AudioClip> soundsLong = new List<AudioClip>();

    public AudioClip endingSound;

    public int currentSound;


    [Range(0, 1)]
    public float soundPosition;
    public int pulseNumber;

    public int lastPulse;


    void Start ()
    {
        source = GetComponent<AudioSource>();
        source.clip = soundsLong[0];
        source.Play();
    }

    void Update()
    {
        if (GameManager.instance.isStarted)
        {
            int lastTimeSample = source.timeSamples;
            soundPosition = (float)source.timeSamples / (float)source.clip.samples;

            lastPulse = pulseNumber;

            if (soundsLong.Count > 0)
            {
                pulseNumber = (int)Mathf.Floor(soundPosition * 8f);
            }
            else
            {
                pulseNumber = (int)Mathf.Floor(soundPosition * 16f);
            }


            if (pulseNumber != lastPulse)
            {
                GameManager.instance.cameraScript.ChangeCamera();
                GameManager.instance.zapScript.Zap();
            }
            if (pulseNumber < lastPulse)
            {
                source.Stop();
                if (soundsLong.Count > 0)
                {
                    soundsLong.RemoveAt(0);
                    if (soundsLong.Count != 0)
                    {
                        source.clip = soundsLong[0];
                        source.volume += (source.volume / (soundsLong.Count + soundsShort.Count));
                    }
                }
                if (soundsLong.Count <= 0 && soundsShort.Count > 0)
                {
                    soundsShort.RemoveAt(0);
                    if (soundsShort.Count > 0)
                    {
                        source.clip = soundsShort[0];
                        source.volume += (source.volume / (soundsLong.Count + soundsShort.Count));
                    }
                }
                source.Play();
                source.timeSamples = lastTimeSample;
            }
        }
    }

    public void Ending()
    {
        source.Stop();
        source.clip = endingSound;
        source.Play();
    }
}