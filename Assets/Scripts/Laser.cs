using UnityEngine;
using System.Collections;
using CSML;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    // Use this for initialization
    [SerializeField]
    private double alpha0;
    [SerializeField]
    private double alpha1;
    [SerializeField]
    private double beta0;
    [SerializeField]
    private double beta1;
    private Complex alpha;
    private Complex beta;
    private double absAlpha;
    private double absBeta;
    private float norm;
    void Awake()
    {
        Debug.LogFormat("Laser Awake() : alpha = {0}+{1}i, beta = {2}+{3}i | parent = {4}", alpha0, alpha1, beta0, beta1, this.transform.parent);
        alpha = new Complex(alpha0, alpha1);
        beta = new Complex(beta0, beta1);
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, this.transform.position);
        absAlpha = Complex.Abs(alpha);
        absBeta = Complex.Abs(beta);
        norm = Mathf.Sqrt((float)(absAlpha * absAlpha + absBeta * absBeta));
        lr.SetWidth(norm * 0.01f, norm * 0.01f);
        RaycastHit hitInfo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo))
        {
            Debug.LogFormat("Raycast has hit {0}", hitInfo.collider.gameObject);
            lr.SetPosition(1, hitInfo.point);
            Vector3 v = this.transform.forward;
            Vector3 n = hitInfo.normal;
            Vector3 w = v - 2 * Vector3.Dot(n, v) * n;
            GameObject hitObject = hitInfo.collider.gameObject;
            Complex tempAlpha = alpha;
            Complex tempBeta = beta;
            // Debug.Log(v.ToString() + n.ToString() + r.ToString());
            if (hitObject.layer == LayerMask.NameToLayer("Reflective"))
            {
                Laser reflectedLaser = Instantiate(this, hitInfo.point, Quaternion.LookRotation(w, this.transform.up));
                reflectedLaser.transform.parent = this.transform;
            }
            else if (hitObject.layer == LayerMask.NameToLayer("BeamSplitting"))
            {
                // Debug.Log("Hit BS");
                this.SetAlphaBeta(Complex.Zero, tempBeta);
                Laser reflectedLaser = Instantiate(this, hitInfo.point, Quaternion.LookRotation(w, this.transform.up));
                this.SetAlphaBeta(tempAlpha, Complex.Zero);
                Laser permeatedLaser = Instantiate(this, hitInfo.point + 0.005f * v, Quaternion.LookRotation(v, this.transform.up));
                this.SetAlphaBeta(tempAlpha, tempBeta);
                reflectedLaser.transform.parent = this.transform;
                permeatedLaser.transform.parent = this.transform;
            }
            else if (hitObject.layer == LayerMask.NameToLayer("Retarding"))
            {
                Debug.Log("Something's Wrong");
                WavePlate wp = hitObject.GetComponentInParent<WavePlate>();
                // Vector3 WPNormal = hitObject.transform.forward;
                Matrix outputVector = wp.matrix * new Matrix(new Complex[] { tempAlpha, tempBeta });
                Debug.LogFormat("outputVector = {0}", outputVector.ToString());
                this.SetAlphaBeta(outputVector[1], outputVector[2]);
                Laser permeatedLaser = Instantiate(this, hitInfo.point + 0.005f * v, Quaternion.LookRotation(v, this.transform.up));
                this.SetAlphaBeta(tempAlpha, tempBeta);
                permeatedLaser.transform.parent = this.transform;
            }
            else if (hitObject.layer == LayerMask.NameToLayer("PolarizationChecking"))
            {
                PolarizationChecker pc = hitObject.GetComponentInParent<PolarizationChecker>();
                pc.UpdatePolarizationInfo(tempAlpha, tempBeta);
                Vector3 WPNormal = hitObject.transform.forward;
                Laser permeatedLaser = Instantiate(this, hitInfo.point + 0.005f * v, Quaternion.LookRotation(v, this.transform.up));
                permeatedLaser.transform.parent = this.transform;
            }
        }
        else
        {
            lr.SetPosition(1, this.transform.forward * 5000);
        }
    }
    public void SetAlphaBeta(Complex alpha, Complex beta)
    {
        this.alpha = alpha;
        this.beta = beta;
        this.alpha0 = alpha.Re;
        this.alpha1 = alpha.Im;
        this.beta0 = beta.Re;
        this.beta1 = beta.Im;
    }
}