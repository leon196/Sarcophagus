Shader "Unlit/VertexDistortion"
{
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {

      Cull off
      Tags { "RenderType" = "Opaque" }

      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      #include "Utils/Noise3D.cginc"

      struct Input {
          float2 uv_MainTex;
      };

      void vert (inout appdata_full v) 
      {
          v.vertex.xyz += v.normal * snoise(v.normal + float3(v.texcoord.xy, 1.0) + _Time);
      }

      sampler2D _MainTex;

      void surf (Input IN, inout SurfaceOutput o) 
      {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }