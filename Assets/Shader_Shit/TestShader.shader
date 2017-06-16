Shader "Custom/Begin" {
	Properties {
		_Color ("Water Color (RGB) Transparency (A)", COLOR) = (1, 1, 1, 0.5)
		_BumpMap ("Normal Map 1", 2D) = "white" {}
		_BumpMap2 ("Normal Map 2", 2D) = "white" {}
		_FlowMap ("Flow Map", 2D) = "white" {}
		_NoiseMap ("Noise Map", 2D) = "black" {}
		_Cube ("Reflection Cubemap", Cube) = "white" { TexGen CubeReflect }
		_Cycle ("Cycle", float) = 1.0
		_Speed ("Speed", float) = 0.05
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
		_Shininess ("Shininess", Range (0.01, 2)) = 0.078125
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
	}

	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200

		CGPROGRAM
		#pragma surface surf BlinnPhong
		#pragma target 3.0

		float4 _Color;
		sampler2D _BumpMap;
		sampler2D _BumpMap2;
		samplerCUBE _Cube;
		sampler2D _FlowMap;
		sampler2D _NoiseMap;
		float _Cycle;
		float _Speed;
		float _Shininess;
		float4 _ReflectColor;

		struct Input {
			float2 uv_BumpMap;
			float2 uv_FlowMap;
			float3 worldRefl;
			float3 worldNormal;
			float viewDir;
			INTERNAL_DATA
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float3 flowDir = tex2D(_FlowMap, IN.uv_FlowMap) * 2 -1;
			flowDir *= _Speed;
			//flowDir.y *= -1; // A dirty fix because I didn't want to rearrange my scene, you should be able to remove it
			float3 noise = tex2D(_NoiseMap, IN.uv_FlowMap);
			
			float phase = _Time[1] / _Cycle + noise.r * 0.5f;
			float f = frac(phase);
			
			half3 n1 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + flowDir.xy * frac(phase + 0.5f)));
			half3 n2 = UnpackNormal(tex2D(_BumpMap2, IN.uv_BumpMap + flowDir.xy * f));
			
			if (f > 0.5f)
				f = 2.0f * (1.0f - f);
			else
				f = 2.0f * f;
			
			o.Normal = lerp(n1, n2, f);
			o.Alpha = _Color.a;
			o.Gloss = 1;
			o.Specular = _Shininess;
			
			fixed4 reflcol = texCUBE (_Cube, WorldReflectionVector(IN, o.Normal));
    		o.Albedo = _Color.rgb;
    		o.Emission = reflcol.rgb * _ReflectColor.rgb;
		}
		ENDCG
	}
	FallBack "Reflective/Bumped Specular"
}