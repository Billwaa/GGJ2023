using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{

    public AudioClip buttonClip;
    public AudioClip startGameClip;

    public AudioSource buttonAudio;

    // Start is called before the first frame update
    void Start()
    {
        // For character scene no double sound controller
        if (GameObject.FindObjectsOfType<SoundController>().Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Billy Game Scene")
            Destroy(this.gameObject);
    }

    public void buttonClick()
    {
        buttonAudio.clip = buttonClip;
        buttonAudio.Play();
    }
    
}
