using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    bool availablity = true;
    bool fadeIn = false;
    bool fadeOut = false;
    bool staying = false;
    float fadeSpeed = 3;
    float staySeconds = 0;
    float maxStaySeconds = 2f;
    float fadeInSecondCount = 0;
    float maxFadeInSecondCount = .4f;
    float fadeInXMove = 150;
    float fadeOutSecondCount = 0;
    float maxFadeOutSecondCount = .5f;
    float fadeOutXMove = 30;

    Vector3 originalVector3;

    private void Start() {
        originalVector3 = transform.position;
    }
    private void Update() {
        if (fadeIn && myUIGroup.alpha < 1){
            fadeInSecondCount += Time.deltaTime;
            transform.position = new Vector3(originalVector3.x + (1-fadeInSecondCount/maxFadeInSecondCount)*fadeInXMove,
            transform.position.y,transform.position.z);
            myUIGroup.alpha = fadeInSecondCount/maxFadeInSecondCount;

            if (myUIGroup.alpha >=1){
                fadeIn = false;
                staying = true;
                fadeInSecondCount = 0;
            }
        }

        if (staying && staySeconds <= maxStaySeconds){
            staySeconds += Time.deltaTime;
            if (staySeconds >= maxStaySeconds){
                staying = false;
                fadeOut = true;
                staySeconds = 0;
            }
        }

        if (fadeOut && myUIGroup.alpha > 0){
            fadeOutSecondCount += Time.deltaTime;
            transform.position = new Vector3(originalVector3.x - (fadeOutSecondCount/maxFadeOutSecondCount)*fadeOutXMove,
            transform.position.y,transform.position.z);
            myUIGroup.alpha = (1-fadeOutSecondCount/maxFadeOutSecondCount);

            if (myUIGroup.alpha <= 0){
                fadeOut = false;
                fadeOutSecondCount = 0;
                availablity = true;

            }
        }
    }

    public void ShowDeathAnnounce (string deadCharacter, Color playerColor){
        availablity = false;
        GetComponentInChildren<TextMeshProUGUI>().text=deadCharacter+" has been eliminated!";

        GetComponent<Image>().color = playerColor;
        fadeIn = true;
    }
    public bool ReportAvailabilty (){
        return availablity;
    }

}
