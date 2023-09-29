using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSML;

public class WavePlate : NewGrabInteractable
{
    // Start is called before the first frame update
    [SerializeField]
    private float retardingAngle;
    [SerializeField]
    private float rotationAngle;
    public Matrix matrix;
    void Awake()
    {
        base.Awake();
        Complex cRetardingAngle = new Complex(retardingAngle * Mathf.PI / 180f);
        Complex cRotationAngle = new Complex(rotationAngle * Mathf.PI / 180f);

        Matrix rotateCCW = new Matrix(new Complex[,] { { Complex.Cos(cRotationAngle), -Complex.Sin(cRotationAngle)}, { Complex.Sin(cRotationAngle), Complex.Cos(cRotationAngle) } });
        Matrix rotateCW = new Matrix(new Complex[,] { { Complex.Cos(cRotationAngle), Complex.Sin(cRotationAngle)}, { -Complex.Sin(cRotationAngle), Complex.Cos(cRotationAngle) } });
        Matrix wavePlateMatrix = new Matrix(new Complex[,] { { Complex.One, Complex.Zero }, { Complex.Zero, Complex.Exp(Complex.I * cRetardingAngle) } });

        matrix = rotateCCW * wavePlateMatrix * rotateCW;

        Debug.LogFormat("{0} {1} | {2} {3}", matrix[1, 1].ToString(), matrix[1, 2].ToString(), matrix[2, 1].ToString(), matrix[2, 2].ToString());

        Debug.Log("WavePlate Awake() complete");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
