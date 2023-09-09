using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBall : MonoBehaviour
{

    [SerializeField] Transform ball;
    [SerializeField] Transform ballRespawnPoint;
  
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject pins;
    static int count;

    // Start is called before the first frame update


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.Equals(ball)) { 
            respawnPlayer();
        count++;
            if (count % 2 == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Pins"));
                StartCoroutine(respawnPins());

            }
        }

       
        

    }



    public void respawnPlayer()
    {

        rb.velocity = Vector3.zero;
        ball.position = ballRespawnPoint.position;
        Physics.SyncTransforms();
        


    }
    public IEnumerator respawnPins()
    {

        yield return new WaitForEndOfFrame();
        GameObject objPrefab = Resources.Load("All Pins") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;




    }

}