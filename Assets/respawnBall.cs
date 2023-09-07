using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBall : MonoBehaviour
{

    [SerializeField] Transform ball;
    [SerializeField] Transform respawnPoint;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        respawnPlayer();
        

    }



    public void respawnPlayer()
    {

        rb.velocity = Vector3.zero;
        ball.position = respawnPoint.position;
        Physics.SyncTransforms();
    }

}