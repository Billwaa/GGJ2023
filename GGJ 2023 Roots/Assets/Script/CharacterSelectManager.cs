using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CharacterSelectManager : MonoBehaviour
{
    public GameObject[] characterSelections;
    public GameObject errorText;
    void BeginGameCheck(){

        bool steadyGo = true;
        int playerNumber = 0;
        for (int i = 0; i < characterSelections.Length; i++)
        {
            if (characterSelections[i].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.SELECTING){
                steadyGo = false;
                break;
            }
        }

        if (!steadyGo){
        errorText.SetActive(true);
        errorText.GetComponent<TextMeshProUGUI>().text="Someone is not ready!";
        Debug.Log("還有人未準備好!");
        return;
        }


        for (int i = 0; i < characterSelections.Length; i++){
            if (characterSelections[i].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.RETIRED){
                PlayerPrefs.SetString("P"+i.ToString()+"joinStatus","false");
            }
            
            if (characterSelections[i].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.READY){
                playerNumber +=1;
                PlayerPrefs.SetString("P"+i.ToString()+"joinStatus","true");
                PlayerPrefs.SetInt("P"+i.ToString()+"selectedCharacter",characterSelections[0].GetComponent<CharacterSelect>().getCharacterSelected());
            }
        }

        if (playerNumber<2){
        errorText.SetActive(true);
        errorText.GetComponent<TextMeshProUGUI>().text="Atleast 2 players are required!";
        Debug.Log("至少需要2名玩家!");
        return;
        }

        Debug.Log("觸發開始遊戲..."+playerNumber.ToString()+"人玩");
        BeginGame();

    }

    void BeginGame(){
        errorText.SetActive(false);
        Debug.Log("開始遊戲");
        SceneManager.LoadScene("Billy Test Scene",LoadSceneMode.Single);
    }
        
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            BeginGameCheck();

        }
    }
}
