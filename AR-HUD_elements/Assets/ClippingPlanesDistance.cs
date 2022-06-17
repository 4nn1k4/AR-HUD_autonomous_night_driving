using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ClippingPlanesDistance : MonoBehaviour
{
    //material we pass the values to
    public Material mat_blue_d;
    public Material mat_gray_d;

    //execute every frame
    void Update () {
        //create plane
        Plane planeBlueD = new Plane(transform.up, transform.position);
        Plane planeGrayD = new Plane(transform.up, transform.position);
        //transfer values from plane to vector4
        Vector4 planeRepresentationBlueD = new Vector4(planeBlueD.normal.x, planeBlueD.normal.y, planeBlueD.normal.z, planeBlueD.distance);
        Vector4 planeRepresentationGrayD = new Vector4(planeGrayD.normal.x, planeGrayD.normal.y, planeGrayD.normal.z, planeGrayD.distance);
        //pass vector to shader
        mat_gray_d.SetVector("_PlaneGD", planeRepresentationGrayD);
        mat_blue_d.SetVector("_PlaneBD", planeRepresentationBlueD);
        
    }
}
