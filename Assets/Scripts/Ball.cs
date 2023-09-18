using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
    {

    [SerializeField] GameObject BowlingBall { get; set; }
    [SerializeField] public  GameObject curBall;


    private void Start()
        {
        Debug.Log("Balls First Spawn");
        StartCoroutine(RespawnBall());
        }

     public IEnumerator DestroyBall()
        {
        yield return new WaitForEndOfFrame();
        Destroy(curBall);
        }

     public IEnumerator RespawnBall()
        {
        yield return new WaitForEndOfFrame();
        GameObject objectPrefab = Resources.Load("BowlingBall") as GameObject;
        Instantiate(curBall);
        Instantiate(objectPrefab);
        BowlingBall = GameObject.FindGameObjectWithTag("BowlingBall");
        }
    }
