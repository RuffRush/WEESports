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
    Vector3[] pinStartingRotation = new Vector3[10];
    static int count;
    int score;
    int pinsKnocked;
    int curFrame;
    int pastFrame;
    int curThrow;
    bool isStrike;
    bool isSpare;


    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(arrayFiller());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.Equals(ball)) { 
            StartCoroutine(respawnPlayer());
            count++;
            StartCoroutine(CheckMoving());
            Debug.Log("Knocked down " + pinsKnocked + " pins");
            if (count % 2 == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Pins"));
                StartCoroutine(respawnPins());

                
            }
            scoreKeeper();
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
            pinStartingRotation[i] = pinArray[i].transform.rotation.eulerAngles;
            }
        Debug.Log("David, Arrays have been filled");
        }
   

    

    public IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
        ball.position = ballRespawnPoint.position;
        Physics.SyncTransforms();
        


    }
    public IEnumerator respawnPins()
    {

        yield return new WaitForSeconds(1);
        GameObject objPrefab = Resources.Load("All Pins") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
        StartCoroutine(arrayFiller());




    }

    public IEnumerator CheckMoving()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {

            
            Vector3 finalPos = pinArray[i].transform.rotation.eulerAngles;
            if (pinStartingRotation[i].x != finalPos.x)
            {
                Destroy(GameObject.FindGameObjectWithTag("pin" + i));
                pinsKnocked++;
            }
        }
    }

    void scoreKeeper()
    {
        curThrow = pinsKnocked;
        curFrame = curThrow + pinsKnocked;



        if (isStrike)
        {
            curFrame = curThrow*2 + pinsKnocked*2 + 10;
           
            Debug.Log("Ater Strike Score: " + curFrame);
        }

        if (pinsKnocked == 10 && count % 1 == 1)
        {
            
            Debug.Log("STRIKE");
            isStrike = true;
            respawnPins();
        }
        Debug.Log("Your score is: " + score);
        pinsKnocked = 0;
    }
}