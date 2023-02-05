using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Bulld number of scene to start when start button is pressed
    public int gameStartScene;


    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("CharacterSelection");

    }
}
