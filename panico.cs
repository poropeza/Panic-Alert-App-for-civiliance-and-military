using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panico : MonoBehaviour {

    float lat;
    float lon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PanicoBoton()
    {

        lat = GPS.lat;
        lon = GPS.lon;

        string mobile_num = "7771376882";
        string message = "Necesito ayuda! (Prueba de app militar)\n\nhttp://maps.google.com/?q=" + lat + "," + lon;


        //GameObject.Find("texto").GetComponent<Text>().text = message;

        #if UNITY_ANDROID
        //Android SMS URL - doesn't require encoding for sms call to work
        string URL = string.Format("sms:{0}?body={1}", mobile_num, System.Uri.EscapeDataString(message));
        #endif

        #if UNITY_IOS
                    string URL ="sms:"+mobile_num+"?&body="+ System.Uri.EscapeDataString(message);
        #endif

                //Execute Text Message
                Application.OpenURL(URL);
    }

   
}
