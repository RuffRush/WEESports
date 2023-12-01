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
        StartCoroutine(StartRunFunctions(other)); 
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
     IEnumerator StartRunFunctions(Collider trigger)
        {


        if (trigger.gameObject.transform.Equals(GameObject.FindGameObjectWithTag("BowlingBall").transform))
            {
            yield return StartCoroutine(RunFunctions());

            }
        }

    IEnumerator RunFunctions()
        {
        yield return new WaitForSeconds(5f);
        pinManager.CheckMoved();
        Task.WaitAll();
        Ball.RespawnBall();
        game.roll(pinManager.getKnockedPins());
        pinManager.resetKnockedPins();
        Score.updateScore(game);
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
    
    
