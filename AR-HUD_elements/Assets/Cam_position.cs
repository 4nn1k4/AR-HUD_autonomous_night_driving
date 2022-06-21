using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_position : MonoBehaviour
{
    public Transform VRCamHolder; //parent of the cam
    public float WaitBeforeCompensation = 0.5f;
    Vector3 deltaPos;
    Vector3 tmp;
 
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Compensate());
    }
   
    IEnumerator Compensate()
    {
        yield return new WaitForSeconds(WaitBeforeCompensation);
        /*deltaPos = InputTracking.GetLocalPosition(VRNode.Head);
        tmp = Vector3.zero;
        tmp.x = deltaPos.x;
        tmp.y = deltaPos.y * -1f;
        tmp.z = deltaPos.z;*/
        /*tmp = Vector3.zero;
        tmp.x = -0.426f;
        tmp.y = 1.31f;
        tmp.z = -0.152f;
        VRCamHolder.position = tmp;*/
    }
}
