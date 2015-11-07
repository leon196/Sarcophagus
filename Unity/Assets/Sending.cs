using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour {
    
    //public static SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
	public static SerialPort sp = new SerialPort("COM3", 9600);
	public string message2;
	float timePassed = 0.0f;

    int cnt = 0;
	// Use this for initialization
	void Awake () {
		OpenConnection();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
            sp.Write("a");
        if (Input.GetKeyDown(KeyCode.B))
            sp.Write("b");

        //timePassed+=Time.deltaTime;
        //if(timePassed>=0.2f){

        //print("BytesToRead" +sp.BytesToRead);
        //message2 = sp.ReadLine();
        //print(message2);
        //	timePassed = 0.0f;
        //}
        try
        {
            string msg = sp.ReadLine();
            cnt++;
            doShit(msg);
        } catch (System.TimeoutException e)
        {

        }
	}

    public static void DoEffect(string msg)
    {
        Debug.Log(msg);
        try
        {
            sp.Write(msg);
        }
        catch { }
    }

    void doShit(string msg)
    {
        switch (msg)
        {
            case "Salut gros!":
                Debug.Log("Got da message!");
                break;
            case "yo":
                Debug.Log("Da yo");
                break;

        }
    }

	public void OpenConnection() 
    {
       if (sp != null) 
       {
         if (sp.IsOpen) 
         {
          sp.Close();
          print("Closing port, because it was already open!");
         }
         else 
         {
          sp.Open();  // opens the connection
          sp.ReadTimeout = 2;  // sets the timeout value before reporting error
          print("Port Opened!");
		//		message = "Port Opened!";
         }
       }
       else 
       {
         if (sp.IsOpen)
         {
          print("Port is already open");
         }
         else 
         {
          print("Port == null");
         }
       }
    }

    void OnApplicationQuit() 
    {
       sp.Close();
    }
}
