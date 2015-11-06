Shader "Hidden/Vortex"
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
			float _VortexScale;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;
				float t = _Time * _Speed;

				float2 center = uv - float2(0.5, 0.5);
				float angle = atan2(center.y, center.x);
				float radius = length(center);
				angle += radius * _VortexScale;
				float a = linearOscillator(abs(angle) / PI);
				//sin(angle * 4.0) * 0.5 + 0.5;
				uv = float2(a + t, log(radius));

				uv = fmod(abs(uv), 1.0);

				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
