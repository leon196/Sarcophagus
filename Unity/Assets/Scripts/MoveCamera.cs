using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
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
    }

    public void ChangeCamera()
    {
        try {
            Sending.sp.Write("a");
        } 
        catch 
        {

        }
        currentTransformNumber++;

        if (currentTransformNumber > maxTransformNumber - 1)
        {
            currentTransformNumber = 0;
        }

        myCamera.transform.position = cameraTransforms[currentTransformNumber].transform.position;
        myCamera.transform.rotation = cameraTransforms[currentTransformNumber].transform.rotation;
    }
}
