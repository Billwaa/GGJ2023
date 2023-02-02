using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name)
        {
            case "PlayButton":
                SceneManager.LoadScene("CharacterSelectScene");
                break;
            case "GalleryButton":
                SceneManager.LoadScene("CharacterGalleryScene");
                break;
            case "QuitGameButton":
                Debug.Log("Quit");
                Application.Quit();
                break;
        }
    }
}
