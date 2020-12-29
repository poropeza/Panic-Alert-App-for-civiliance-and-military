using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class haversine : MonoBehaviour
{

    static double _eQuatorialEarthRadius = 6378.1370D;
    static double _d2r = (Math.PI / 180D);
    static double meLat;
    static double meLong;
    GPS coordenadas;

    // Use this for initialization
    void Start ()
    {
        //var meLat = 18.909299;
        //double meLong = -99.2129802;

        //yo y el destino
        //var result1 = HaversineInKM(meLat, meLong, 18.934449, -99.2307994);

        //Debug.Log(result1);

        meLat = GPS.lat;
        meLong = GPS.lon;
    }
	
	// Update is called once per frame
	void Update ()
    {
        meLat = GPS.lat;
        meLong = GPS.lon;

    }

    private static int HaversineInM(double lat2, double long2)
    {
        return (int)(1000D * HaversineInKM(lat2, long2));
    }

    public static double HaversineInKM(double lat2, double long2)
    {
        double lat1 = meLat;
        double long1 = meLong;

        double dlong = (long2 - long1) * _d2r;
        double dlat = (lat2 - lat1) * _d2r;
        double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
        double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
        double d = _eQuatorialEarthRadius * c;

        return d;
    }

}
