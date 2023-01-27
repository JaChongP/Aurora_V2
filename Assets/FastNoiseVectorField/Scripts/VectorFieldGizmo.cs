using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VectorFieldGizmo : MonoBehaviour
{
    public Vector3 dimensions;
    public Vector3 noiseOffset;
    public float magnification;

    public Vector3 validDirections;

    public Color previewColor;
    
    FastNoise fastNoise = new FastNoise();

    private void OnDrawGizmos()
    {
        for (int z = 0; z < dimensions.z; ++z)
        {
            for (int y = 0; y < dimensions.y; ++y)
            {
                for (int x = 0; x < dimensions.x; ++x)
                {
                    float noise = fastNoise.GetSimplex((x + noiseOffset.x)  * magnification,
                        (y + noiseOffset.y)  * magnification,
                        (z + noiseOffset.z)  * magnification);

                    Vector3 noiseDirection = new Vector3(Mathf.Cos(noise * Mathf.PI), Mathf.Sin(noise * Mathf.PI),
                        Mathf.Cos(noise * Mathf.PI)).normalized;
                    noiseDirection.x *= validDirections.x;
                    noiseDirection.y *= validDirections.y;
                    noiseDirection.z *= validDirections.z;

                    //float noise = _fastNoise.Getsimplex(xoff + _offset.x, yoff + _offset.y, zoff + _offset.z) + 1;
                    //Vector3 noiseDirection = new Vector3 (Mathf.Cos (noise * Mathf.PI), Mathf.Sin (noise * * Mathf.PI), Mathf. Cos (nois
                    Gizmos.color = previewColor;// new Color(noiseDirection.normalized.x, noiseDirection.normalized.y, 0);
                    Vector3 pos = new Vector3(x , y , z ) + transform.position;
                    Vector3 endpos = pos + Vector3.Normalize(noiseDirection);
                    Gizmos.DrawLine(pos, endpos);
                    Gizmos.DrawSphere(endpos, 0.1f);

                    //vectorField[x, y] = (endpos - pos).normalized;


                }
            }
        }
    }

    public Vector3 SampleDirectionFromPosition(Vector3 location)
    {
        float noise = fastNoise.GetSimplex((location.x + noiseOffset.x)  * magnification,
            (location.y + noiseOffset.y)  * magnification,
            (location.z + noiseOffset.z)  * magnification);

        Vector3 noiseDirection = new Vector3(Mathf.Cos(noise * Mathf.PI), Mathf.Sin(noise * Mathf.PI), Mathf.Cos(noise * Mathf.PI)).normalized;
        noiseDirection.x *= validDirections.x;
        noiseDirection.y *= validDirections.y;
        noiseDirection.z *= validDirections.z;
        
        return noiseDirection;
    }
}
