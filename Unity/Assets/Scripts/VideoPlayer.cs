using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VideoPlayer : MonoBehaviour
{
#if !UNITY_ANDROID
    string[] videoNameList = new string[] { "Video_TitleScreen.ogv", "Video_Sarcophagus.ogv" };

    List<MovieTexture> videoList =  new List<MovieTexture>();

    void Awake ()
    {
        videoList = new List<MovieTexture>();

        LoadVideos();
    }

    //void Update ()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        PlayVideo(GetRandomVideo());
    //    }
    //}

    void LoadVideos ()
    {
        foreach (string videoName in videoNameList)
        {
            StartCoroutine(StartStream(videoName));
        }
    }

    public void StartVideoForGame ()
    {
        PlayVideo(videoList[1]);
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
        if (videoName == "Video_TitleScreen.ogv")
        {
            PlayVideo(movieTexture);
        }
}

    void PlayVideo (MovieTexture movieTexture)
    {
        GetComponent<Renderer>().material.mainTexture = movieTexture;
        movieTexture.Play();
        Shader.SetGlobalTexture("_VideoTexture", movieTexture);
    }
#endif
}

