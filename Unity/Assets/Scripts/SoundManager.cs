using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> soundsShort = new List<AudioClip>();
    public List<AudioClip> soundsLong = new List<AudioClip>();

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
                    }
                }
                if (soundsLong.Count <= 0 && soundsShort.Count > 0)
                {
                    soundsShort.RemoveAt(0);
                    if (soundsShort.Count > 0)
                    {
                        source.clip = soundsShort[0];
                    }
                }
                source.Play();
                source.timeSamples = lastTimeSample;
            }
        }
    }
}
//using UnityEngine;
//using System.Collections;

//public class SoundManager : MonoBehaviour
//{

//    public AudioSource source;

//    [Range(0, 1)]
//    public float soundPosition;
//    public int pulseNumber;

//    public int lastPulse;


//    Use this for initialization
//    void Start()
//    {
//        source = GetComponent<AudioSource>();
//        source.Play();
//    }

//    Update is called once per frame
//    void Update()
//    {
//        soundPosition = (float)source.timeSamples / (float)source.clip.samples;

//        lastPulse = pulseNumber;

//        if (soundPosition)
//            pulseNumber = (int)Mathf.Floor(soundPosition * 8f);

//        if (pulseNumber != lastPulse)
//        {
//            GameManager.instance.cameraScript.ChangeCamera();
//            GameManager.instance.zapScript.Zap();
//        }
//    }
//}
