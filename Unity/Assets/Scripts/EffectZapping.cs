using UnityEngine;
using System.Collections;

public class ProgressValue
{
	float valueFrom;
	float valueTo;
	float progressStart;
	float progressDelay;
	float timeStart;
	public ProgressValue (float from_, float to_, float start_, float delay_)
	{
		valueFrom = from_;
		valueTo = to_;
		progressStart = start_;
		progressDelay = delay_;
	}
	public void Start ()
	{
		timeStart = Time.time;
	}
	public float GetRatio ()
	{
		return Mathf.Clamp((Time.time - timeStart - progressStart) / progressDelay, 0f, 1f);
	}
	public float GetValue ()
	{
		return Mathf.Lerp(valueFrom, valueTo, GetRatio());
	}
	public void Debug ()
	{
		timeStart = Mathf.Infinity;
	}
}

public class EffectZapping : MonoBehaviour 
{
	Filter[] filterList;

    // Intro video
#if !UNITY_ANDROID
    ProgressValue videoProgress = new ProgressValue(1.0f, 0.6f, 0f, 30f);
#endif

    // "Chill" FX
#if UNITY_ANDROID
    ProgressValue lsdColorProgress = new ProgressValue(0.0f, 0.4f, 0f, 1f);
	ProgressValue randomLineProgress = new ProgressValue(0.0f, 0.6f, 10f, 1f);
#else
    ProgressValue lsdColorProgress = new ProgressValue(0.0f, 0.4f, 5f, 1f);
    ProgressValue randomLineProgress = new ProgressValue(0.0f, 0.6f, 15f, 1f);
#endif
    // Geometry transformations
    ProgressValue complexProgress = new ProgressValue(0.0f, 0.4f, 20f, 1f);
	ProgressValue odysseyProgress = new ProgressValue(0.0f, 0.3f, 25f, 1f);
	ProgressValue vortexProgress = new ProgressValue(0.0f, 0.4f, 30f, 1f);

	ProgressValue meshesProgress = new ProgressValue(0.0f, 0.2f, 10f, 1f);
	
	// The climax
	ProgressValue epilepsyColorProgress = new ProgressValue(0.0f, 0.6f, 60f, 1f);

	// Kill screen and retina
	ProgressValue blankingProgress = new ProgressValue(0.0f, 0.5f, 80f, 1f);

	void Start () 
	{
		filterList = GetComponentsInChildren<Filter>(true) as Filter[];
	}

    public void BeginGame()
    {
#if !UNITY_ANDROID
        videoProgress.Start();
#endif
        lsdColorProgress.Start();
        randomLineProgress.Start();
        complexProgress.Start();
        odysseyProgress.Start();
        vortexProgress.Start();
        epilepsyColorProgress.Start();
        blankingProgress.Start();
        meshesProgress.Start();
    }

	public void Zap ()
    {
        if (Random.value>0.50f)
            Sending.DoEffect("t");
        else
            Sending.DoEffect("b");
        filterList = GetComponentsInChildren<Filter>(true) as Filter[];
		
		foreach (Filter filter in filterList)
		{
			Destroy(filter);
		}

		Shuffle();

		foreach (Filter filter in filterList)
		{
			Filter newFilter = gameObject.AddComponent(filter.GetType()) as Filter;
			newFilter.enabled = Random.Range(0f, 1f) < GetChanceFor(newFilter.GetType().ToString());
			newFilter.Rumble();
		}
        Debug.Log("Bim");
	}

	float GetChanceFor (string filterName)
	{
		float chance = 0.5f;
		switch (filterName)
		{
			case "LSDColor": chance = lsdColorProgress.GetValue(); break;
			case "EpilepsyColor": chance = epilepsyColorProgress.GetValue(); break;
			case "Complex": chance = complexProgress.GetValue(); break;
			case "RandomLine": chance = randomLineProgress.GetValue(); break;
			case "Odyssey": chance = odysseyProgress.GetValue(); break;
			case "Vortex": chance = vortexProgress.GetValue(); break;
			case "Meshes": chance = meshesProgress.GetValue(); break;
#if !UNITY_ANDROID
            case "Video": chance = videoProgress.GetValue(); break;
#endif
			case "Blanking": chance = blankingProgress.GetValue(); break;
			default: chance = 0.0f; break;
		}
		return chance;
	}

	public void Stop ()
	{
		filterList = GetComponentsInChildren<Filter>(true) as Filter[];
		foreach (Filter filter in filterList)
		{
            // Destroy(filter);
            filter.gameObject.SetActive(false);
		}
	}

	void Shuffle ()
	{
		for (int i = filterList.Length - 1; i > 0; i--)
		{
			int j = (int)Mathf.Floor(Random.Range(0f, 1f) * ((float)i + 1f));
			Filter temp = filterList[i];
			filterList[i] = filterList[j];
			filterList[j] = temp;
		}
	}
}
