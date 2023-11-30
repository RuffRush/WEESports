using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading.Tasks;


public class BallDetector : MonoBehaviour
    {
    bool pinsKnocked;

    public int count;
    [ShowInInspector]
    public BowlingGame game;
    public PinManager pinManager;

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
    private void Start()
    {
        
    }

    private void Awake()
    {
        
        }
    async void RunFunctions(Collider trigger)
        {

        await Task.Yield();
        await Task.Delay(400);
        Task.WaitAll(); 
        if (trigger.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            await Task.Delay(10);
            await Task.Run(() => pinManager.CheckMoved());
            await Task.Yield();
            Task.WaitAll();
            Ball.RespawnBall();
            await Task.Yield();
            game.roll(pinManager.getKnockedPins());
            pinManager.resetKnockedPins();
            await Task.Run(() => Score.updateScore(game));
            await Task.Yield();
            }
        }

    private void Update()
        {
        int pinKinCount = 0;
        //for (int i = 0; i < pinManager.pinArray.Length; i++)
        //    {
        //    if (pinManager.pinArray[i].getPinRB().isKinematic)
        //        {

        //        pinKinCount++;

        //        }
        //    }
        for (int i = 0; i < pinManager.pinArray.Length; i++)
            {
            if (count == 10 || pinKinCount == 10)
                {

            pinManager.MovePinsToOriginal();
            pinKinCount = 0;
            }
        }

            }
        }
    
    
