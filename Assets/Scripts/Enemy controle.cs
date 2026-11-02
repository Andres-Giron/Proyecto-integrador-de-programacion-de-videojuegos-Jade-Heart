using UnityEngine;

public class Enemycontrole : MonoBehaviour
{
    public Transform player;
    public float DetectionRadius = 5.0f;
    public float Speed = 2.0f;

    private Rigidbody2D EnemyRB;
    private Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (DistanceToPlayer < DetectionRadius)
        {
            Vector2 Direction = (player.position - transform.position).normalized;

            move = new Vector2(Direction.x, 0);
        }
        else
        {
            move = Vector2.zero;
        }

        EnemyRB.MovePosition(EnemyRB.position + move * Speed * Time.deltaTime);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, DetectionRadius);
    }
}
