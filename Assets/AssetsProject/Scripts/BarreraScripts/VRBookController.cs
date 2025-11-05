using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class VRBookController : MonoBehaviour
{
    public Book book;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Para saber si el libro está agarrado

    private InputDevice rightController;
    private InputDevice leftController;

    private bool isGrabbed = false;

    void Start()
    {
        grabInteractable = book.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }

        var rightDevices = new List<InputDevice>();
        var leftDevices = new List<InputDevice>();

        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightDevices);
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftDevices);

        if (rightDevices.Count > 0) rightController = rightDevices[0];
        if (leftDevices.Count > 0) leftController = leftDevices[0];
    }

    void Update()
    {
 
        if (!isGrabbed) return;


        if (!rightController.isValid)
        {
            var devices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
            if (devices.Count > 0) rightController = devices[0];
        }

        if (!leftController.isValid)
        {
            var devices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);
            if (devices.Count > 0) leftController = devices[0];
        }

        if (rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool botonB) && botonB)
        {
            book.SiguientePagina();
        }


        if (leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool botonY) && botonY)
        {
            book.PaginaAnterior();
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }
}

