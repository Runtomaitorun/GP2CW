using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] flockPrefabs;
    public Canvas ideaBubble;

    //[Header("Click Management")]
    //private FlocksData flocksData;
    //private bool canClick = true;

    [Header("Character Animaiton")]
    public float durationTime = 4f;


    public void OnMouseDown()
    {
        // Ask FlocksData if click is allowed
        if (FlocksData.flockList.Count < 6)
        {
            HandleIdeas();
        }
        else
            Debug.Log("Sorry my brain is full");


    }

    public void HandleIdeas()
    {
        // initiate flocks
        int flockIndex = IdeaSelection();
        InitiateFlocks(flockIndex);

        // Pass the index to ideaBudbble
        ShowIdeas showIdeas = ideaBubble.GetComponent<ShowIdeas>();
        if (showIdeas != null)
        {
            showIdeas.StartCoroutine(showIdeas.TackleIdeas(ideaBubble, flockIndex, durationTime));
        }
        else
            Debug.Log("can't find the script ShowIdeas!");

        // Set the animator
        StartCoroutine(SetAnimation(flockIndex));

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

        // Count the flock
        FlocksData.flockList.Add(flock);
    }

    IEnumerator SetAnimation(int flockIndex)
    {
        Animator anim = GetComponentInChildren<Animator>();
        if (anim != null)
        {
            // Play the disired animation
            anim.SetInteger("Index", flockIndex);

            yield return new WaitForSeconds(durationTime);

            // Go back to idle
            anim.SetInteger("Index", 100);
            anim.SetTrigger("BackToIdle");
        }
        else
            Debug.Log("can't find animtor in child of character");


    }
}
