using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ClippingPlane : MonoBehaviour {
    public Material mat_blue;
    public Material mat_gray;

    //execute every frame
    void Update () {
        //create plane
        Plane planeBlue = new Plane(transform.up, transform.position);
        Plane planeGray = new Plane(transform.up, transform.position);
        //transfer values from plane to vector4
        Vector4 planeRepresentationBlue = new Vector4(planeBlue.normal.x, planeBlue.normal.y, planeBlue.normal.z, planeBlue.distance);
        Vector4 planeRepresentationGray = new Vector4(planeGray.normal.x, planeGray.normal.y, planeGray.normal.z, planeGray.distance);
        //pass vector to shader
        mat_blue.SetVector("_Plane", planeRepresentationBlue);
        mat_gray.SetVector("_PlaneG", planeRepresentationGray);
    }
}
