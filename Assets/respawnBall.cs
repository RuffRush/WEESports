using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBall : MonoBehaviour
{

    [SerializeField] Transform ball;
    [SerializeField] Transform respawnPoint;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        ball.transform.position = respawnPoint.transform.position;

    }
}
