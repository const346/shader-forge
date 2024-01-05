Shader "Custom/HoleMask"
{
	Properties{}

	SubShader{

		Tags {
			"RenderType" = "Opaque"
		}

		Pass {
            ZWrite Off  
            ColorMask 0
		}
	}
}