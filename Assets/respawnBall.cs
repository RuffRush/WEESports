using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBall : MonoBehaviour
{

    [SerializeField] Transform ball;
    [SerializeField] Transform ballRespawnPoint;
    [SerializeField] Transform pinsRespawnPoint;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject oldPins;
    [SerializeField] GameObject newPins;
    static int count;

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.Equals(ball)) { 
            respawnPlayer();
        count++;
            if (count % 2 == 0)
            {
                respawnPins();

            }
        }

       
        

    }



    public void respawnPlayer()
    {

        rb.velocity = Vector3.zero;
        ball.position = ballRespawnPoint.position;
        Physics.SyncTransforms();
        


    }
    public void respawnPins()
    {

        Destroy(oldPins);
        Instantiate(newPins);



    }

}