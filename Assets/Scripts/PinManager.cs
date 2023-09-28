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
    static Transform[] pinTransforms;
    static Vector3[] pinStartingLocation = new Vector3[10];



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
            pinArray[i] = pinTransforms[i].GetComponent<Pin>();
            //pinArray[i].setPinGO();
            //pinArray[i].setPinNum(i + 1);
            pinStartingLocation[i] = pinTransforms[i].localRotation.eulerAngles; ;
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

    public async static void CheckMoved()
        {
        
        for (int i = 0; i < 10; i++)
            {
            if (pinArray[i] != null)
                {
                await Task.Delay(200);
                GameObject rootGO = GameObject.Find("All Pins");
                Vector3 finalPos = rootGO.transform.GetChild(i).transform.localRotation.eulerAngles;
                if (pinStartingLocation[i].x != finalPos.x)
                    {
                    await Task.Yield();
                    pinArray[i].setIsUp(false);
                    Frame.FirstThrow++;

                    //Destroy(GameObject.FindGameObjectWithTag("pin" + i));
                    //pinsKnocked++;
                    }
                }
            }
        Debug.Log(Frame.FirstThrow);

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