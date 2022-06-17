Shader "Custom/transparent_clipping"
{
    Properties 
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Color (RGBA)", Color) = (1, 1, 1, 1) // add _Color property
    }

    SubShader 
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        LOD 100

        Pass 
        {
            CGPROGRAM

            #pragma target 3.0
            #pragma vertex vert alpha
            #pragma fragment frag alpha
            

            #include "UnityCG.cginc"

            struct appdata_t 
            {
                float4 vertex   : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f 
            {
                float4 vertex  : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _Plane;
            float4 _PlaneG;

            v2f vert (appdata_t v)
            {
                v2f o;

                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.vertex     = UnityObjectToClipPos(v.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float distance = dot(i.worldPos, _Plane.xyz);
                distance = distance + _Plane.w;
                clip(distance);
                float distanceG = dot(i.worldPos, _PlaneG.xyz);
                distanceG = distanceG + _PlaneG.w;
                clip(distanceG);

                fixed4 col = tex2D(_MainTex, i.worldPos) * _Color; // multiply by _Color
                return col;
            }

            ENDCG
        }
    }
}
