using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ClippingPlaneLeft : MonoBehaviour
{
    public Material mat_blue_l;
    public Material mat_gray_l;

    //execute every frame
    void Update () {
        //create plane
        Plane planeBlueL = new Plane(transform.up, transform.position);
        Plane planeGrayL = new Plane(transform.up, transform.position);
        //transfer values from plane to vector4
        Vector4 planeRepresentationBlueL = new Vector4(planeBlueL.normal.x, planeBlueL.normal.y, planeBlueL.normal.z, planeBlueL.distance);
        Vector4 planeRepresentationGrayL = new Vector4(planeGrayL.normal.x, planeGrayL.normal.y, planeGrayL.normal.z, planeGrayL.distance);
        //pass vector to shader
        mat_blue_l.SetVector("_PlaneBL", planeRepresentationBlueL);
        mat_gray_l.SetVector("_PlaneGL", planeRepresentationGrayL);
        
        
    }
}
