using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RandomLine : MonoBehaviour 
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
}