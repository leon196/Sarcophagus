Shader "Unlit/Buffer"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
                float4 screenUV : TEXCOORD1;
			};

			sampler2D _MainTex;
			sampler2D _BufferTexture;
			float4 _MainTex_ST;
			
			v2f vert (appdata_full v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		        o.screenUV = ComputeScreenPos(o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
		    	float2 uv = i.screenUV.xy / i.screenUV.w;
				fixed4 render = tex2D(_MainTex, uv);			
				fixed4 buffer = tex2D(_BufferTexture, uv);			
    			fixed4 color = lerp(buffer, render, step(0.71, distance(render, buffer)));
				return color;
			}
			ENDCG
		}
	}
}
