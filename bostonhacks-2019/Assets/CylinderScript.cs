using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.UI;
//using WearableControl;

//using _wearableControl;
using Bose.Wearable;
using System.Globalization; // for lots of globalization types

//using System;
//using System.Diagnostics;
//using System.Threading;

//using namespace System.Globalization;

//using CultureInfo;

//using System;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;

public class CylinderScript : MonoBehaviour
{
    //stores the last acceleration vector
    private Vector3 lastFrameAcceleration = new Vector3(0, 0, 0);
    private int counter = 0;

    public UnityEvent onMovementDetected;
    public GameObject cube;
    private WearableControl _wearableControl;
    private bool fallen = false;
    private AudioSource audios;
    private int counter2 = 0;
    private int counter3 = 0;
    //private stopwatch stp;

    // Start is called before the first frame update
    void Start()
    {
        audios = cube.GetComponent<AudioSource>();
        audios.enabled = false;
        _wearableControl = WearableControl.Instance;

        // Create stopwatch.
        //Stopwatch stp = new Stopwatch();

        //requirement.EnableSensor(SensorId.Accelerometer);

        // Establish a requirement for the acceleration sensor
        WearableRequirement requirement = GetComponent<WearableRequirement>();
        if (requirement == null)
        {
            requirement = gameObject.AddComponent<WearableRequirement>();
        }

        requirement.EnableSensor(SensorId.Accelerometer);
        requirement.SetSensorUpdateInterval(SensorUpdateInterval.EightyMs);

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hello from cylinder script 2" + counter);
        counter ++;

        //get  and store the new acceleration vector
        SensorFrame frame = _wearableControl.LastSensorFrame;
        Vector3 newAcceleration = frame.acceleration;

        //calculate the difference in accelerations
        Vector3 diff = lastFrameAcceleration - newAcceleration;

        //store the current acceleration for the next iteration
        lastFrameAcceleration = newAcceleration;

        //Debug.Log("X:" + lastFrameAcceleration.X);
        //Debug.Log("Y:" + lastFrameAcceleration.Y);
        //Debug.Log("Z:" + lastFrameAcceleration.Z);

        Debug.Log("Acceleration vector:" + lastFrameAcceleration);

        string my_str = lastFrameAcceleration.ToString();
        string[] words = my_str.Split(',');



        Debug.Log(" The Vertical Acceleration is: (" + words[1].Trim() + ")");


        decimal d1 = decimal.Parse(words[1].Trim(), CultureInfo.InvariantCulture);

        Debug.Log("D1 is " + d1);
        Debug.Log("counter2 is " + counter2);
        if ( (d1 < 5)  &&  (counter2 >= 500) ){
            //Debug.Log("YOU ARE FALLING");
            fallen = true;
            //stp.Start();
        }
        else{
            //Debug.Log("YOU ARE NOT FALLING");
        }
        if (fallen == true){
            audios.enabled = true;
            Debug.Log("YOU HAVE FALLEN");
            //audios.Play();

        }

        counter2++;

    }
}
