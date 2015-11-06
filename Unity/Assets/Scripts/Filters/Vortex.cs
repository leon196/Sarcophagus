using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Vortex : Filter 
{
	public float speed = 10f;
	public float vortexScale = 4f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/Vortex") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Speed", speed);
		material.SetFloat("_VortexScale", vortexScale);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		speed = Random.Range(10f, 100f);
		vortexScale = Random.Range(1f, 10f);
	}
}