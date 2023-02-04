using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] player1Characters;
    public GameObject[] player2Characters;
    public GameObject[] player3Characters;
    public GameObject[] player4Characters;

    public GameObject[][] database;


    void Start()
    {
        Debug.Log("database");
        database = new GameObject[4][];

        database[0] = new GameObject[4];
        database[1] = new GameObject[4];
        database[2] = new GameObject[4];
        database[3] = new GameObject[4];

        for (int i = 0; i < 4; i++)
        {
            database[0][i] = player1Characters[i];
            database[1][i] = player2Characters[i];
            database[2][i] = player3Characters[i];
            database[3][i] = player4Characters[i];
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
