Shader "Light2D/FOWMultiply" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        brightness ("Brightness", Range(0, 1)) = 0.5
    }

        Category{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }
            Blend Zero SrcColor

            Cull Off Lighting Off ZWrite Off

            SubShader {
                Pass {

                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma target 2.0

                    #include "UnityCG.cginc"

                    sampler2D _MainTex;
                    float4 _MainTex_ST;

                    float brightness;

                    struct appdata_t {
                        float4 vertex : POSITION;
                        float2 texcoord : TEXCOORD0;
                        UNITY_VERTEX_INPUT_INSTANCE_ID
                    };

                    struct v2f {
                        float4 vertex : SV_POSITION;
                        float2 texcoord : TEXCOORD0;
                        UNITY_VERTEX_OUTPUT_STEREO
                    };

                    v2f vert(appdata_t v)
                    {
                        v2f o;
                        UNITY_SETUP_INSTANCE_ID(v);
                        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                        o.vertex = UnityObjectToClipPos(v.vertex);
                        o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
                        return o;
                    }

                    float4 frag(v2f i) : SV_Target
                    {
                        float4 color = tex2D(_MainTex, i.texcoord);

                        float4 white = float4(1, 1, 1, 1);
                        float4 black = float4(brightness, brightness, brightness, 1);

                        color = lerp(black, white, color.r);

                        return color;
                    }
                    ENDCG
                }
            }
    }
}
