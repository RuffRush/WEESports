using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using Sirenix.Serialization;

public class PinManager : Pin
    {
    
    [ShowInInspector] [ReadOnly]
    public static Pin[]       pinArray                = new Pin[10];
    [ShowInInspector][ReadOnly]
    public static Transform[] pinTransforms;
    public static Vector3[]   pinStartingLocation     = new Vector3[10];

    //[ShowNonSerializedFieldAttribute]
    

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin2;

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin3;

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin4;

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin5;

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin6;

    //[ShowNonSerializedFieldAttribute]
    //GameObject pin7;


    // Start is called before the first frame update
    void Start()
        {
      
        StartCoroutine(ArrayFiller());
        }

    
    private IEnumerator ArrayFiller()
        {
        yield return new WaitForEndOfFrame();
        GameObject rootGO = GameObject.Find("All Pins");
        pinTransforms = new Transform[rootGO.transform.childCount];
        for (int i = 0; i < rootGO.transform.childCount; i++)
            { 
            pinTransforms[i] = rootGO.transform.GetChild(i);
            pinArray[i] = pinTransforms[i].AddComponent<Pin>();
            //pinArray[i].setPinGO();
            pinArray[i].setPinNum(i + 1);
            pinStartingLocation[i] = pinArray[i].transform.eulerAngles;
            //pinArray[i].setPinGO(pinTransforms[i]);
            //pinArray[i].setPinNum(i + 1);

            //pinArray[i].setPinGO(pinTransforms[i].GetComponent<Transform>());
            //pinArray[i].GetComponent<Pin>().setPinGO(pinTransforms[i]);
            }

        //PinVarFiller();
       
        }

    private void PinVarFiller()
    {
        //for (int i = 0; i < 10; i++)
        //    {
        //    if (i == 0)
        //        {
        //        pinArray[i].setPinGO(pinHolder.transform.Find("Pin").GameObject());
        //        }
        //    else
        //        {
        //        pinArray[i].setPinGO(pinHolder.transform.Find("Pin (" + i + ")").GameObject());
        //        }
        //    Debug.Log(pinArray[i].getPinGO().name);
        //    pinArray[i].setPinNum(i + 1);
        //    }
        }

    private IEnumerator RespawnPins()
        {
        yield return new WaitForSeconds(1);
        GameObject objPrefab = Resources.Load("All Pins") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
        StartCoroutine(ArrayFiller());
        }

    public static IEnumerator CheckMoved()
        {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 10; i++)
            {
            if (pinArray[i] != null)
                {
                Vector3 finalPos = pinArray[i].transform.rotation.eulerAngles;
                if (pinStartingLocation[i].x != finalPos.x)
                    {
                    pinArray[i].setIsUp(false);
                    //Destroy(GameObject.FindGameObjectWithTag("pin" + i));
                    //pinsKnocked++;
                    }
                }
            }
        }

    private int CurNumPinsDown()
        {
        int count = 0;
        for (int i = 0; i < 10; i++)
            {
            if (pinArray[i] = null)
                {
                count++;
                }
            }
        return count;
        }
    }