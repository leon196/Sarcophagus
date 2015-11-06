﻿Shader "Hidden/Odyssey"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Utils/Helper.cginc"

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
			float _Speed;
			float _ScaleX;

			fixed4 frag (v2f i) : SV_Target
			{
				float t = _Time * _Speed;
				float2 uv = i.uv * 2.0 - 1.0;
				uv.x *= _ScreenParams.x / _ScreenParams.y;
				uv.x *= _ScaleX;
				uv.x /= uv.y;
				uv = fmod(abs(abs(uv) - float2(0, t)), 1.0);
				uv.x = kaleido(uv.x, 0);
				uv.y = kaleido(uv.y, 0);
				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
