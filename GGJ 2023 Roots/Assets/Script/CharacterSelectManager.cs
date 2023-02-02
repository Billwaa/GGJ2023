using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    public GameObject[] characterSelections;

    void BeginGameCheck(){

        bool steadyGo = true;
        int playerNumber = 0;
        for (int i = 0; i < characterSelections.Length; i++)
        {
            if (characterSelections[0].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.SELECTING){
                steadyGo = false;
                break;
            }
        }

        if (!steadyGo){
        Debug.Log("還有人未準備好!");
        return;
        }


        for (int i = 0; i < characterSelections.Length; i++){
            if (characterSelections[0].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.RETIRED){
                PlayerPrefs.SetString("P"+i.ToString()+"joinStatus","false");
            }
            
            if (characterSelections[0].GetComponent<CharacterSelect>().getReadyStatus()==readyStatus.READY){
                playerNumber +=1;
                PlayerPrefs.SetString("P"+i.ToString()+"joinStatus","true");
                PlayerPrefs.SetInt("P"+i.ToString()+"selectedCharacter",characterSelections[0].GetComponent<CharacterSelect>().getCharacterSelected());
            }
        }

        if (playerNumber<2){
        Debug.Log("至少需要2名玩家!");
        return;
        }

        Debug.Log("觸發開始遊戲");
        BeginGame();

    }

    void BeginGame(){

        Debug.Log("開始遊戲");

    }
        
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            BeginGameCheck();

        }
    }
}
