Shader "Custom/NoiseGround"
{
    Properties
    {
		_Tess("Tessellation", Range(1,8)) = 4
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_NoiseScale("Noise Scale", float) = 1
		_NoiseFrequency("Noise Frequency", float) = 1
		_NoiseOffset("Noise Offset", Vector)  = (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        //创建网格；要用噪声控制顶点偏移所以传入顶点
        #pragma surface surf Standard fullforwardshadows tessellate:tess vertex:vert

        #pragma target 4.6 
        //插件package,使用里面的方法
		#include "noiseSimplex.cginc"

		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
            float4 tangent : TANGENT;
			float2 texcoord : TEXCOORD0;
		};

        sampler2D _MainTex, _NormalMap;

        struct Input
        {
            float2 uv_MainTex;
        };

		float _Tess;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

		float _NoiseScale, _NoiseFrequency;
		float4 _NoiseOffect;

		float4 tess()
		{
			return _Tess;
		}

		void vert(inout appdata v)//噪声函数
		{
            //输入一个三维向量得到三维噪声
			//float noise = _NoiseScale * snoise(float3(v.vertex.x + _NoiseOffect.x, v.vertex.y + _NoiseOffect.y, v.vertex.z + _NoiseOffect.z) * _NoiseFrequency);
            //然后将获得的噪声应用于顶点（此时法线全都朝上，所以之后开始重新计算法线）
            //v.vertex.y += noise;

            float3 v0 = v.vertex.xyz;
            float3 bitangent = cross(v.normal, v.tangent.xyz);
            float3 v1 = v0 + (v.tangent.xyz * 0.01);//tangent
            float3 v2 = v0 + (bitangent * 0.01);//bitangent

            float ns0 = _NoiseScale * snoise(float3(v0.x + _NoiseOffect.x, v0.y + _NoiseOffect.y, v0.z + _NoiseOffect.z) * _NoiseFrequency);
            v0.xyz += ((ns0 + 1)/2) * v.normal;//(ns0+1)/2为了使noise原来的（-1,1）取值变到（0,1）范围

            float ns1 = _NoiseScale * snoise(float3(v1.x + _NoiseOffect.x, v1.y + _NoiseOffect.y, v1.z + _NoiseOffect.z) * _NoiseFrequency);
            v1.xyz += ((ns1 + 1)/2) * v.normal;
            
            float ns2 = _NoiseScale * snoise(float3(v2.x + _NoiseOffect.x, v2.y + _NoiseOffect.y, v2.z + _NoiseOffect.z) * _NoiseFrequency);
            v2.xyz += ((ns2 + 1)/2) * v.normal;            

            float3 vn = cross(v2-v0,v1-v0);//vnormal 法线
            v.normal = normalize(-vn);
            v.vertex.xyz = v0;
		}
		       
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
