using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    public float scaleFactor = 0.0003f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Always face Main Camera
        var camDirection = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(camDirection);

        //Scale Text from the distance of the camera
        var distanceToCam = camDirection.magnitude;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scaleFactor*distanceToCam, scaleFactor*distanceToCam, scaleFactor*distanceToCam);
    }
}
