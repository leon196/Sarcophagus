using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour
{
    MovieTexture movieTexture;
 
    void Start ()
    {        
        StartCoroutine(StartStream());
    }
 
    protected IEnumerator StartStream ()
    {
    	string url = "file://" + Application.streamingAssetsPath + "/small.ogv";
        WWW videoStreamer = new WWW (url);

        movieTexture = videoStreamer.movie;
        GetComponent<AudioSource>().clip = movieTexture.audioClip;
        while (!movieTexture.isReadyToPlay) 
        {
            yield return 0;
        }
 
        GetComponent<AudioSource>().Play ();
        movieTexture.Play ();
        movieTexture.loop = true;
        
        GetComponent<Renderer>().material.mainTexture = movieTexture;
    }
}
