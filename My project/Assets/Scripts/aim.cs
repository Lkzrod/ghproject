using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
//private Camera mainCam;
//private Vector3 mousePos;

void Update()
{
    Vector3 mousePos = Input.mousePosition;
    Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

    Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

    float angle = Mathf.Atan2(offset.y, offset.x)* Mathf.Rad2Deg;

       transform.rotation = Quaternion.Euler(0, 0, angle);
}
    /*void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    // Update is called once per frame
    private void Update()
     {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, rotationZ);

    }*/
}