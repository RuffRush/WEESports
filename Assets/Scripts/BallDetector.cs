using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.Equals(Ball.curBall))
            {
            StartCoroutine(Ball.DestroyBall());
            StartCoroutine(Ball.RespawnBall());
            }
        }
}
