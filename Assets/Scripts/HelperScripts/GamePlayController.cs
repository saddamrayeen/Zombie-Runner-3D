using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public GameObject[] zombiePrefabs;

    public GameObject[] obstalePrefabs;

    public Transform[] lanePosition;

    public float

            minObstacleDelay = 10f,
            maxObstacleDelay = 40f;

    float

            timer,
            halfGroundDistance = 100;

    GameObject playerController;

    TMP_Text scoreText;
TMP_Text finalScore;
    int score = 0;

  public  GameObject

            pausePanel,
            gameOverPanel;

    void Awake()
    {
        MakeSingelaton();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag(MyTags.PLAYER_TAG);
        StartCoroutine(GenerateObstacle());
    }

    public void MakeSingelaton()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    IEnumerator GenerateObstacle()
    {
        print("gen");
        timer =
            Random.Range(minObstacleDelay, maxObstacleDelay) /
            playerController.GetComponent<PlayerBaseController>().speed.z;

        yield return new WaitForSeconds(timer);
        CreateObstacle(playerController.transform.position.z +
        halfGroundDistance);

        StartCoroutine(GenerateObstacle());
    }

    private void CreateObstacle(float zpos)
    {
        float r = Random.Range(0, 7);

        if (0 <= r && r < 7)
        {
            int obstacLane = Random.Range(0, lanePosition.Length);

            AddObstacle(new Vector3(lanePosition[obstacLane]
                    .transform
                    .position
                    .x,
                0f,
                zpos),
            Random.Range(0, obstalePrefabs.Length));

            int ZombieLane = 0;

            if (obstacLane == 0)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if (obstacLane == 1)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obstacLane == 2)
            {
                ZombieLane = Random.Range(0, 2) == 1 ? 1 : 0;
            }

            AddZombies(new Vector3(lanePosition[ZombieLane]
                    .transform
                    .position
                    .z,
                0.15f,
                zpos));
        }
    }

    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle =
            Instantiate(obstalePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation =
                    Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 1:
                obstacle.transform.rotation =
                    Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 2:
                obstacle.transform.rotation =
                    Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;
            case 3:
                obstacle.transform.rotation =
                    Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;
        }
        obstacle.transform.position = position;
    }

    void AddZombies(Vector3 position)
    {
        int count = Random.Range(0, 3) + 1;
        for (int i = 0; i < count; i++)
        {
            Vector3 shift =
                new Vector3(Random.Range(-0.5f, .5f),
                    0f,
                    Random.Range(1f, 10f) * i);

            Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)],
            position + shift * i,
            Quaternion.identity);
        }
    } //add zombies

    public void addZombieScore()
    {
        score++;
        scoreText.text = score.ToString();
    } //score

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    } //pause game

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    } //resume game

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
         finalScore = GameObject.Find("finalScoreText").GetComponent<TMP_Text>();
        finalScore.text = score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }//restart game

    public void ExitGame()
    {
    Time.timeScale = 1;
    SceneManager.LoadScene("MainMenu");
    }//main menu


} //class
