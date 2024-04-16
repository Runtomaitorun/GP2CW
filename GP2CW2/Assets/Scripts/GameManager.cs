using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] flockPrefabs;
    public void OnMouseDown()
    {
        GameObject prefab = flockPrefabs[Random.Range(0, flockPrefabs.Length)];
        GameObject flock = Instantiate(prefab, transform);
        flock.transform.position = new Vector3(0, 0, 0);

    }
}
