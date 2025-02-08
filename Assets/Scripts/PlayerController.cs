using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f; 
    public SpawnManager spawnManager;

    private float xInput;
    private float zInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        MoveForward();  
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered(other); 
    }
}
