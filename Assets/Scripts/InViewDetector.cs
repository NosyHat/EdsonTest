using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{
    Camera cam;
    MeshRenderer render;
    Plane[] cameraFrustum;
    Collider collisor;

    public void Start()
    {
        cam = Camera.main;
        render = GetComponent<MeshRenderer>();
        collisor = GetComponent<Collider>();
    }

    private void Update()
    {
        var bounds = collisor.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            render.sharedMaterial.color = Color.green;
        }
        else
        {
            render.sharedMaterial.color = Color.red;
        }
    }
}
