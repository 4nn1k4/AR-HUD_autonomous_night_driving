using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_2_screen_fix : MonoBehaviour
{
    public Material[] materials;
     //in the editor this is what you would set as the object you wan't to change
    public GameObject[] changingPoints;
    public GameObject screen;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, changingPoints[counter].transform.position);
        if(distance < 3f)
        {
            screen.GetComponent<MeshRenderer> ().material = materials[counter];
            counter++;
        }

        if(counter == changingPoints.Length){
            counter = 0;
        }
         
    }
}
