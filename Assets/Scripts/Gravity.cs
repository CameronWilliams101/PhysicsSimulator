using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private List<GameObject> celestialBodies;
    public float netForce = 0;
    public float G = 6.674f * Mathf.Pow(10f, -11f);
    public float mass = 1f;
    public Vector3 netDisplacement;
    public float netAcceleration = 0f;
    public float netVelocity = 0f;


    void Start()
    {
        celestialBodies = new List<GameObject>(GameObject.FindGameObjectsWithTag("CelestialBody"));
        celestialBodies.Remove(gameObject);
    }
    
    void Update()
    {
        netDisplacement = new Vector3(0, 0, 0);

        foreach (GameObject celestialBody in celestialBodies)
        {
            //Distance between bodies
            var rVector = celestialBody.transform.position - transform.position;
            var r = rVector.magnitude;

            //Newton's law of universal gravitation
            var F = G * ((mass * celestialBody.GetComponent<Gravity>().mass)/Mathf.Pow(r, 2));

            //Newton's second law
            var a = F/mass;

            //Calculate v with current acceleration for the amount of time at that acceleration (since last frame of time sample)
            var v = a * Time.deltaTime;

            //Get displacement
            var d = v * Time.deltaTime;

            //Displacemnt caused by this celestialBody
            netDisplacement += rVector * d;

            //Draw line
            Debug.DrawLine(transform.position, celestialBody.transform.position, Color.red);
        }

        //Move body by the displacement
        transform.position += netDisplacement;

        //Calculating net Variables
        netVelocity = netDisplacement.magnitude/Time.deltaTime;
        netAcceleration = netVelocity/Time.deltaTime;
        netForce = netAcceleration * mass;
    }
}
