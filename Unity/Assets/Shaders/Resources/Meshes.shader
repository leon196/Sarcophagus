Shader "Hidden/Meshes"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
   		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }

		Pass
		{
		    Cull off
	    	Blend SrcAlpha OneMinusSrcAlpha     
		    ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Utils/Helper.cginc"
			#include "Utils/Noise3D.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _MeshesTexture;
			float _Speed;
			float _VortexScale;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, i.uv);
				fixed4 meshes = tex2D(_MeshesTexture, i.uv);
				color.rgb = lerp(color.rgb, meshes.rgb, meshes.a);
				return color;
			}
			ENDCG
		}
	}
}
