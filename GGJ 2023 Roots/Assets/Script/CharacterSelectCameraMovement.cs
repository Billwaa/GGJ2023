using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCameraMovement : MonoBehaviour
{
    private bool start = false;
    public Texture whtTexture;
    public Color fadeColor;
    public float fadeTime;
    float currentTime;
    Color colorLerp;

    void Start()
    {
        colorLerp = fadeColor;

    }

    // Update is called once per frame
    void Update()
    {

        if (start){
        currentTime += Time.deltaTime;
        colorLerp = Color.Lerp(Color.clear,fadeColor,currentTime); 
        transform.Translate(Vector3.back*Time.deltaTime*50,Space.World);
        }
    }

    public void startGame(){
        start = true;
    }

    private void OnGUI() {
        if (start){
        GUI.color = colorLerp;
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),whtTexture);
        }
    }
}
