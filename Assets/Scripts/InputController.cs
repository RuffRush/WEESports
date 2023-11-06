using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;

    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;

    void GetDevice()
        {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        device = devices.FirstOrDefault();
        }

void OnEnable()
    {
        if (!device.isValid)
            {
            GetDevice();
            }
    }


    void Update()
    {
        //if (!device.isValid)
        //    {
        //    GetDevice();
        //    }

        //List<InputFeatureUsage> features = new List<InputFeatureUsage>();
        //device.TryGetFeatureUsages(features);
        //foreach(var feature in features)
        //    {
        //    Debug.Log("David, Feature " + feature.name + "type " + feature.type);
        //    }

        bool triggerButtonAction = false;

        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonAction) && triggerButtonAction)
            {
            print("hi");
            }

        bool primaryButton = false;

    }
}
