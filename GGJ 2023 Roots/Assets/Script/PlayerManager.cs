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

    public KeyCode[][] PlayerControls = new KeyCode[4][];
    public List<PlayerController> playerList = new List<PlayerController>();

    public CharacterDatabase characterDatabase;

    public int[] selectedCharacter;

    private bool init = false;

    void Start()
    {   


        // Load character array from character selection scene
        selectedCharacter = new int [] {-1,-1,-1,-1};
        for (int i = 0; i < 4; i++){
            if (PlayerPrefs.GetString("P"+i.ToString()+"joinStatus")=="true"){
                selectedCharacter[i]=PlayerPrefs.GetInt("P"+i.ToString()+"selectedCharacter");
            }
        }
        Debug.Log("已載入玩家列表: [" +string.Join(",",
        new List<int>(selectedCharacter)
        .ConvertAll(i => i.ToString()))+"]");






        
        // Define Player Controls
        PlayerControls[0] = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.BackQuote, KeyCode.Tab };
        PlayerControls[1] = new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Period, KeyCode.Slash };
        PlayerControls[2] = new KeyCode[] { KeyCode.Keypad8, KeyCode.Keypad5, KeyCode.Keypad4, KeyCode.Keypad6, KeyCode.Keypad3, KeyCode.KeypadPeriod };
        PlayerControls[3] = new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L, KeyCode.G, KeyCode.B };

    }



    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            initializePlayers(selectedCharacter.Length);
            init = true;
        }
    }

    public void initializePlayers(int num)
    {
        //selectedCharacter = new int[] { 0, 1, 2, 3 };

        int playerID = 0;
        string[] name = new string[] {"Red", "Yellow", "Green", "Black"};

        for (int i = 0; i < num; i++)
        {
            //Debug.Log(selectedCharacter[i]);
            if (selectedCharacter[i] == -1)
                continue;

            //Debug.Log(characterDatabase.database[i][selectedCharacter[i]]);

            // Player Initialization
            GameObject playerObj = GameObject.Instantiate(characterDatabase.database[i][selectedCharacter[i]]);
            PlayerController player = playerObj.GetComponent<PlayerController>();
            player.transform.position = PlayerSpawn[i].position;
            player.transform.rotation = PlayerSpawn[i].rotation;
            player.PlayerId = playerID;
            player.PlayerName = name[i];
            player.UpKey = PlayerControls[i][0];
            player.DownKey = PlayerControls[i][1];
            player.LeftKey = PlayerControls[i][2];
            player.RightKey = PlayerControls[i][3];
            player.AttackKey = PlayerControls[i][4];
            player.PassKey = PlayerControls[i][5];
            player.Speed = 5.5f;
            player.skill = skillset.skillset[selectedCharacter[i]];

            playerList.Add(player);
            player.playerList = this.playerList;
            playerID++;
        }

    }
}
