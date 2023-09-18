using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    [SerializeField] Ball ball = new Ball();
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.Equals(ball.curBall))
            {
            StartCoroutine(ball.DestroyBall());
            StartCoroutine(ball.RespawnBall());
            }
        }
}
