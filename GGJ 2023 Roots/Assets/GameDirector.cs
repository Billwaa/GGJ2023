using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GameDirector : MonoBehaviour
{
    public bool gameStart = false;
    public int countdown = 6;
    public TMP_Text text;

    private float timer;

    private TreeController treeController = null;
    private PlayerController[] playerControllers = null;
    private SeedController seedController = null;

    private bool randomSpawn = false;
    private bool[] aliveMap;
    private float messageTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        timer = countdown;                
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int count = Mathf.FloorToInt(timer);

        if (count > 0)
        {
            text.text = count.ToString();
            playerControllers = GameObject.FindObjectsOfType<PlayerController>();
            treeController = GameObject.FindObjectOfType<TreeController>();
            seedController = GameObject.FindObjectOfType<SeedController>();

            if (treeController != null)
            {               
                treeController.enabled = false;
                treeController.GetComponent<NavMeshAgent>().enabled = false;
            }

            if (playerControllers != null)
            {
                aliveMap = new bool[playerControllers.Length];

                for (int i = 0; i < playerControllers.Length; i++)
                {
                    playerControllers[i].enabled = false;
                    aliveMap[i] = true;
                }

            }

            if (!randomSpawn && seedController != null)
            {
                seedController.transform.position = new Vector3(Random.Range(-12, 12), 0, Random.Range(7, -17));
                randomSpawn = true;
            }

            if (seedController != null)
            {
                //seedController.enabled = false;
                seedController.GetComponent<NavMeshAgent>().enabled = false;
            }



        }
        else if (count > -1 && count <= 0 )
        {
            text.text = "BATTLE!";
        }
        else if (count == -1)
        {
            gameStart = true;

            for (int i = 0; i < playerControllers.Length; i++)
                playerControllers[i].enabled = true;

            if( treeController != null)
            {
                treeController.GetComponent<NavMeshAgent>().enabled = true;
                treeController.enabled = true;
            }

            if (seedController != null)
                //seedController.enabled = true;
                seedController.GetComponent<NavMeshAgent>().enabled = true;


            text.text = "";
        }
        else if (count < -1)
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                if (aliveMap[i] == playerControllers[i].isDead)
                {
                    aliveMap[i] = false;
                    text.fontSize = 100;
                    text.text = playerControllers[i].PlayerName + " was Terminated!\n Tree Monster Speed Up!";
                    messageTimer = 2;

                    if (playerControllers[i].PlayerName == "Green")
                        text.color = Color.green;
                    if (playerControllers[i].PlayerName == "Red")
                        text.color = Color.red;
                    if (playerControllers[i].PlayerName == "Black")
                        text.color = Color.grey;
                    if (playerControllers[i].PlayerName == "Yellow")
                        text.color = Color.yellow;
                }
            }

            int alivePlayer = 0;
            
            for (int i = 0; i < aliveMap.Length; i++)
                if (aliveMap[i])
                    alivePlayer++;

            float targetSpeed = 0;

            switch (alivePlayer)
            {
                case 4:
                    targetSpeed = 5;
                    break;
                case 3:
                    targetSpeed = 5.1f;
                    break;
                case 2:
                    targetSpeed = 5.2f;
                    break;
                case 1:
                    targetSpeed = 5.3f;
                    break;
                default:
                    targetSpeed = 0f;
                    break;
            }

            //if (treeController.GetComponent<NavMeshAgent>().speed != targetSpeed)
            //{
            //    treeController.GetComponent<NavMeshAgent>().speed = targetSpeed;
            //    if (targetSpeed > 0)
            //    {
            //        text.text = "Tree Monster Speed Up!";
            //        messageTimer = 1;
            //    }
            //}



            if (messageTimer <= 0)
                text.text = "";
            else
                messageTimer -= Time.deltaTime;


        }
        

        

    }
}
