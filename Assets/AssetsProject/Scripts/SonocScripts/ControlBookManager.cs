using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ControlBookManager : MonoBehaviour
{
    public XRBaseInteractor _leftInteractor;
    public InputActionProperty GrabBook;
    public bool bookInHand = false;
    private XRGrabInteractable _grabInteractable;
    public Vector3 playerInteraccionVoice;
    void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        if (_grabInteractable == null)
        {
            enabled = false;
            return;
        }
    }
    
    private void OnDisable()
    {
        if (GrabBook.action != null)
        {
            GrabBook.action.performed -= OnGrabAction;
            GrabBook.action.canceled -= OnGrabAction;
            GrabBook.action.Disable();
        }
    }

    private void OnEnable()
    {
        if (GrabBook.action != null)
        {
            GrabBook.action.Enable();
            GrabBook.action.performed += OnGrabAction;
            GrabBook.action.canceled += OnGrabAction;
        }
    }

    private void OnGrabAction(InputAction.CallbackContext context)
    {
        bool grab = context.ReadValue<float>() > 0.1f;
        if (grab && !bookInHand)
        {
            TryToGrabBook(_leftInteractor);
            AudioManager.Instance.PlayReadBook(playerInteraccionVoice);
        }
        else if (grab && bookInHand)
        {
            TryToThrowBook(_leftInteractor);
        }
        else
        {
            Debug.Log("no esta el libro carnal");
        }
    }

    private void TryToGrabBook(XRBaseInteractor interactor)
    {
        interactor.StartManualInteraction((IXRSelectInteractable)_grabInteractable);
        _grabInteractable.transform.SetPositionAndRotation(interactor.attachTransform.position, interactor.attachTransform.rotation);
        bookInHand = true;
    }

    private void TryToThrowBook(XRBaseInteractor interactor)
    {
        if (bookInHand)
        {
            interactor.EndManualInteraction();
            bookInHand = false;
        }
    }
}
