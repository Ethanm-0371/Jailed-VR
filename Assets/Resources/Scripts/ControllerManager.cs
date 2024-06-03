using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerManager : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;

    void Update()
    {
        if (!rightController.isValid || !leftController.isValid)
        {
            InitializeControllers();
        }
    }

    void InitializeControllers()
    {
        if (!rightController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref rightController);
        }
        if (!leftController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref rightController);
        }
    }

    void InitializeInputDevice(InputDeviceCharacteristics deviceCharacteristics, ref InputDevice varToFill)
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we're looking for
        InputDevices.GetDevicesWithCharacteristics(deviceCharacteristics, devices);

        //Our controllers might not be active and so they will not be generated from the search
        if (devices.Count > 0) //!= null
        {
            varToFill = devices[0];
        }
    }
}
