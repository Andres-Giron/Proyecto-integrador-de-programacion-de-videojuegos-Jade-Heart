using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    //walk
    public float Speed = 5f;
    private float inputx;

    //junp//
    public float PowerJump = 10f;
    public float LengthRaycast = 011f;
    public LayerMask maskFloor;

    [Header("Walljump")]

    [SerializeField] private Transform ControladorDePared;
    [SerializeField] private Vector3 BoxWallDimension;
    private bool inWall;
    private bool Sliding;
    [SerializeField] private float SlidingSpeed;
    public float PowerJumpX;


    private bool inFloor;
    private Rigidbody2D Rb;
    private Animator animations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputx = Input.GetAxis("Horizontal");
        float SpeedX = inputx*Time.deltaTime*Speed;

        Vector3 Posicion = transform.position;

        transform.position = new Vector3(SpeedX + Posicion.x, Posicion.y, Posicion.z);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LengthRaycast, maskFloor);
        inFloor = hit.collider != null;

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, LengthRaycast, maskFloor);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, LengthRaycast, maskFloor);

        bool wallRight = hitRight.collider != null;
        bool wallLeft = hitLeft.collider != null;
        inWall = wallRight || wallLeft;

        if (inFloor && Input.GetKeyDown(KeyCode.Z))
        {
            Rb.AddForce(new Vector2(0f, PowerJump), ForceMode2D.Impulse);
        }

        else if (!inFloor && inWall && Input.GetKeyDown(KeyCode.Z))
        {
           
            Rb.linearVelocity = Vector2.zero;

            
            float wallDir = wallRight ? -1f : 1f;

            
            Vector2 wallJumpForce = new Vector2(wallDir * PowerJumpX, PowerJump);
            Rb.AddForce(wallJumpForce, ForceMode2D.Impulse);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LengthRaycast);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * LengthRaycast);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * LengthRaycast);
    }
}
