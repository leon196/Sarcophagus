using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Complex : Filter 
{
	public float zoom = 0.1f;
	public float speedZoom = 0f;
	public float speedUV = 5f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Complex") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Zoom", zoom);
		material.SetFloat("_SpeedZoom", speedZoom);
		material.SetFloat("_SpeedUV", speedUV);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		zoom = Random.Range(0.1f, 1f);
		// speedZoom = Random.Range(0f, 1f);
		speedUV = Random.Range(1f, 10f);
	}
}