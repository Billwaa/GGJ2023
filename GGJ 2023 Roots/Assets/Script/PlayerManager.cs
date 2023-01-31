using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    int spawnPlayer = 1;

    [SerializeField]
    GameObject PlayerPrefab;

    [SerializeField]
    Transform[] PlayerSpawn;

    [SerializeField]
    Skillset skillset;

    void Start()
    {
        initializePlayers(spawnPlayer);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void initializePlayers(int num)
    {
        if (num > 0)
        {
            GameObject player1Obj = GameObject.Instantiate(PlayerPrefab);
            PlayerController player1 = player1Obj.GetComponent<PlayerController>();
            player1.transform.position = PlayerSpawn[0].position;
            player1.transform.rotation = PlayerSpawn[0].rotation;
            player1.PlayerId = 0;
            player1.UpKey = KeyCode.W;
            player1.DownKey = KeyCode.S;
            player1.LeftKey = KeyCode.A;
            player1.RightKey = KeyCode.D;
            player1.AttackKey = KeyCode.Tilde;
            player1.PassKey = KeyCode.Tab;
            player1.Speed = 5;
            player1.Skill = skillset.skillset[0];
        }

        if (num > 1)
        {
            GameObject player2Obj = GameObject.Instantiate(PlayerPrefab);
            PlayerController player2 = player2Obj.GetComponent<PlayerController>();
            player2.transform.position = PlayerSpawn[1].position;
            player2.transform.rotation = PlayerSpawn[1].rotation;
            player2.PlayerId = 1;
            player2.UpKey = KeyCode.UpArrow;
            player2.DownKey = KeyCode.DownArrow;
            player2.LeftKey = KeyCode.LeftArrow;
            player2.RightKey = KeyCode.RightArrow;
            player2.AttackKey = KeyCode.RightShift;
            player2.PassKey = KeyCode.RightControl;
            player2.Speed = 5;
            player2.Skill = skillset.skillset[1];
        }
    }
}
