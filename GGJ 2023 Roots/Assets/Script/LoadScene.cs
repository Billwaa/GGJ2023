using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadGalleryScene()
    {
        SceneManager.LoadScene("GalleryScene");
    }
     public void LoadHelpScene()
    {
        SceneManager.LoadScene("Help");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
