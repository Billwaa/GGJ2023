using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelect : MonoBehaviour
{

    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter+1)%characters.Length;
        characters[selectedCharacter].SetActive(true);
        
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            NextCharacter();
            Debug.Log("123");
        }

    }
    
    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharcater",selectedCharacter);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

}
