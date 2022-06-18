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
        carNewX = car.transform.position.x;
        carNewZ = car.transform.position.z;
        float offsetX = (carNewZ - carZ)/387;
        float offsetY = (carNewX - carX)/507;
        
        carRotation = car.transform.localEulerAngles.y;
        float rotationValue = 90 - carRotation;
        
        map.transform.localRotation = Quaternion.Euler(90 + rotationValue, 91, 91);
        mapRenderer.material.mainTextureOffset = new Vector2(mapRenderer.material.mainTextureOffset.x - offsetX, mapRenderer.material.mainTextureOffset.y + offsetY);
        /*Vector2 offset = new Vector2(mapRenderer.material.mainTextureOffset.x - offsetX, mapRenderer.material.mainTextureOffset.y + offsetY);
        Vector2 tiling = new Vector2(0.15f, 0.15f);
        var rot = Quaternion.Euler(90 + rotationValue, 91, 91);
        var matrix = Matrix4x4. TRS (offset, rot, tiling);
        mapRenderer.material.SetMatrix("_Matrix", matrix);*/

        carX = carNewX;
        carZ = carNewZ;
    
    }
}
