using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_map : MonoBehaviour
{
    public GameObject map;
    public GameObject car;
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
        //calculate map position depending on position of the car
        carNewX = car.transform.position.x;
        carNewZ = car.transform.position.z;
        float offsetX = (carNewZ - carZ)/387;
        float offsetY = (carNewX - carX)/507;
        
        //calculate map rotation based on rotation of the car 
        carRotation = car.transform.localEulerAngles.y;
        float rotationValue = 90 - carRotation;
        
        //set rotation and position of the map
        map.transform.localRotation = Quaternion.Euler(90 + rotationValue, 91, 91);
        mapRenderer.material.mainTextureOffset = new Vector2(mapRenderer.material.mainTextureOffset.x - offsetX, mapRenderer.material.mainTextureOffset.y + offsetY);

        carX = carNewX;
        carZ = carNewZ;
    
    }
}
