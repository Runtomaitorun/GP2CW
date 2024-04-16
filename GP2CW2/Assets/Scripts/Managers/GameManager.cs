using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] flockPrefabs;
    public Canvas ideaBubble;
    public void OnMouseDown()
    {
        // initiate flocks
        int flockIndex = IdeaSelection();
        InitiateFlocks(flockIndex);

        // Pass the index to ideaBudbble
        ShowIdeas showIdeas = ideaBubble.GetComponent<ShowIdeas>();
        if (showIdeas != null)
        {
            showIdeas.PickIdeas(ideaBubble, flockIndex);
        }
        else
        Debug.Log("can't find the script ShowIdeas!");
        
        
        

    }
    public int IdeaSelection()
    {
        int flockIndex = Random.Range(0, flockPrefabs.Length);
        return flockIndex;
    }

    public void InitiateFlocks(int flockIndex)
    {
        
        GameObject prefab = flockPrefabs[flockIndex];
        GameObject flock = Instantiate(prefab, transform);
        flock.transform.position = new Vector3(0, 0, 0);
    }
}
