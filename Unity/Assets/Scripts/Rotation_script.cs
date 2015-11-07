using UnityEngine;
using System.Collections;

public class Rotation_script : MonoBehaviour {

    private float rotationSpeed;
    public float minSpeed;
    public float maxSpeed;
    // Use this for initialization
	void Start () 
    {
        StartCoroutine(ChangeSpeed());
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.World);
	}

    IEnumerator ChangeSpeed ()
    {
        while (true)
        {
            rotationSpeed = Random.Range(minSpeed, maxSpeed);
            yield return new WaitForSeconds(Random.Range(0.5f,3f));
        }
    }
}
