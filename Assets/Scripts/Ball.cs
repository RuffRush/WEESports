using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
    {

    [SerializeField] GameObject BowlingBall { get; set; }
    [SerializeField] GameObject respawnWall;
   

    private void Start()
    {
        BowlingBall = Resources.Load("BowlingBall") as GameObject;
        Instantiate(BowlingBall);
        }


    //public IEnumerator DestroyBall()
    //    {
    //    GameObject curBall = GameObject.FindGameObjectWithTag("BowlingBall");
    //    yield return new WaitForEndOfFrame();
    //    Destroy(curBall);
    //    }

     public IEnumerator RespawnBall()
        {
        GameObject curBall = GameObject.FindGameObjectWithTag("BowlingBall");
        yield return new WaitForSeconds(1);
        curBall.GetComponent<RigidBody>() = Vector3.zero;
        curBall.transform.position = BowlingBall.transform.position;
        Physics.SyncTransforms();

        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.Equals(respawnWall.transform))
            {
            StartCoroutine(DestroyBall());
            StartCoroutine(RespawnBall());
            }
    }
}
