using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class Pin : MonoBehaviour
{
    [ShowInInspector]
 public Transform   pinGO;

    [ShowInInspector]
 public bool        isUp        = true;

    [ShowInInspector]
 public int         pinNum;

//---------------------------------------------------

    public Pin(Transform pinGO, int PinNum)
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

    public Transform getPinGO()
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

    public void setPinGO(Transform pinGO)
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
