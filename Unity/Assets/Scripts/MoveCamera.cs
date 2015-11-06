using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    float cooldown;
    public float cdMin;
    public float cdMax;


    public bool loopCamera = true;

    public Camera myCamera;

    public GameObject[] cameraTransforms;
    public GameObject currentTransform;
    public int currentTransformNumber = 0;
    int maxTransformNumber;


    // Use this for initialization
    void Start()
    {
        cameraTransforms = GameObject.FindGameObjectsWithTag("transform");
        maxTransformNumber = cameraTransforms.Length;

        myCamera.transform.position = cameraTransforms[currentTransformNumber].transform.position;
        myCamera.transform.rotation = cameraTransforms[currentTransformNumber].transform.rotation;

        StartCoroutine(ReplaceCam());
    }

    // Update is called once per frame
    void Update()
    {

        //timer++;
        //if (timer >= maxTimer)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplaceCam();
        }
    }

    IEnumerator ReplaceCam()
    {
        while (loopCamera)
        {
            currentTransformNumber++;

            if (currentTransformNumber > maxTransformNumber - 1)
            {
                currentTransformNumber = 0;
            }

            myCamera.transform.position = cameraTransforms[currentTransformNumber].transform.position;
            myCamera.transform.rotation = cameraTransforms[currentTransformNumber].transform.rotation;

            //currentTransform = cameraTransforms[currentTransformNumber - 1];
            yield return new WaitForSeconds(cooldown);
            cooldown = Random.Range(cdMin, cdMax);
        }
        yield return null;
    }
}
