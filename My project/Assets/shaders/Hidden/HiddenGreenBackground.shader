Shader "Unlit/HiddenGreenBackground"
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

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float Hash2To1(float2 p)
            {
                float3 p3 = frac(p.xyx * 0.1031);
                p3 += dot(p3, p3.yzx + 33.33);
                return frac((p3.x + p3.y) * p3.z);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = v.vertex;
                o.uv = v.vertex.xy * unity_OrthoParams.xy + _WorldSpaceCameraPos.xy;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float grayValue = Hash2To1(floor(i.uv));
                // fixed4 col = fixed4(0.0, grayValue, 0.0, 1.0);
                // fixed4 col = fixed4(frac(i.uv), 0.0, 1.0);
                fixed4 col = fixed4(grayValue, grayValue, grayValue, 1.0);
                return col;
            }
            // fixed4 frag (v2f i) : SV_Target
            // {
            //     // float2 gridUV = floor(i.uv);
            //     // float gridNoise = Hash2To1(gridUV);
            //     // fixed3 grassColor = tex1D(_GrassColorTexture, gridNoise).rgb;
            //
            //     fixed4 col = fixed4(frac(i.uv), 0.0, 1.0);
            //     return  col;
            // }
            ENDCG
        }
    }
}