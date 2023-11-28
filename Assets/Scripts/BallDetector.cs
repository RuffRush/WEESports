using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading.Tasks;


public class BallDetector : BowlingGame
    {
    bool pinsKnocked;

    public int count;
   public static BowlingGame game = new BowlingGame();
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
            game.roll(PinManager.getKnockedPins());
            PinManager.resetKnockedPins();
            await Task.Delay(1000);
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

                pinKinCount++;

                }
            }
        for (int i = 0; i < PinManager.pinArray.Length; i++)
            {
            if (count == 10 || pinKinCount == 10)
                {

            PinManager.MovePinsToOriginal();
            pinKinCount = 0;
            }
        }

            }
        }
    
    
