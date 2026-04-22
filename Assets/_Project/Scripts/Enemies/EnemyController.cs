using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Transform player;
    private Animator animator;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        if (animator != null)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                animator.SetFloat("MoveX", direction.x);
                animator.SetFloat("MoveY", 0f);
            }
            else
            {
                animator.SetFloat("MoveX", 0f);
                animator.SetFloat("MoveY", direction.y);
            }
        }
    }
}