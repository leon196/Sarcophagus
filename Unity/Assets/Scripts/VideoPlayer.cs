using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class VideoPlayer : MonoBehaviour
{
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
        StartCoroutine(StartStream("TesUnOufToi.ogv"));
        StartCoroutine(StartStream("small.ogv"));
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
