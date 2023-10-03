using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using Sirenix.Serialization;
using System.Threading.Tasks;

public class PinManager : MonoBehaviour
    {




    [ShowInInspector]
    [ReadOnly]
    public static Pin[] pinArray = new Pin[10];
    [ShowInInspector]
    [ReadOnly]

    static int pinNum;
    static Transform[] pinTransforms;
    static Vector3[] pinStartingRotation = new Vector3[10];
    static Vector3[] pinStartPos = new Vector3[10];
    static GameObject[] pinGO;
    static Rigidbody[] pinRB = new Rigidbody[10];


    // Start is called before the first frame update
    void Start()
        {

        ArrayFiller();
        }


    private async void ArrayFiller()
        {
        await Task.Delay(200);
        GameObject rootGO = GameObject.Find("All Pins");
        pinNum = rootGO.transform.childCount;
        pinTransforms = new Transform[pinNum];
        pinGO = new GameObject[pinNum];
        for (int i = 0; i < pinNum; i++)
            {
            pinTransforms[i] = rootGO.transform.GetChild(i).transform;
            pinGO[i] = rootGO.transform.GetChild(i).gameObject;
            pinArray[i] = pinGO[i].GetComponent<Pin>();
            //pinArray[i].setPinGO();
            //pinArray[i].setPinNum(i + 1);

            pinStartingRotation[i] = pinArray[i].gameObject.transform.localEulerAngles;
            pinStartPos[i] = pinArray[i].gameObject.transform.localPosition;
            pinRB[i] = pinArray[i].gameObject.GetComponent<Rigidbody>();
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
        ArrayFiller();
        }

    public async static void CheckMoved()
        {
        int count = 0;
        for (int i = 0; i < pinNum; i++)
            {
            if (pinArray[i] != null)
                {
                await Task.Delay(400);

                Vector3 finalRot = pinArray[i].gameObject.transform.localEulerAngles;
                Vector3 finalPos = pinArray[i].gameObject.transform.localPosition;
                if (pinStartPos[i].y > finalPos.y)
                    {
                    await Task.Yield();
                    pinArray[i].isUp = false;
                    Frame.FirstThrow++;
                    count++;

                    //Destroy(GameObject.FindGameObjectWithTag("pin" + i));
                    //pinsKnocked++;
                    }
                }
            }
        Debug.Log(count);
        RemoveKnockedPins();
        }

    private int CurNumPinsDown()
        {
        int count = 0;
        for (int i = 0; i < pinNum; i++)
            {
            if (pinArray[i] = null)
                {
                count++;
                }
            }
        return count;
        }

    private static void RemoveKnockedPins()
        {
        for (int i = 0; i < pinNum; i++)
            {
            Debug.Log(pinArray[i].isUp);
            if (!pinArray[i].isUp)
                {
                pinRB[i].isKinematic = true;
                pinArray[i].gameObject.transform.localPosition = new Vector3(pinStartPos[i].x, pinStartPos[i].y, pinStartPos[i].z + 10);
                pinArray[i].gameObject.transform.localEulerAngles = pinStartingRotation[i];
                }
            }

        }

    public static void movePinsToOriginal()
        {
        for (int i = 0; i < pinNum; i++)
            {
            pinArray[i].gameObject.transform.localPosition = pinArray[i].gameObject.transform.localPosition = pinStartPos[i];
            }
        for (int i = 0; i < pinNum; i++)
            {
            pinRB[i].isKinematic = true;
            }

        }
    }