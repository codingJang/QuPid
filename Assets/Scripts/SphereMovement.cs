using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static int N = 40;
    public float A = 0.3f;
    public float k = 1.0f;
    public float w = 1.0f;
    public float h = 1.0f;
    private float t;
    public GameObject spherePrefab;
    private GameObject[,] spheres = new GameObject[N+1, N+1];
    private Vector3[,] defaultPositions = new Vector3[N+1, N+1];

    void Start()
    {
        for (int i= 0; i <= N; i++)
        {
            for (int j=0; j <= N; j++)
            {
                defaultPositions[i, j] = indexToPosition(i, j);
                spheres[i, j] = Instantiate(spherePrefab, indexToPosition(i, j), Quaternion.identity);
            }
        }
    }

    Vector3 indexToPosition(int i, int j)
    {
        Vector3 startPosition = new Vector3(1.5f-(3.0f/N)*i, h, 1.5f-(3.0f/N)*j);
        return startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        for(int i=0; i<= N; i++)
        {
            for(int j=0; j <= N; j++)
            {
                float x = defaultPositions[i, j].x;
                float z = defaultPositions[i, j].z;
                spheres[i, j].transform.localPosition = defaultPositions[i, j] + new Vector3(0, A * Mathf.Sin(k * x - w * t) * Mathf.Sin(k * z - w * t), 0);
            }
        }
    }
}
