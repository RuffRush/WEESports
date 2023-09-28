using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading.Tasks;


public class BallDetector : MonoBehaviour
{ 
    int firstThrow = Frame.FirstThrow;
    private void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            StartCoroutine(Ball.RespawnBall());
            PinManager.CheckMoved();
            //Wait();
            //PinFallCheck();
            }
        }


    //void PinFallCheck()
    //    {
    //    for (int i = 0; i < PinManager.pinArray.Length; i++)
    //        {
    //        if (PinManager.pinArray[i] != null && PinManager.pinArray[i].getIsUp() == false)
    //            {
    //            firstThrow++;
    //            Destroy(PinManager.pinArray[i].gameObject);
    //            }
    //        }
    //    Debug.Log(firstThrow);
    //    }

    async void Wait()
        {
        await Task.Delay(2000);
        }
}
