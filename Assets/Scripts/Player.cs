using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 0.005f;
    [SerializeField] float steerSpeed = 0.05f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed, 0);
        transform.Rotate(0, 0, steerSpeed);
    }
}
