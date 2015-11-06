Shader "Hidden/RandomLine"
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
			float _ScaleX;
			float _ScaleY;

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

			fixed4 frag (v2f i) : SV_Target
			{
				float t = _Time * 30.0;
				float osc1 = sin(_Time * 30.0) * 0.5 + 0.5;

				float2 uv = i.uv;

				uv.x += rand(uv.y + _Time) * _ScaleX - _ScaleX * 0.5;
				uv.y += rand(uv.x + _Time) * _ScaleY - _ScaleY * 0.5;

				fixed4 col = tex2D(_MainTex, uv);

				return col;
			}
			ENDCG
		}
	}
}
