using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    [SerializeField] float idleThreshold = 4f; // Tiempo de espera para activar animación

    Vector3 move;
    float idleTimer = 0f;
    float repeatTimer = 0f;
    bool isIdle = false;

    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        anim.SetFloat("horizontal", move.x);
        anim.SetFloat("vertical", move.y); // Cambia la dirección de la animación según el movimiento

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
                    repeatTimer = 0f; // Reinicia para que se repita cada 5 segundos
                }
            }
        }
        else
        {
            // Si el jugador se mueve, reseteamos todo
            idleTimer = 0f;
            repeatTimer = 0f;
            isIdle = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (move * speed * Time.fixedDeltaTime));
    }
}
