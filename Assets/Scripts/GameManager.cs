using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnManager;
    private Vector3 spawnStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private MoveLeft[] resetPosition;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        spawnStartPoint = spawnManager.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");    // With this function you can add some time delays and player won't spawn instantly back to start.
    }

    /*public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        resetPosition = FindObjectsOfType<MoveLeft>();

        for (int i = 0; i < resetPosition.Length; i++)
        {
            resetPosition[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        spawnManager.position = spawnStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);              // RestartGame will wait 0.5 seconds before it starts again.

        resetPosition = FindObjectsOfType<MoveLeft>();

        for(int i = 0; i < resetPosition.Length; i++)
        {
            resetPosition[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        spawnManager.position = spawnStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
