using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Camera myCamera;

    public MoveCamera cameraScript;
    public SoundManager soundScript;
    public EffectZapping zapScript;
    VideoPlayer videoPlayer;

    public float timePressed = 0;
    public float timeToPress;
    public bool isStarted = false;

    bool videoStart = false;

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
        videoPlayer = FindObjectOfType<VideoPlayer>();
    }
	
    void Start()
    {
        Sending.DoEffect("n");
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (isStarted)
            {
                //soundScript.enabled = false;
                isStarted = false;
                soundScript.Ending();
                Camera.main.transform.position = Vector3.one * 9000f;
                Camera.main.transform.LookAt(Camera.main.transform.position + Vector3.one);
                zapScript.Stop();
                myCamera.GetComponent<AudioSource>().enabled = false;
            }
            else
            {
                timePressed = 0;
                soundScript.source.volume = 0.1f;
            }
            Sending.DoEffect("n");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Sending.DoEffect("o");
        }
        if (Input.GetKey(KeyCode.LeftControl) && !isStarted)
        {
            if (!videoStart)
            {
                videoStart = true;
                videoPlayer.StartVideoForGame();
            }
            timePressed = timePressed + Time.deltaTime;
            myCamera.GetComponent<AudioSource>().enabled = true;
            soundScript.source.volume = Mathf.Lerp(0.1f, 0.5f, timePressed/timeToPress);
            if (timePressed > timeToPress)
            {
                isStarted = true;
                zapScript.BeginGame();
            }
        }
	}
}
