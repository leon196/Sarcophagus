Shader "Hidden/Blanking"
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
			float _Speed;
			float _VortexScale;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed gray = abs(rand(_Time));
				fixed4 color = fixed4(1.0, 1.0, 1.0, 1.0);
				color.rgb *= step(gray, 0.5);
				return color;
			}
			ENDCG
		}
	}
}
