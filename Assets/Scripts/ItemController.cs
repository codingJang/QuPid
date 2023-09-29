using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> itemPrefabs;
    private List<GameObject> itemInstances = new List<GameObject>();
    [SerializeField]
    private List<Vector3> itemPositions;
    void Start()
    {
        for(int i=0; i<itemPositions.Count; i++)
        {
            GameObject instantiatedItem = Instantiate(itemPrefabs[i], itemPositions[i], Quaternion.identity);
            instantiatedItem.transform.SetParent(this.transform);
            itemInstances.Add(instantiatedItem);
        }
    }
}
