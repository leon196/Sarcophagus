using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Odyssey : Filter 
{
	public float speed = 10f;
	public float scaleX = 4f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Odyssey") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Speed", speed);
		material.SetFloat("_ScaleX", scaleX);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		scaleX = Random.Range(0f, 10f);
		speed = Random.Range(10f, 100f);
	}
}