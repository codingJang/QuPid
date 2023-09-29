using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewSocketInteractor : XRSocketInteractor
{
    protected override void OnSelectEntering(XRBaseInteractable interactable)
    {
        base.OnSelectEntering(interactable);
    }

    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        // Debug.Log(interactable);

        if(interactable is NewGrabInteractable)
        {
            OnNewGrabInteractableAttached(interactable as NewGrabInteractable);
        } 

    }

    public void OnNewGrabInteractableAttached(NewGrabInteractable interactable)
    {
        this.attachTransform = this.transform;

        Quaternion minAngleRotation = Quaternion.identity;
        float minAngle = 1000.0f;

        foreach (Quaternion rotation in interactable.possibleRotations)
        {
            float angle = Quaternion.Angle(interactable.transform.rotation, rotation);
            if (angle < minAngle)
            {
                minAngle = angle;
                minAngleRotation = rotation;
            }
        }
        this.attachTransform.rotation = minAngleRotation;
    }
}
