using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyChase : MonoBehaviour
{
    [Header("Character Stats (Composition)")]
    public CharacterStats stats;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player dengan tag 'Player' tidak ditemukan di scene!");
        }
    }

    void Update()
    {
        if (player == null) return;

        
        Vector2 direction = (player.position - transform.position).normalized;

        
        rb.linearVelocity = direction * stats.moveSpeed;

        
        if (direction.x != 0)
            spriteRenderer.flipX = direction.x < 0;

        
        bool isWalking = direction.magnitude > 0.1f;
        animator.SetBool("isWalking", isWalking);

        
        if (Vector2.Distance(player.position, transform.position) < 1f)
        {
            stats.TakeDamage(10);
        }
    }
}
