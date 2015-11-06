using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class VideoPlayer : MonoBehaviour
{
    string[] videoNameList = new string[] { "TesUnOufToi.ogv", "Sensor2.ogv" };
    List<MovieTexture> videoList;
 
    void Awake ()
    {        
        videoList = new List<MovieTexture>();
        LoadVideos();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayVideo(GetRandomVideo());
        }
    }

    void LoadVideos ()
    {
        foreach (string videoName in videoNameList)
        {
            StartCoroutine(StartStream(videoName));
        }
    }

    MovieTexture GetRandomVideo ()
    {
        return videoList[Random.Range(0, videoList.Count)];
    }
 
    IEnumerator StartStream (string videoName)
    {
    	string url = "file://" + Application.streamingAssetsPath + "/" + videoName;
        WWW videoStreamer = new WWW (url);
        MovieTexture movieTexture = videoStreamer.movie;
        movieTexture.loop = true;
        videoList.Add(movieTexture);
        while (!movieTexture.isReadyToPlay) 
        {
            yield return 0;
        }
        PlayVideo(movieTexture);
    }

    void PlayVideo (MovieTexture movieTexture)
    {
        GetComponent<AudioSource>().clip = movieTexture.audioClip;
        GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().material.mainTexture = movieTexture;
        movieTexture.Play();
    }
}
