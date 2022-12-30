Shader "Hidden/FogEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FogColor ("Fog Color", Color) = (1, 1, 1, 1)
        _DepthStart ("Depthh Start", float) = 1
        _DepthDistance ("Depth Distance", float) = 1
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

            #include "UnityCG.cginc"

            sampler2D _CameraDepthTexture;
            fixed4 _FogColor;
            float _DepthStart, _DepthDistance;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 scrPos : TEXCOORD1;                
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.scrPos = ComputeScreenPos(o.vertex);//片元着色器获取屏幕坐标
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : COLOR
            {
                //传入相机深度贴图接口
                //Linear01Depth():file:///G:/unity2019.3.2f1/Editor/Data/Documentation/en/Manual/SL-DepthTextures.html
                //UNITY_PROJ_COORD():file:///G:/unity2019.3.2f1/Editor/Data/Documentation/en/Manual/SL-BuiltinMacros.html
                //投影参数_ProjectionParams：file:///G:/unity2019.3.2f1/Editor/Data/Documentation/en/Manual/SL-UnityShaderVariables.html
                //saturate 0,1
                
                float depthValue = Linear01Depth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r) * _ProjectionParams.z;//P(5)
                depthValue = saturate((depthValue - _DepthStart) / _DepthDistance);
                fixed4 fogColor = _FogColor * depthValue;
                //return fixed4(depthValue, depthValue, depthValue,1);

                fixed4 col = tex2Dproj(_MainTex, i.scrPos);
                return lerp(col, fogColor, depthValue);
            }
            ENDCG
        }
    }
}
