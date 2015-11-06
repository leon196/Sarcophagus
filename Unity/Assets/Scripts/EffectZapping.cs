using UnityEngine;
using System.Collections;

public class EffectZapping : MonoBehaviour 
{
	Filter[] filterList;

	void Start () 
	{
		filterList = GetComponentsInChildren<Filter>(true) as Filter[];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Zap();
		}		
	}

	public void Zap ()
	{
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
	}

	float GetChanceFor (string filterName)
	{
		float chance = 0.5f;
		switch (filterName)
		{
			case "LSDColor": chance = 0.5f; break;
			case "EpilepsyColor": chance = 0.8f; break;
			case "Complex": chance = 0.6f; break;
			case "RandomLine": chance = 0.5f; break;
			case "Odyssey": chance = 0.1f; break;
			case "Vortex": chance = 0.2f; break;
			case "Video": chance = 0.7f; break;
			case "Blanking": chance = 0.2f; break;
			default: chance = 0.5f; break;
		}
		return chance;
	}

	public void Stop ()
	{
		filterList = GetComponentsInChildren<Filter>(true) as Filter[];
		foreach (Filter filter in filterList)
		{
			Destroy(filter);
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
