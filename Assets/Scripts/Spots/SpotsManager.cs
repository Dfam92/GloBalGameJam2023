using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsManager : MonoBehaviour
{
    public List<Root> possibleRootsSpot;
    [SerializeField] List<GameObject> roots;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomizeRoot();
    }

    public void SpawnRandomizeRoot()
    {
        Instantiate(roots[Random.Range(0, roots.Count)], possibleRootsSpot[Random.Range(0, possibleRootsSpot.Count)].transform.position, Quaternion.identity);
    }
}
