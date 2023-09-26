using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class BallDetector : PinManager
{
 
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            StartCoroutine(Ball.RespawnBall());
            StartCoroutine(PinManager.CheckMoved());
            for (int i = 0; i < PinManager.pinArray.Length; i++)
                {
                if (!PinManager.pinArray[i].getIsUp())
                    {
                    Destroy(PinManager.pinArray[i].gameObject);
                    }
                }
            }
        }
        
}
