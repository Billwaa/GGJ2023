using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public enum readyStatus {
    RETIRED,SELECTING,READY
};

public class CharacterSelect : MonoBehaviour
{

    public GameObject[] characters;
    public int selectedCharacter = 0;
    public int playerPosition;
    public GameObject joinCanvas;
    public GameObject selectingCanvas;
    public GameObject readyCanvas;
    public GameObject joinText;
    public GameObject retireText1;
    public GameObject retireText2;

    string[] confirmKeyMap = {"<sprite=0>","<sprite=2>","<sprite=5>","<sprite=9>"};
    string[] cancelKeyMap = {"<sprite=1>","<sprite=4>","<sprite=8>","<sprite=10>"};


    private readyStatus playerReadyStatus = readyStatus.RETIRED;

    public int getCharacterSelected(){
    return selectedCharacter;
    }
    public readyStatus getReadyStatus(){
    return playerReadyStatus;
    }

    private void Start() {
        joinText.GetComponent<TextMeshProUGUI>().text=confirmKeyMap[playerPosition]+" to Join";
        retireText1.GetComponent<TextMeshProUGUI>().text=cancelKeyMap[playerPosition]+" to Cancel";
        retireText2.GetComponent<TextMeshProUGUI>().text=cancelKeyMap[playerPosition]+" to Cancel";
    }

    public void Confirm(){
        switch (playerReadyStatus)
        {
            case readyStatus.RETIRED:
            playerReadyStatus = readyStatus.SELECTING;
            selectedCharacter = 0;
            characters[0].SetActive(true);
            joinCanvas.SetActive(false);
            selectingCanvas.SetActive(true);
            readyCanvas.SetActive(false);
            break;

            case readyStatus.SELECTING:
            playerReadyStatus = readyStatus.READY;

            joinCanvas.SetActive(false);
            selectingCanvas.SetActive(false);
            readyCanvas.SetActive(true);
            break;

            default:
            break;
        }
    }

    public void Cancel(){
        switch (playerReadyStatus)
        {
            case readyStatus.READY:
            playerReadyStatus = readyStatus.SELECTING;
            joinCanvas.SetActive(false);
            selectingCanvas.SetActive(true);
            readyCanvas.SetActive(false);
            break;

            case readyStatus.SELECTING:
            characters[selectedCharacter].SetActive(false);
            playerReadyStatus = readyStatus.RETIRED;
            joinCanvas.SetActive(true);
            selectingCanvas.SetActive(false);
            readyCanvas.SetActive(false);
            break;
            
            default:
            break;
        }
    }



    public void NextCharacter(){
        if (playerReadyStatus != readyStatus.SELECTING) {return;}
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter+1)%characters.Length;
        characters[selectedCharacter].SetActive(true);
        
    }

    public void PreviousCharacter(){
    if (playerReadyStatus != readyStatus.SELECTING) {return;}
    characters[selectedCharacter].SetActive(false);
    selectedCharacter--;
    if (selectedCharacter < 0){
        selectedCharacter += characters.Length;
    }
    characters[selectedCharacter].SetActive(true);
    
    }


    void Update()
    {
        if (Input.GetButtonDown("P"+(playerPosition+1).ToString()+"A"))
        {            Debug.Log("P"+playerPosition.ToString()+"Triggered Confirm");
            Confirm();
            Debug.Log("P"+playerPosition.ToString()+"Triggered Confirm");
        }
        if (Input.GetButtonDown("P"+(playerPosition+1).ToString()+"B"))
        {
            Cancel();
            Debug.Log("P"+playerPosition.ToString()+"Triggered Cancel");
        }
        if (Input.GetButtonDown("P"+(playerPosition+1).ToString()+"Right"))
        {
            NextCharacter();
            Debug.Log("P"+playerPosition.ToString()+"Triggered next Char");
        }else if (Input.GetButtonDown("P"+(playerPosition+1).ToString()+"Left"))
        {
            PreviousCharacter();
            Debug.Log("Triggered prev Char");
        }
    }

    


}
