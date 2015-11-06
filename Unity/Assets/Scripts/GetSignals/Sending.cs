//using UnityEngine;
//using System.Collections;
//using System.IO.Ports;
//using System.Threading;

//public class Sending : MonoBehaviour
//{
//    public static SerialPort sp = new SerialPort("COM3", 9600);
//    public string message2;
//    float timePassed = 0.0f;

//    int cnt = 0;
//    // Use this for initialization
//    void Start()
//    {
//        OpenConnection();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (Input.GetKeyDown(KeyCode.A))
//            DoThings("a");

//        if (Input.GetKeyDown(KeyCode.Z))
//            DoThings("z");

//        if (Input.GetKeyDown(KeyCode.E))
//            DoThings("e");

//        if (Input.GetKeyDown(KeyCode.R))
//            DoThings("r");


//        //timePassed+=Time.deltaTime;
//        //if(timePassed>=0.2f){

//        //print("BytesToRead" +sp.BytesToRead);
//        //message2 = sp.ReadLine();
//        //print(message2);
//        //	timePassed = 0.0f;
//        //}
//        try
//        {
//            string msg = sp.ReadLine();
//            cnt++;
//            DoThings(msg);
//        }
//        catch (System.TimeoutException e)
//        {

//        }
//    }

//    void DoThings(string msg)
//    {
//        switch (msg)
//        {
//            case "a":
//                Debug.Log("Got da message!");
//                break;

//            case "z":
//                Debug.Log("Got da message!");
//                break;

//            case "e":
//                Debug.Log("Got da message!");
//                break;

//            case "r":
//                Debug.Log("Got da message!");
//                break;

//        }
//    }

//    public void OpenConnection()
//    {
//        if (sp != null)
//        {
//            if (sp.IsOpen)
//            {
//                sp.Close();
//                print("Closing port, because it was already open!");
//            }
//            else
//            {
//                sp.Open();  // opens the connection
//                sp.ReadTimeout = 2;  // sets the timeout value before reporting error
//                print("Port Opened!");
//                //		message = "Port Opened!";
//            }
//        }
//        else
//        {
//            if (sp.IsOpen)
//            {
//                print("Port is already open");
//            }
//            else
//            {
//                print("Port == null");
//            }
//        }
//    }

//    void OnApplicationQuit()
//    {
//        sp.Close();
//    }

//    //public static void sendYellow()
//    //{
//    //    sp.Write("y");
//    //}
//}
