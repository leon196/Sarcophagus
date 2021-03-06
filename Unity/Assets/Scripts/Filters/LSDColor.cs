using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LSDColor : Filter 
{
	public float speed = 10f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/LSDColor") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Speed", speed);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		speed = Random.Range(10f, 100f);
	}
}