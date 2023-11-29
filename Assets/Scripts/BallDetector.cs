using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading.Tasks;


public class BallDetector : BowlingGame
    {
    bool pinsKnocked;

    public int count;
    [ShowInInspector]
    public static BowlingGame game;

    private void OnTriggerEnter(Collider other)
    {
        RunFunctions(other); 
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


    private void Awake()
    {
        game = new BowlingGame();
        }
    async void RunFunctions(Collider trigger)
        {

        await Task.Yield();
        if (trigger.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            await Task.Delay(10);
            PinManager.CheckMoved();
            await Task.Yield();
            Ball.RespawnBall();
            await Task.Yield();
            game.roll(PinManager.getKnockedPins());
            PinManager.resetKnockedPins();
            Score.updateScore();
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
    
    
