using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class Pin : MonoBehaviour
{
    [ShowNonSerializedField]
    GameObject  pinGO;

    [ShowNonSerializedField]
    bool        isUp            = true;

    [ShowNonSerializedField]
    int         pinNum;

//---------------------------------------------------

    public Pin(GameObject pinGO, int PinNum)
        {
        pinGO   =   this.pinGO;
        isUp    =   true;
        PinNum  =   this.pinNum;
        }

    public Pin()
        {
        pinGO = null;
        isUp = true;
        pinNum = 0;
        }

    //---------------------------------------------------

    public GameObject getPinGO()
        {
        return pinGO;
        }

    public bool getIsUp()
        {
        return isUp;
        }

    public int getPinNum()
        {
        return pinNum;
        }

    public void setPinGO(GameObject pinGO)
        {
        pinGO = this.pinGO;
        }

    public void setIsUp(bool isUp)
        {
        isUp = this.isUp;
        }

    public void setPinNum(int pinNum)
        {
        pinNum = this.pinNum;
        }
    }
