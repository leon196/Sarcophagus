using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EpilepsyColor : Filter 
{
	public float speed = 1f;
	Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/EpilepsyColor") );
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Speed", speed);
		Graphics.Blit (source, destination, material);
	}

	override public void Rumble ()
	{
		speed = Random.Range(0.001f, 1f);
	}
}