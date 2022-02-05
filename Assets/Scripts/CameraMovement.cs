using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float zoomIn = Input.GetAxis("Fire1");
        float zoomOut = Input.GetAxis("Fire2");

        transform.position += new Vector3(horizontal*speed, 0, vertical*speed);
        transform.Translate(0, 0, (zoomIn - zoomOut)*speed/4);
    }
}
