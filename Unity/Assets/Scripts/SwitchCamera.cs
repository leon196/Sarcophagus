using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

    public int timer = 0;
    public int maxTimer;

    public float cooldown;
    public bool loopCamera = true;

    public GameObject[] cameras;
    public GameObject currentCamera;
    int currentCameraNumber = 1;
    int maxCameraNumber;


	// Use this for initialization
	void Start ()
    {
        cameras = GameObject.FindGameObjectsWithTag("camera");
        maxCameraNumber = cameras.Length;
        for(int i = maxCameraNumber - 1; i > 0; i --)
        {
            cameras[i].SetActive(false); 
        }
        StartCoroutine(ReplaceCam());
    }

    // Update is called once per frame
    void Update () {

        //timer++;
        //if (timer >= maxTimer)
        //{
            
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplaceCam();
        }
	}

    IEnumerator ChangeCam()
    {
        currentCameraNumber++;
            cameras[currentCameraNumber].SetActive(true);
            for (int i = maxCameraNumber - 1; i > 1; i--)
            {
                if (i != currentCameraNumber)
                {
                    cameras[i].SetActive(false);
                }
            }
            Debug.Log("change !");
            currentCamera = cameras[currentCameraNumber];
            yield return new WaitForSeconds(cooldown);
    }

    IEnumerator ReplaceCam()
    {
        while (loopCamera)
        {
            currentCameraNumber++;
            if (currentCameraNumber > maxCameraNumber)
            {
                currentCameraNumber = 1;
            }
            for (int i = maxCameraNumber - 1; i > -1; i--)
            {
                cameras[i].SetActive(false);
            }
            cameras[currentCameraNumber - 1].SetActive(true);

            currentCamera = cameras[currentCameraNumber - 1];
            yield return new WaitForSeconds(cooldown);
            cooldown = Random.Range(0.01f, 0.5f);
        }
        yield return null;
    }
}
