using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
    {

    [SerializeField] GameObject pins;

    GameObject[] pinArray = new GameObject[10];
    Vector3[] pinStartingRotation = new Vector3[10];

    // Start is called before the first frame update
    void Start()
        {
        StartCoroutine(ArrayFiller());
        }


    private IEnumerator ArrayFiller()
        {
        yield return new WaitForEndOfFrame();
        pinArray[0] = GameObject.FindGameObjectWithTag("pin0");
        pinArray[1] = GameObject.FindGameObjectWithTag("pin1");
        pinArray[2] = GameObject.FindGameObjectWithTag("pin2");
        pinArray[3] = GameObject.FindGameObjectWithTag("pin3");
        pinArray[4] = GameObject.FindGameObjectWithTag("pin4");
        pinArray[5] = GameObject.FindGameObjectWithTag("pin5");
        pinArray[6] = GameObject.FindGameObjectWithTag("pin6");
        pinArray[7] = GameObject.FindGameObjectWithTag("pin7");
        pinArray[8] = GameObject.FindGameObjectWithTag("pin8");
        pinArray[9] = GameObject.FindGameObjectWithTag("pin9");
        for (int i = 0; i < 10; i++)
            {
            pinStartingRotation[i] = pinArray[i].transform.rotation.eulerAngles;
            }
        Debug.Log("David, Arrays have been filled");
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