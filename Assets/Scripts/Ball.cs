using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
    {

    [SerializeField] static GameObject BowlingBall { get; set; }
    [SerializeField] GameObject respawnWall;
   

    private void Start()
    {
        BowlingBall = Resources.Load("BowlingBall") as GameObject;
        Instantiate(BowlingBall);
        }




     public static IEnumerator RespawnBall()
        {
        GameObject curBall = GameObject.FindGameObjectWithTag("BowlingBall");
        yield return new WaitForSeconds(1);
        Rigidbody curBallRB = curBall.GetComponent<Rigidbody>();
        curBallRB.velocity = Vector3.zero;
        curBallRB.isKinematic = true;
        curBall.transform.position = BowlingBall.transform.position;
        curBallRB.isKinematic = false;
        Physics.SyncTransforms();

        }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.Equals(respawnWall.transform))
    //        {
    //        StartCoroutine(RespawnBall());
    //        }
    //}
}
