using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.UI;
using Bose.Wearable;
using System.Globalization;
using System;


using Twilio;
using Twilio.Rest.Api.V2010.Account;

//using GestureDetector;

public class CylinderScript : MonoBehaviour
{
    //stores the last acceleration vector
    private Vector3 lastFrameAcceleration = new Vector3(0, 0, 0);

    //various counters
    private int counter = 0;
    //private int counter2 = 0;
    private int countdown = 0;

    //cube is used to play sound once fall is detected
    public GameObject cube;
    private AudioSource audios;
    private bool fallen = false;

    private WearableControl _wearableControl;
    public bool headShaken = false;
    private bool textIsSent = false;

    

    
    //private GestureDetector gest;
    
    // Start is called before the first frame update
    void Start()
    {
        headShaken = false;
        audios = cube.GetComponent<AudioSource>();
        audios.enabled = false;
        _wearableControl = WearableControl.Instance;

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

        decimal vertAccelVal = decimal.Parse(words[1].Trim(), CultureInfo.InvariantCulture);


        words[0] = words[0].Replace("(", "");
        words[2] = words[2].Replace(")", "");

        //Debug.Log(" words at 0 (" + words[0] + ")");
        //Debug.Log(" words at 1 (" + words[1].Trim() + ")");
        //Debug.Log(" words at 2 (" + words[2].Trim() + ")");

        decimal xVal = decimal.Parse(words[1], CultureInfo.InvariantCulture);
        decimal YVal = decimal.Parse(words[2].Trim(), CultureInfo.InvariantCulture);

        //decimal xVal = Convert.ToDecimal(words[0]);

        counter ++;
        Debug.Log("counter is " + counter);
        //fall is only able to trigger after certain grace period
        if ( (vertAccelVal < 5)  &&  (counter >= 750)  &&   (  countdown>= 100 || countdown == 0   ) ){
            //Debug.Log("YOU ARE FALLING");
            fallen = true;
            headShaken = false;
            countdown = 0;
            //stp.Start();
        }

        //Debug.Log("COUNTDOWN IS " + countdown);

        // if (    (  Math.Abs(xVal - YVal) <= 5 )   &&  countdown>= 100) {
        //         //fallen = false;
        //        //headShaken = true;`
        //        Debug.Log("CANCEL THAT");
        //        countdown = 0;
        //        fallen = false;
        // }

       // else{
            //Debug.Log("YOU ARE NOT FALLING");
        
        if (fallen == true){
            audios.enabled = true;
            Debug.Log("FALL DETECTED");

            //start incrementing third counter
            countdown++;
            //audios.Play();
        }

    

        //Debug.Log("YEEEEEEEE " + Math.Abs(xVal - YVal));
        //Debug.Log("Yoo00 " + (xVal - YVal)  );

   

        //counter2++;

        //check if user is canceling the fall
        if(headShaken == true){
            //if they do cancel, just reset everything
            fallen = false;
            audios.enabled = false;
            Debug.Log("SMS Cancelled");
        }


        //if a certain amount of times has passed and user hasnt canceled the call, send it
        
       // if(true){
        if (countdown == 700 && fallen == true) {
            Debug.Log("Sending text message");
            textIsSent = true;
            fallen = false;

            //send the text
             // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "";
            const string authToken = "";
            
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your family member may have fallen",
                from: new Twilio.Types.PhoneNumber("+14805256961"),
                to: new Twilio.Types.PhoneNumber("+16475541964")
            );

            Console.WriteLine(message.Sid);

        }

        if(textIsSent == true){

            Debug.Log("TEXT HAS BEEN SENT");
        }

    }

    public void shake(){
        headShaken = true;
        audios.enabled = false;
        Debug.Log("You shook your head");
    }
}
