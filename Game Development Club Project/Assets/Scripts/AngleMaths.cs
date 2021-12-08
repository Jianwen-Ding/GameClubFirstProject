using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleMaths : MonoBehaviour
{
    public static float DistPoints(float Point1X, float Point1Y, float Point2X, float Point2Y)
    {
        return Mathf.Sqrt((Point1X - Point2X) * (Point1X - Point2X) + (Point1Y - Point2Y) * (Point1Y - Point2Y));
    }
    public static float AngleBetweenTwoPoints(float Point1X, float Point1Y, float Point2X, float Point2Y)
    {
        return Mathf.Rad2Deg*Mathf.Atan2((Point2Y- Point1Y), (Point2X- Point1X)); 
    }
    public static Vector2 locationOutOfAngle(float Length, float Angle)
    {
        return new Vector2(Length*Mathf.Cos(Mathf.Deg2Rad *Angle), Length * Mathf.Sin(Mathf.Deg2Rad * Angle));
    }
}
