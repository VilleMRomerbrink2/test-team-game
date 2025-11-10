using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;

    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (other.gameObject.layer == layerIndex)
        {
            playerController.DisableControls();
            crashParticles.Play();
            Invoke(nameof(ReloadScene), restartDelay);
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}