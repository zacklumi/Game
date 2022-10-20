Shader "Unlit/LeafEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorShiftSpeed ("Color Shift Speed", float) = 1.0
        _Repetition ("Repetition", float) = 2.0
        _Direction ("Direction", float) = 1.0
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
            float _ColorShiftSpeed;
            float _Repetition;
            float _Direction;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Repetition * _Direction;
                fixed red = sin(_Time.y * _ColorShiftSpeed + col.r + 2.0) * 0.1 + 0.7;
                fixed green = sin(_Time.y * _ColorShiftSpeed + col.g + 0.0) * 0.1 + 0.7;
                fixed blue = sin(_Time.y * _ColorShiftSpeed + col.b + 4.0) * 0.1 + 0.7;
                return fixed4(red, green, blue, col.a);
            }
            ENDCG
        }
    }
}
