using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]
public class SO_IntList : ScriptableObject
{
    public List<int> listOfIntagers;

    public int lastInt;
    //public int[] arrayOfInts;

    /*private void Awake()
    {
        listOfIntagers.Add(1);
    }*/

    public void AddInt(int thisInt)
    {
        listOfIntagers.Add(thisInt);
    }
    public void SubInt(int thisInt)
    {
        listOfIntagers.Remove(thisInt);
    }
    
    public void AddInt(GameObject thisObjsInt)
    {
        listOfIntagers.Add(thisObjsInt.GetHashCode());
    }

    public void UpdateLastInt(GameObject lastAddedInt)
    {
        lastInt = lastAddedInt.transform.GetHashCode();
        //Debug.Log(lastAddedInt.transform.GetHashCode() + "is the last added int");
    }

}
