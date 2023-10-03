using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
    {

    [SerializeField] static GameObject BowlingBall { get; set; }
    [SerializeField] GameObject respawnWall;
   

    private void Start()
    {
        SpawnBall();
        }


    async void SpawnBall()
        {
        await Task.Delay(300);
        BowlingBall = Resources.Load("BowlingBall") as GameObject;
        Instantiate(BowlingBall);
        }

    public static async void RespawnBall()
        {
        GameObject curBall = GameObject.FindGameObjectWithTag("BowlingBall");
        await Task.Delay(200);
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
