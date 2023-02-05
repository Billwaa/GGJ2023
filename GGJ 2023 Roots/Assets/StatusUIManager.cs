using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fourPanels;
    public void AnnouceDeath (string deadPlayer){
        for (int i = 0; i < fourPanels.Length; i++){
            if (fourPanels[i].GetComponent<StatusPanel>().ReportAvailabilty()==true){
                fourPanels[i].GetComponent<StatusPanel>().ShowDeathAnnounce(playerColorToStringConverter(deadPlayer),playerColorToColorConverter(deadPlayer));
                break;
            }
        }
    }

    string playerColorToStringConverter (string playerColor){
        string result = "";
        switch (playerColor)
        {
            case "Red":
            result = "P1";
            break;
            case "Yellow":
            result = "P2";
            break;
            case "Green":
            result = "P3";
            break;
            case "Black":
            result = "P4";
            break;
            default:
            break;
        }
        return result;
    }

    Color playerColorToColorConverter (string playerColor){
        Color result = Color.white;
        switch (playerColor)
        {
            case "Red":
            result = new Color(255,0,0,.5f);

            break;
            case "Yellow":
            result = new Color(242,242,0,.5f);
            break;
            case "Green":
            result = new Color(78,0,242,.5f);
            break;
            case "Black":
            result = new Color(51,51,51,.5f);
            break;
            default:
            break;
        }
        return result;
    }
}
