
#ifndef TRIPLANAR_INCLUDED
#define TRIPLANAR_INCLUDED

void Triplanar_float(float4 Node_X, float4 Node_Y, float4 Node_Z, 
    float3 Position, float3 Normal, float Tile, float Blend, out float4 Out)
{
    float3 Node_UV = Position * Tile;
    float3 Node_Blend = pow(abs(Normal), Blend);
    Node_Blend /= dot(Node_Blend, 1.0);
    Out = Node_X * Node_Blend.x + Node_Y * Node_Blend.y + Node_Z * Node_Blend.z;
}

#endif // GRAYSCALE_INCLUDED