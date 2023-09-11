using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBall : MonoBehaviour
{

    [SerializeField] Transform ball;
    [SerializeField] Transform ballRespawnPoint;

    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject pins;

    GameObject[] pinArray = new GameObject[10];
    Vector3[] pinStartingLocation = new Vector3[10];
    static int count;
    int score;
    int pinsKnocked;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(arrayFiller());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.Equals(ball)) { 
            respawnPlayer();
        count++;
            Debug.Log("Knocked down " + pinsKnocked + " pins");
            StartCoroutine(CheckMoving());
            if (count % 2 == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Pins"));
                StartCoroutine(respawnPins());
                score = pinsKnocked;
                pinsKnocked = 0;
                Debug.Log("Your score is: " +score);
            }
        }


    }

    public IEnumerator arrayFiller()
    {
            yield return new WaitForSeconds(1);
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
                pinStartingLocation[i] = pinArray[i].transform.position;
            }
        Debug.Log("David, Arrays have been filled");
        }
   

    

    public void respawnPlayer()
    {

        rb.velocity = Vector3.zero;
        ball.position = ballRespawnPoint.position;
        Physics.SyncTransforms();
        


    }
    public IEnumerator respawnPins()
    {

        yield return new WaitForEndOfFrame();
        GameObject objPrefab = Resources.Load("All Pins") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
        StartCoroutine(arrayFiller());




    }

    public IEnumerator CheckMoving()
    {

        for (int i = 0; i < 10; i++)
        {

            yield return new WaitForEndOfFrame();
            Vector3 finalPos = pinArray[i].transform.position;
            if (pinStartingLocation[i].x != finalPos.x || pinStartingLocation[i].y != finalPos.y
    || pinStartingLocation[i].z != finalPos.z)
            {
                Destroy(GameObject.FindGameObjectWithTag("pin" + i));
                pinsKnocked++;
            }
        }
    }

}