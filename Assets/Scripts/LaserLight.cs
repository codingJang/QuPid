using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLight : NewGrabInteractable
{
    [SerializeField]
    private GameObject laserControllerPrefab;
    private GameObject laserController;
    
    protected override void Awake()
    {
        base.Awake();
        laserController = Instantiate(laserControllerPrefab, this.transform.position, this.transform.rotation);
        laserController.transform.parent = this.transform;
        laserController.SetActive(false);
    }

    private void Update()
    {
        laserController.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
    }
    public override void SwitchOnOff(bool value)
    {
        base.SwitchOnOff(value);
        laserController.SetActive(value);
    }
}
