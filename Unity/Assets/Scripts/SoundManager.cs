using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource source;

    [Range(0, 1)]
    public float soundPosition;
    public int pulseNumber;

    public int lastPulse;


    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        source.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        soundPosition = (float) source.timeSamples / (float) source.clip.samples;

        lastPulse = pulseNumber;

        //if (soundPosition )
        pulseNumber = (int)Mathf.Floor(soundPosition *  8f);

        if (pulseNumber != lastPulse)
        {
            GameManager.instance.cameraScript.ChangeCamera();
            GameManager.instance.zapScript.Zap();
        }
    }
}
