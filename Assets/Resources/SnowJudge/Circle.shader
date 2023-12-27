Shader "Custom/Circle"
{
    Properties{
        _MainTex ("Main Tex", 2D) = "white" {}
        _ColorTint ("Color", Color) = (1, 1, 1, 1)
        _CircleEdge ("CircleEdge", float) = 0.03
    }

    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
        // 开启透明度
        Blend SrcAlpha OneMinusSrcAlpha
        // 设置渲染队列
        Tags { "Queue"="Transparent" "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _ColorTint;
            float _CircleEdge;
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
            // 顶点着色获取
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // 片元着色
            fixed4 frag (v2f i) : SV_Target
            {
                float _CircleEdgeInFrag = (1 - _CircleEdge)*0.5;
                float disToCenter = (i.uv.x-0.5)*(i.uv.x-0.5) + (i.uv.y-0.5)*(i.uv.y-0.5);
                if( 0.5*0.5 > disToCenter && disToCenter > _CircleEdgeInFrag*_CircleEdgeInFrag )
                    return fixed4(_ColorTint.xyz, 1);
                else
                    return fixed4(_ColorTint.xyz, 0);
            }
            ENDCG
        }
    }
}
