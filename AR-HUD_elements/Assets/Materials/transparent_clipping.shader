//vgl. https://www.ronja-tutorials.com/post/006-simple-transparency/
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
            float4 _PlaneBD;
            float4 _PlaneGD;
            float4 _PlaneBR;
            float4 _PlaneGR;
            float4 _PlaneBL;
            float4 _PlaneGL;

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
                float distanceBD = dot(i.worldPos, _PlaneBD.xyz);
                distanceBD = distanceBD + _PlaneBD.w;
                clip(-distanceBD);
                float distanceGD = dot(i.worldPos, _PlaneGD.xyz);
                distanceGD = distanceGD + _PlaneGD.w;
                clip(-distanceGD);
                float distanceBR = dot(i.worldPos, _PlaneBR.xyz);
                distanceBR = distanceBR + _PlaneBR.w;
                clip(-distanceBR);
                float distanceGR = dot(i.worldPos, _PlaneGR.xyz);
                distanceGR = distanceGR + _PlaneGR.w;
                clip(-distanceGR);
                float distanceBL = dot(i.worldPos, _PlaneBL.xyz);
                distanceBL = distanceBL + _PlaneBL.w;
                clip(-distanceBL);
                float distanceGL = dot(i.worldPos, _PlaneGL.xyz);
                distanceGL = distanceGL + _PlaneGL.w;
                clip(-distanceGL);

                fixed4 col = tex2D(_MainTex, i.worldPos) * _Color; // multiply by _Color
                return col;
            }

            ENDCG
        }
    }
}
