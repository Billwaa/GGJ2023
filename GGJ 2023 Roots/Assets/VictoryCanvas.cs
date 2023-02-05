using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class VictoryCanvas : MonoBehaviour
{
    public GameObject playerPosition;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Victory(string winner){

        switch (winner)
        {
            case "Red":
            playerPosition.GetComponent<TextMeshProUGUI>().text="P1";
            playerPosition.GetComponent<TextMeshProUGUI>().color=Color.red;
            break;
            case "Yellow":
            playerPosition.GetComponent<TextMeshProUGUI>().text="P2";
            playerPosition.GetComponent<TextMeshProUGUI>().color=Color.yellow;
            break;
            case "Green":
            playerPosition.GetComponent<TextMeshProUGUI>().text="P3";
            playerPosition.GetComponent<TextMeshProUGUI>().color=Color.green;
            break;
            case "Black":
            playerPosition.GetComponent<TextMeshProUGUI>().text="P4";
            playerPosition.GetComponent<TextMeshProUGUI>().color=Color.grey;
            break;
            default:
            break;
        }

    }
    public void Rematch(){
        Debug.Log("Rematch()!");
        SceneManager.LoadScene("Billy Game Scene",LoadSceneMode.Single);
    }
    public void CharacterSelect(){
        SceneManager.LoadScene("CharacterSelection",LoadSceneMode.Single);
    }
    public void MainMenu(){
SceneManager.LoadScene("StartMenu");
    }
}
