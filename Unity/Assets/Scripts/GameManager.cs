﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Camera myCamera;

    public MoveCamera cameraScript;
    public SoundManager soundScript;
    public EffectZapping zapScript;

    public float timePressed = 0;
    public float timeToPress;
    public bool isStarted = false;

    // Use this for initialization
    void Awake ()
    {
	    if (instance == null)
        {
            instance = this;
        }

        cameraScript = GetComponent<MoveCamera>();
        soundScript = myCamera.GetComponent<SoundManager>();
        zapScript = myCamera.GetComponent<EffectZapping>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isStarted)
            {
                //soundScript.enabled = false;
                isStarted = false;
                soundScript.Ending();
                Debug.Log("lol");
                Camera.main.transform.position = Vector3.one * 9000f;
                Camera.main.transform.LookAt(Camera.main.transform.position + Vector3.one);
                zapScript.Stop();
            }
            else
            {
                timePressed = 0;
                soundScript.source.volume = 0.1f;
            }

        }
        if (Input.GetKey(KeyCode.Space) && !isStarted)
        {
            timePressed = timePressed + Time.deltaTime;
            soundScript.source.volume = Mathf.Lerp(0.1f, 0.5f, timePressed/timeToPress);
            if (timePressed > timeToPress)
            {
                isStarted = true;
                zapScript.BeginGame();
            }
        }
	}
}
