using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ClippingPlaneRight : MonoBehaviour
{
    public Material mat_blue_r;
    public Material mat_gray_r;

    //execute every frame
    void Update () {
        //create plane
        Plane planeBlueR = new Plane(transform.up, transform.position);
        Plane planeGrayR = new Plane(transform.up, transform.position);
        //transfer values from plane to vector4
        Vector4 planeRepresentationBlueR = new Vector4(planeBlueR.normal.x, planeBlueR.normal.y, planeBlueR.normal.z, planeBlueR.distance);
        Vector4 planeRepresentationGrayR = new Vector4(planeGrayR.normal.x, planeGrayR.normal.y, planeGrayR.normal.z, planeGrayR.distance);
        //pass vector to shader
        mat_gray_r.SetVector("_PlaneGR", planeRepresentationGrayR);
        mat_blue_r.SetVector("_PlaneBR", planeRepresentationBlueR);
        
    }
}

