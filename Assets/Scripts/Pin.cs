using UnityEngine;
using Sirenix.OdinInspector;

public class Pin : MonoBehaviour
{
    [ShowInInspector]
 public Transform   pinGO;

 public Rigidbody   pinRB;

    [ShowInInspector]
 public bool        isUp        = true;

    [ShowInInspector]
 public int         pinNum;

//---------------------------------------------------

    public Pin(Transform pinGO, Rigidbody pinRB, int pinNum)
        {
        this.pinGO  =    pinGO;
        this.pinRB  =    pinRB;
        isUp        =    true;
        this.pinNum =    pinNum;
        }

    public Pin()
        {
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

    public void setPinGO()
        {
        pinGO = transform;
        }

    public void setIsUp(bool isUp)
        {
        this.isUp = isUp;
        }

    public void setPinNum(int pinNum)
        {
        this.pinNum = pinNum;
        }

    public Rigidbody getPinRB()
        {
        return pinRB;
        }
    }
