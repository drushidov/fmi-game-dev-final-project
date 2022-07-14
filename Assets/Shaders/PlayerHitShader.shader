Shader "Custom Shaders/Player Hit Shader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Screen Tint Color", Color) = (1, 1, 1, 1)
        _TintStrength("Tint Strength", Range(0, 1)) = 0
    }

    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

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
            float4 _Color;
            float _TintStrength;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);
                _Color.rgb = _Color.rgb + ((float3(1, 1, 1) - _Color.rgb) * (1 - _TintStrength));
                color.rgb = color.rgb * _Color.rgb;
                return color;
            }
            ENDCG
        }
    }
}
