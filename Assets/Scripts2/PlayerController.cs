using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    [SerializeField] float idleThreshold = 4f;

    private float horizontal = 0f;
    private float vertical = 0f;

    float idleTimer = 0f;
    float repeatTimer = 0f;
    bool isIdle = false;

    void Update()
    {
        Vector3 move = new Vector3(horizontal, vertical, 0).normalized;

        anim.SetFloat("horizontal", move.x);
        anim.SetFloat("vertical", move.y);

        if (move.magnitude == 0)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleThreshold)
            {
                isIdle = true;
                repeatTimer += Time.deltaTime;

                if (repeatTimer >= idleThreshold)
                {
                    anim.SetTrigger("playIdleSpecial");
                    repeatTimer = 0f;
                }
            }
        }
        else
        {
            idleTimer = 0f;
            repeatTimer = 0f;
            isIdle = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(horizontal, vertical, 0).normalized;
        rb.MovePosition(transform.position + (move * speed * Time.fixedDeltaTime));
    }

    // Métodos para botones UI
    public void MoverIzquierda() => horizontal = -1f;
    public void MoverDerecha() => horizontal = 1f;
    public void MoverArriba() => vertical = 1f;
    public void MoverAbajo() => vertical = -1f;

    public void DetenerHorizontal() => horizontal = 0f;
    public void DetenerVertical() => vertical = 0f;
}
