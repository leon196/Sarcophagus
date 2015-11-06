using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Complex : MonoBehaviour 
{
	public float zoom = 1f;
	public float speed1 = 1f;
	public float speed2 = 1f;
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
		material.SetFloat("_Speed1", speed1);
		material.SetFloat("_Speed2", speed2);
		Graphics.Blit (source, destination, material);
	}
}