using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRBookController : MonoBehaviour
{
    public Book book;

    private InputDevice rightController;
    private InputDevice leftController;

    void Start()
    {
        GetControllers();
    }

    void Update()
    {
        if (!rightController.isValid || !leftController.isValid)
            GetControllers();

        if (rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool botonB) && botonB)
        {
            book.SiguientePagina();
        }

        if (leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool botonY) && botonY)
        {
            book.PaginaAnterior();
        }
    }

    private void GetControllers()
    {
        var rightDevices = new List<InputDevice>();
        var leftDevices = new List<InputDevice>();

        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightDevices);
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftDevices);

        if (rightDevices.Count > 0) rightController = rightDevices[0];
        if (leftDevices.Count > 0) leftController = leftDevices[0];
    }
}
