Shader "Custom/MandelbrotShader"
{
    Properties
    {
        _Offset ("Offset", Vector) = (0, 0, 0, 0)
        _Zoom ("Zoom", Float) = 1.0
        _MaxIterations ("Max Iterations", Int) = 200
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

            float4 _Offset;
            float _Zoom;
            int _MaxIterations;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 c = (i.uv - 0.5) * _Zoom - _Offset.xy;
                float2 z = 0;
                int iterations = 0;

                for (int k = 0; k < _MaxIterations; k++)
                {
                    float x = z.x * z.x - z.y * z.y + c.x;
                    float y = 2.0 * z.x * z.y + c.y;
                    z = float2(x, y);

                    if (dot(z, z) > 4.0)
                    {
                        iterations = k;
                        break;
                    }
                }

                float t = iterations / (float)_MaxIterations; // Normalize iterations
                return float4(t, t, t, 1.0); // Grayscale output
            }
            ENDCG
        }
    }
}