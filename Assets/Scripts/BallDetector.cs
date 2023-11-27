using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading.Tasks;


public class BallDetector : MonoBehaviour
    {
    bool pinsKnocked;
    private void OnCollisionEnter(Collision collision)
        {
        RunFunctions(collision); 
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



    async void RunFunctions(Collision collision)
        {

        await Task.Yield();
        if (collision.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            PinManager.CheckMoved();
            await Task.Yield();
            Ball.RespawnBall();
            await Task.Yield();

            await Task.Delay(1000);
            if (Frame.FirstThrow == 10)
                {
                await Task.Yield();
                PinManager.MovePinsToOriginal();
                Frame.FirstThrow = 0;
                }
            await Task.Yield();
            }
        }

    private void Update()
        {
        int pinKinCount = 0;
        for (int i = 0; i < PinManager.pinArray.Length; i++)
            {
            if (PinManager.pinArray[i].getPinRB().isKinematic)
                {

                Score.frames[i].FirstThrow++;

                }
            }
        for (int i = 0; i < PinManager.pinArray.Length; i++)
            {
            if (Frame.FirstThrow == 10 || pinKinCount == 10)
                {

            PinManager.MovePinsToOriginal();
            Frame.FirstThrow = 0;
            }
        }

            }
        }
    
    
