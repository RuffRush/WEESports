using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class BallDetector : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            StartCoroutine(Ball.RespawnBall());
            }
        }
        
}
