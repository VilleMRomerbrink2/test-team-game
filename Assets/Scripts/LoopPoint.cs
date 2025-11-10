using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreManager scoreManager;

    
    public void OnTriggerEnter2D(Collider2D other)
    {

        int layerIndex = LayerMask.NameToLayer("Player");

        if (other.gameObject.layer == layerIndex)
        {
            scoreManager.AddScore(500);
        }
    }

}
