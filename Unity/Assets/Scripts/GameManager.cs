using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Camera myCamera;

    public MoveCamera cameraScript;
    public SoundManager soundScript;
    public EffectZapping zapScript;



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
	void Update () {
	
	}
}
