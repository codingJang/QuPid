using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSML;

public class PolarizationChecker : NewGrabInteractable
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pointerPrefab;
    private GameObject pointer;
    [SerializeField]
    private GameObject pointPrefab;
    private GameObject point;
    private Complex alpha;
    private Complex beta;
    [SerializeField]
    private float w;
    private float t;
    private int cnt;

    private void Awake()
    {
        base.Awake();
        alpha = Complex.Zero;
        beta = Complex.Zero;
        pointer = Instantiate(pointerPrefab, this.transform.position, this.transform.rotation);
        pointer.transform.parent = this.transform;
        point = Instantiate(pointPrefab, this.transform.position, this.transform.rotation);
        point.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha != Complex.Zero || beta != Complex.Zero)
        {
            Debug.Log("Doing Something but failed");
            pointer.SetActive(true);
            point.SetActive(true);
            t += Time.deltaTime;
            float absAlpha = (float)Complex.Abs(alpha);
            float argAlpha = (float)Complex.Arg(alpha);
            float absBeta = (float)Complex.Abs(beta);
            float argBeta = (float)Complex.Arg(beta);
            float x = absAlpha * Mathf.Sin(w * t + argAlpha);
            float y = absBeta *Mathf.Sin(w * t + argBeta);
            Debug.LogFormat("absAlpha : {0} | argAlpha : {1} | absBeta : {2} | argBeta : {3} | x : {4} | y : {5}", absAlpha, argAlpha, absBeta, argBeta, x, y);
            pointer.transform.localScale = new Vector3(Mathf.Sqrt(x * x + y * y), 1, 1);
            pointer.transform.localRotation = Quaternion.Euler(0, 0, 180 / Mathf.PI * (float)Complex.Arg(new Complex(x, y)));
            point.transform.localPosition = new Vector3(0.3f * x, 0.3f * y, 0);
        }
        else
        {
            pointer.SetActive(false);
            point.SetActive(false);
        }
        if(cnt % 10 == 0)
        {
            alpha = Complex.Zero;
            beta = Complex.Zero;
        }

        cnt++;
    }

    public void UpdatePolarizationInfo(Complex alpha, Complex beta)
    {
        this.alpha = alpha;
        this.beta = beta;
    }
}
