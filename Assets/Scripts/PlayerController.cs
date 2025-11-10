using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Configurable parameters
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 30f;
    [SerializeField] float slowSpeed = 25f;
    [SerializeField] float boostSpeed = 45f;
    [SerializeField] int scorePerFlip = 100;

    // Private variables
    Vector2 moveVector;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;

    // Cached references
    InputAction moveAction;
    Rigidbody2D myRigidbody;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        myRigidbody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void FixedUpdate()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (canControlPlayer)
        {
            RotatePlayer();
            MovePlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        if (moveVector.x < 0)
        {
            myRigidbody.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0)
        {
            myRigidbody.AddTorque(-torqueAmount);
        }
    }

    void MovePlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (moveVector.y < 0)
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            scoreManager.AddScore(scorePerFlip); // TODO hardcoded value, refactor/serialize later
        }

        previousRotation = currentRotation;
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }
}