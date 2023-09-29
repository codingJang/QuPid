using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewGrabInteractable : XRGrabInteractable
{
    [SerializeField]
    private bool isOn = false;
    [SerializeField]
    private List<Vector3> forwards = new List<Vector3>()
    {
        Vector3.forward,
        Vector3.back,
        Vector3.right,
        Vector3.left
    };
    [SerializeField]
    private List<Vector3> upwards = new List<Vector3>()
    {
        Vector3.up,
        Vector3.up,
        Vector3.up,
        Vector3.up
    };
    public List<Quaternion> possibleRotations = new List<Quaternion>();


    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < forwards.Count; i++)
        {
            possibleRotations.Add(Quaternion.LookRotation(forwards[i], upwards[i]));
        }
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if (interactor is NewSocketInteractor)
        {
            SwitchOnOff(true);
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        if (interactor is NewSocketInteractor)
        {
            SwitchOnOff(false);
        }
    }

    public virtual void SwitchOnOff(bool value)
    {
        this.isOn = value;
    }
}
