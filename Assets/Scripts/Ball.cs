using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
    {

    public static GameObject BowlingBall { get; set; }
    public static GameObject curBall;


    private void Start()
        {
        RespawnBall();
        }

    static public IEnumerator DestroyBall()
        {
        yield return new WaitForEndOfFrame();
        Destroy(BowlingBall);
        }

    static public IEnumerator RespawnBall()
        {
        yield return new WaitForEndOfFrame();
        BowlingBall = Resources.Load("Bowling Ball") as GameObject;
        curBall = BowlingBall;
        }
    }
