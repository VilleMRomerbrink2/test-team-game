using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;
    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score: " + score.ToString();

    }


}