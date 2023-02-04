
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillyGameSceneCamera : MonoBehaviour
{
    private bool start = false;
    public Texture whtTexture;
    public Color fadeColor;
    public float fadeTime;
    public float rotateXStart = 20;
    public float rotateXEnd = 37.574f;
    public float rotationSpeed = 10f;
    float currentTime;
    Color colorLerp;

    void Start()
    {
        colorLerp = fadeColor;
    }

    void Update()
    {

        currentTime += Time.deltaTime;
        colorLerp = Color.Lerp(fadeColor,Color.clear,currentTime/fadeTime); 

        if (transform.eulerAngles.x < rotateXEnd){
            transform.Rotate ( Vector3.right * ( rotationSpeed * Time.deltaTime ) );
        }

    }

    private void OnGUI() {

        GUI.color = colorLerp;
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),whtTexture);

    }
}
