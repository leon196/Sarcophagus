Shader "Custom/Coloring" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		#include "Utils/Noise3D.cginc"

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float3 rotateY(float3 v, float t)
		{
		    float cost = cos(t); float sint = sin(t);
		    return float3(v.x * cost + v.z * sint, v.y, -v.x * sint + v.z * cost);
		}

		float3 rotateX(float3 v, float t)
		{
		    float cost = cos(t); float sint = sin(t);
		    return float3(v.x, v.y * cost - v.z * sint, v.y * sint + v.z * cost);
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
				float t = _Time * 10.0;

			c.rgb = abs(rotateX(c.rgb, t));
			c.rgb = abs(rotateY(c.rgb, t));

			c.r = abs(snoise(c.rgb));
			c.g = abs(snoise(c.gbr));
			c.b = abs(snoise(c.brg));

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
