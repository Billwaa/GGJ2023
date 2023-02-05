using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundController : MonoBehaviour
{
    public AudioClip buttonClickClip;
    public AudioClip gameStartClip;
    public AudioClip confirmSelectionClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClick()
    {
        audioSource.clip = buttonClickClip;
        audioSource.Play();
    }
}
