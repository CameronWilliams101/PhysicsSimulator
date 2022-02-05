using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject otherBody;
    public float F = 0;
    public float G = 6.674f * Mathf.Pow(10f, -11f);
    public float m1 = 1f;
    public float m2 = 1f;
    public Vector3 rVector;
    public float r = 0f;    
    public float a = 0f;
    public float v = 0f;
    public float d = 0f;


    void Start()
    {
        Debug.DrawLine(transform.position, otherBody.transform.position, Color.green, float.PositiveInfinity);
    }
    
    void Update()
    {
        //Radius
        rVector = otherBody.transform.position - transform.position;
        r = rVector.magnitude;

        //Newton's law of universal gravitation
        F = G * ((m1 * m2)/Mathf.Pow(r, 2));

        //Newton's second law
        a = F/m1;

        //Calculate v with current acceleration for the amount of time at that acceleration (since last frame of time sample)
        v = a * Time.deltaTime;

        //Get displacement
        d = v * Time.deltaTime;

        //Move body by the displacement
        transform.position += rVector * d;

        //Draw line
        Debug.DrawLine(transform.position, otherBody.transform.position, Color.red);
    }
}
