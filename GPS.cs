using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public static float lat;
    public static float lon;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(IniciarGPS());
    }

    private void Update()
    {
        StartCoroutine(Rastrear());
    }

    IEnumerator Rastrear()
    {
        while (true)
        {
            //1 seconds for example
            yield return new WaitForSeconds(1f);

            if (Input.location.status == LocationServiceStatus.Running)
            {
                //Get the location data here
                lat = Input.location.lastData.latitude;
                lon = Input.location.lastData.longitude;


                PlayerPrefs.SetFloat("lat_ini", lat);
                PlayerPrefs.SetFloat("lon_ini", lon);
            }
        }
    }

    IEnumerator IniciarGPS()
    {

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            // Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;


            PlayerPrefs.SetFloat("lat_ini",lat);
            PlayerPrefs.SetFloat("lon_ini",lon);


        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
        yield break;
    }
}
