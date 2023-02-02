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


    void Start()
    {   


        // Load character array from character selection scene
        int[] selectedCharacter = new int [] {-1,-1,-1,-1};
        for (int i = 0; i < 4; i++){
            if (PlayerPrefs.GetString("P"+i.ToString()+"joinStatus")=="true"){
                selectedCharacter[i]=PlayerPrefs.GetInt("P"+i.ToString()+"selectedCharacter");
            }
        }
        Debug.Log("已載入玩家列表: [" +string.Join(",",
        new List<int>(selectedCharacter)
        .ConvertAll(i => i.ToString()))+"]");






        
        // Define Player Controls
        PlayerControls[0] = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Tilde, KeyCode.Tab };
        PlayerControls[1] = new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.RightShift, KeyCode.RightControl };
        PlayerControls[2] = new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L, KeyCode.G, KeyCode.B };
        PlayerControls[3] = new KeyCode[] { KeyCode.Keypad8, KeyCode.Keypad5, KeyCode.Keypad4, KeyCode.Keypad6, KeyCode.Keypad3, KeyCode.KeypadPeriod };

        initializePlayers(spawnPlayer);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void initializePlayers(int num)
    {
        for (int i = 0; i < num; i++)
        {
            // Player Initialization
            GameObject playerObj = GameObject.Instantiate(PlayerPrefab);
            PlayerController player = playerObj.GetComponent<PlayerController>();
            player.transform.position = PlayerSpawn[i].position;
            player.transform.rotation = PlayerSpawn[i].rotation;
            player.PlayerId = i;
            player.UpKey = PlayerControls[i][0];
            player.DownKey = PlayerControls[i][1];
            player.LeftKey = PlayerControls[i][2];
            player.RightKey = PlayerControls[i][3];
            player.AttackKey = PlayerControls[i][4];
            player.PassKey = PlayerControls[i][5];
            player.Speed = 5.5f;
            player.Skill = skillset.skillset[i];

            playerList.Add(player);
        }
    }
}
