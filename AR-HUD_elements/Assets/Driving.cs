using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Driving : MonoBehaviour
{
    public GameObject[] speedPoints;
    public PathCreator pathCreator;
    public float speed = 7;
    float distanceTravelled;
    int speedPointCounter = 0;
    private bool speedChanger = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //reduce and increase speed at points on map
        var distance = Vector3.Distance(transform.position, speedPoints[speedPointCounter].transform.position);
        if(distance < 2f && (speedPointCounter % 2 == 0))
        {
            speed = speed - 0.04f;
            speedChanger = true;
        }
        else if(distance < 2f && (speedPointCounter % 2 == 1))
        {
            speed = speed + 0.04f;
            speedChanger = true;
        }
        if(speedChanger && (distance >= 2f))
        {
            speedPointCounter++;
            speedChanger = false;
        }
        if(speedPointCounter == speedPoints.Length)
        {
            speedPointCounter = 0;
        }

        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
