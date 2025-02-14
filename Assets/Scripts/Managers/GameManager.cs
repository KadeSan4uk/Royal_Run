using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    public float TimeLeft => timeLeft;
    float timeLeft;
    bool gameOver = false;
    float minDecreaseTimeObstacle = 0.5f;
    float mediumDecreaseTimeObstacle = 1f;
    float maxDecreaseTimeObstacle = 2f;

    public bool GameOver => gameOver;
    //public bool GameOver { get; private set; }

    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        DecriaseTime();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    void DecreaseAmount(float amount)
    {
        timeLeft -= amount;
    }

    public void DecreaseTimeFromObstacles(string tag)
    {
        switch (tag)
        {
            case "Barrel":
                DecreaseAmount(minDecreaseTimeObstacle);
                break;
            case "Chair":
                DecreaseAmount(minDecreaseTimeObstacle);
                break;
            case "Chest":
                DecreaseAmount(minDecreaseTimeObstacle);
                break;
            case "Cart":
                DecreaseAmount(mediumDecreaseTimeObstacle);
                break;
            case "SmallRock":
                DecreaseAmount(mediumDecreaseTimeObstacle);
                break;
            case "BigRock":
                DecreaseAmount(maxDecreaseTimeObstacle);
                break;
                //case "Fence":
                //    DecreaseAmount(minDecreaseTimeObstacle);
                //    break;
        }
    }

    void DecriaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
