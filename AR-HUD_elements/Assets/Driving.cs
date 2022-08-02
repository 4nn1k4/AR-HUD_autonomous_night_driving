using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Driving : MonoBehaviour
{
    public GameObject[] speedPoints;
    public PathCreator pathCreator;
    public float speed = 7f;
    float distanceTravelled;
    int speedPointCounter = 0;
    private bool speedChanger = false;
    private float speedChangeValue = 0.04f;
    private float minSpeed = 3f;
    private float maxSpeed = 7.5f;
    private float distanceValue = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //reduce and increase speed at points on map
        var distance = Vector3.Distance(transform.position, speedPoints[speedPointCounter].transform.position);
        if(distance < distanceValue && (speedPointCounter % 2 == 0))
        {
            if(speed>minSpeed){
            speed = speed - speedChangeValue;
            speedChanger = true;
            }
        }
        else if(distance < 2f && (speedPointCounter % 2 == 1))
        {
            if(speed<maxSpeed){
            speed = speed + speedChangeValue;
            speedChanger = true;
            }
        }
        if(speedChanger && (distance >= distanceValue))
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
