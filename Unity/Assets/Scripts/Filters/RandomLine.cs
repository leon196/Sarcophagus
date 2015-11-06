using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RandomLine : Filter 
{
	public float scaleX = 0.1f;
	public float scaleY = 0.1f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/RandomLine") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_ScaleX", scaleX);
		material.SetFloat("_ScaleY", scaleY);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		scaleX = Random.Range(0f, 0.1f);
		scaleY = Random.Range(0f, 0.1f);
	}
}