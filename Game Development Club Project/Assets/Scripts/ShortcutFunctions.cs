using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutFunctions : MonoBehaviour
{
    //Angle math functions
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
    //Removes null from array of GameObjects
    public static GameObject[] compactGameObjectArray(GameObject[] compactObject)
    {
        int amountOfNonNull = 0;
        for (int i = 0; i < compactObject.Length; i++)
        {
            if (compactObject[i] != null)
            {
                amountOfNonNull++;
            }
        }
        GameObject[] tempArray = new GameObject[amountOfNonNull];
        int objectsInserted = 0; ;
        for (int i = 0; i < compactObject.Length; i++)
        {
            if (compactObject[i] != null)
            {
                tempArray[objectsInserted] = compactObject[i];
                objectsInserted++;
            }
        }
        return tempArray;
    }
    public static GameObject[] addArrays(GameObject[] Objects1, GameObject[] Objects2)
    {
        GameObject[] returnArray = new GameObject[(Objects1.Length + Objects2.Length)];
        for (int i = 0; i < Objects1.Length; i++)
        {
            returnArray[i] = Objects1[i];
        }
        for (int i = 0; i < Objects2.Length; i++)
        {
            returnArray[i + Objects1.Length] = Objects2[i];
        }
        return returnArray;
    }
    public static GameObject[] addArrays(GameObject[] Objects1, GameObject Object2)
    {
        GameObject[] returnArray = new GameObject[(Objects1.Length + 1)];
        for (int i = 0; i < Objects1.Length; i++)
        {
            returnArray[i] = Objects1[i];
        }
        returnArray[returnArray.Length - 1] = Object2;
        return returnArray;
    }
}
