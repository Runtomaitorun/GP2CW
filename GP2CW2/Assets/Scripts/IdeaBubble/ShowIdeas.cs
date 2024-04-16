using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIdeas : MonoBehaviour
{
    public Image imagesContainer;
    public Sprite[] ideaImages;


    public void PickIdeas(Canvas ideaBubble, int flockIndex)
    {
        // find the image component
        if (imagesContainer != null && flockIndex >= 0 && flockIndex < ideaImages.Length)
        {
            imagesContainer.sprite = ideaImages[flockIndex];
        }
        else
            Debug.Log("Image component not found or invalid flockIndex.");

    }
}
