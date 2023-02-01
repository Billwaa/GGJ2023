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

        public void PreviousCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if (selectedCharacter < 0){
            selectedCharacter += characters.Length;
        }
        
        characters[selectedCharacter].SetActive(true);
        
    }


    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            NextCharacter();
            Debug.Log("Triggered next Char");
        }else if (Input.GetButtonDown("Fire1"))
        {
            PreviousCharacter();
            Debug.Log("Triggered prev Char");
        }
    }

    
    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharcater",selectedCharacter);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

}
