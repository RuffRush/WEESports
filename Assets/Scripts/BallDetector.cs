using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class BallDetector : MonoBehaviour
{ 
    int firstThrow = Frame.FirstThrow;
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            StartCoroutine(Ball.RespawnBall());
            StartCoroutine(PinManager.CheckMoved());
            PinFallCheck();
            }
        }


    void PinFallCheck()
        {
        for (int i = 0; i < PinManager.pinArray.Length; i++)
            {
            if (!PinManager.pinArray[i].getIsUp())
                {
                firstThrow++;
                Destroy(PinManager.pinArray[i].gameObject);
                }
            }
        Debug.Log(firstThrow);
        }
}
