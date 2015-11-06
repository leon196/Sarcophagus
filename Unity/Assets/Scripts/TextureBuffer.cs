using UnityEngine;
using System.Collections;

public class TextureBuffer : MonoBehaviour 
{
	public Material material;
	Camera cameraRender;
	int currentTexture = 0;
	RenderTexture[] textureList;

	void Start ()
	{
		cameraRender = GetComponent<Camera>();
		textureList = new RenderTexture[2];

		int width = Screen.width;
		int height = Screen.height;
		for (int i = 0; i < textureList.Length; ++i)
		{
			textureList[i] = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
			textureList[i].antiAliasing = 2;
			textureList[i].Create();
			// textureList[i].filterMode = FilterMode.Point;
		}
		NextTexture();
		cameraRender.targetTexture = GetCurrentTexture();
		Shader.SetGlobalTexture("_BufferTexture", GetCurrentTexture());
		material.mainTexture = GetCurrentTexture();
	}

	void Update ()
	{
		Shader.SetGlobalTexture("_BufferTexture", GetCurrentTexture());
		NextTexture();
		cameraRender.targetTexture = GetCurrentTexture();
		material.mainTexture = GetCurrentTexture();
	}

	void NextTexture ()
	{
		currentTexture = (currentTexture + 1) % 2;
	}

	RenderTexture GetCurrentTexture ()
	{
		return textureList[currentTexture];
	}
}
