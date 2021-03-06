﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>This is used in Global for selecting a checkbox in the checklist screen, not to be used elsewhere.
/// <para>This is a class based on MonoBehaviour, IPointerEnterHandler and IPointerExitHandler. </para>
/// <seealso cref="GlobalVariables"/> 
/// </summary>
public class MapSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool active = false;
    private bool completed = false; //made true by a completedImage GameObject
    public bool isCompletedImage = false;
    private Image image;
    public Sprite activeImage;
    public Sprite selectedImage;
    public MapSelection ogImage; //only used for completedImage GameObjects
    public AudioSource sfxSource;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        if(!isCompletedImage)
        {
            if(active)
            {
                image.color = Color.white;
                image.sprite = activeImage;
                image.raycastTarget = true;
            }
            else
            {
                image.color = Color.clear;
                image.raycastTarget = false;
            }
        }
        else
        {
            ogImage.active = false;
            ogImage.image.color = Color.clear;
            ogImage.image.raycastTarget = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isCompletedImage && active)
        {
            sfxSource.Play();
            image.sprite = selectedImage;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(!isCompletedImage && active) image.sprite = activeImage;
    }
}
