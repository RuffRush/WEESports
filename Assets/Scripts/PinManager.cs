using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;
using System;

public class PinManager : Pin
    {

    Pin[]       pinArray             = new Pin[10];
    Vector3[]   pinStartingRotation = new Vector3[10];

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
        yield return new WaitForEndOfFrame;
        pinArray[0] = gameObject.AddComponent<Pin>();
        pinArray[1] = gameObject.AddComponent<Pin>();
        pinArray[2] = gameObject.AddComponent<Pin>();
        pinArray[3] = gameObject.AddComponent<Pin>();
        pinArray[4] = gameObject.AddComponent<Pin>();
        pinArray[5] = gameObject.AddComponent<Pin>();
        pinArray[6] = gameObject.AddComponent<Pin>();
        pinArray[7] = gameObject.AddComponent<Pin>();
        pinArray[8] = gameObject.AddComponent<Pin>();
        pinArray[9] = gameObject.AddComponent<Pin>();

        PinVarFiller();
        }

    private void PinVarFiller()
    {
        for (int i = 0; i < 10; i++)
            {
            pinArray[i].setPinGO(GameObject.Find("Bowling Pin " + (i + 1)));
            pinArray[i].setPinNum(i + 1);
            }
        }

    private IEnumerator RespawnPins()
        {
        yield return new WaitForSeconds(1);
        GameObject objPrefab = Resources.Load("All Pins") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
        StartCoroutine(ArrayFiller());
        }

    void CheckMoved()
        {
        for (int i = 0; i < 10; i++)
            {
            if (pinArray[i] != null)
                {
                Vector3 finalPos = pinArray[i].transform.rotation.eulerAngles;
                if (pinStartingRotation[i].x != finalPos.x)
                    {
                    pinArray[i].setIsUp(false);
                    Destroy(GameObject.FindGameObjectWithTag("pin" + i));
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