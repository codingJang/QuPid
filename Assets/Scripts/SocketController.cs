using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject socketPrefab;
    private List<GameObject> socketInstances = new List<GameObject>();
    [SerializeField]
    private List<Vector3> socketPositions;
    void Start()
    {
        foreach (var position in socketPositions)
        {
            GameObject instantiatedSocket = Instantiate(socketPrefab, position, Quaternion.identity);
            instantiatedSocket.transform.SetParent(this.transform);
            socketInstances.Add(instantiatedSocket);
        }
    }
}