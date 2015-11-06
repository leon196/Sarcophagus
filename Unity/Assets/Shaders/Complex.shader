Shader "Hidden/Complex"
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
			#include "Utils/Complex.cginc"
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
			float _Zoom;
			float _Speed1;
			float _Speed2;

			fixed4 frag (v2f i) : SV_Target
			{
				float t = _Time * 10.0;
				float osc1 = sin(_Time * 30.0) * 0.5 + 0.5;

				float2 uv = i.uv * 2.0 - 1.0;

				uv = complex_div(_Zoom - osc1 * _Speed1, uv);

				uv.x = kaleido(uv.x, t * _Speed2);
				uv.y = kaleido(uv.y, t * _Speed2);

				fixed4 col = tex2D(_MainTex, uv);

				return col;
			}
			ENDCG
		}
	}
}
