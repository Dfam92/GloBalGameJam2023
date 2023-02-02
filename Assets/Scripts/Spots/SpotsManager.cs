using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsManager : MonoBehaviour
{
    public List<Root> possibleRootsSpot;
    [SerializeField] GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomizeRoot();
    }

    public void SpawnRandomizeRoot()
    {
        Instantiate(root, possibleRootsSpot[Random.Range(0, possibleRootsSpot.Count - 1)].transform.position, Quaternion.identity);
    }
}
