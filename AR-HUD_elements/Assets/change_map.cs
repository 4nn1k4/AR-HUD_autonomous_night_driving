using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_map : MonoBehaviour
{
    public GameObject map;
    public GameObject car;
    public GameObject arrow;
    public float horizontalScrollSpeed = 0f;
    public float verticalScrollSpeed = 1f;
    Renderer mapRenderer;
    float carX;
    float carZ;
    float carNewX;
    float carNewZ;
    float carRotation;

    // Start is called before the first frame update
    void Start()
    {
        mapRenderer = map.GetComponent<Renderer> ();
        carX = car.transform.position.x;
        carZ = car.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate map position depending on the position of the car
        carNewX = car.transform.position.x;
        carNewZ = car.transform.position.z;
        float offsetX = (carNewZ - carZ)/385;
        float offsetY = (carNewX - carX)/510;
        //calculate arrow rotation depending on rotation of the car
        carRotation = car.transform.localEulerAngles.y;
        
        //set rotation and position
        arrow.transform.localRotation = Quaternion.Euler(-carRotation, -88, 90);
        mapRenderer.material.mainTextureOffset = new Vector2(mapRenderer.material.mainTextureOffset.x - offsetX, mapRenderer.material.mainTextureOffset.y + offsetY);


        carX = carNewX;
        carZ = carNewZ;
    
    }
}

