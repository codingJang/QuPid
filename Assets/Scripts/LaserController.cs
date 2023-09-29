using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSML;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject laserPrefab;
    private GameObject firstRay;
    private GameObject temp = null;
    private int cnt = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cnt%1==0)
        {
            temp = firstRay;
            // Debug.Log(temp);
            firstRay = Instantiate(laserPrefab, this.transform.position, this.transform.rotation);
            // Debug.Log(firstRay);
            firstRay.transform.parent = this.transform;
            Laser laserComponent = firstRay.GetComponent<Laser>();
            laserComponent.SetAlphaBeta(Complex.One, Complex.Zero);
            if(temp)
            {
                //Debug.Log("temp is Destroyed");
                Destroy(temp);
            }

        }
        cnt++;
    }
}
