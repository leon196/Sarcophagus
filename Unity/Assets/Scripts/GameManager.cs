using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Camera myCamera;

    public MoveCamera cameraScript;
    public SoundManager soundScript;
    public EffectZapping zapScript;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundScript.enabled = false;
            Camera.main.transform.position = Vector3.one * 9000f;
            Camera.main.transform.LookAt(Camera.main.transform.position + Vector3.one);
            zapScript.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            isStarted = true;
            zapScript.BeginGame();
        }
	}
}
