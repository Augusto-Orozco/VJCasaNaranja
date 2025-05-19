using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPCController : MonoBehaviour
{
    [Header("NPC Settings")]
    public float speed;
    public float minmoveTime;
    public float maxmoveTime;
    public float minWaitTime;
    public float maxWaitTime;

    Animator animator;

    Vector2 direction;
    Rigidbody2D Rigidbody;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();

        direction = RandomDirection();
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
    }

    IEnumerator Patrol()
    {
        direction = RandomDirection();
        Animations();
        yield return new WaitForSeconds(Random.Range(minmoveTime, maxmoveTime));

        direction = Vector2.zero;
        Animations();
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

        StartCoroutine(Patrol());

    }

    private Vector2 RandomDirection()
    {
        int x = Random.Range(-1, 2);

        return x switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            3 => Vector2.right,
            4 => new Vector2(1, 1),
            5 => new Vector2(-1, -1),
            6 => new Vector2(-1, 1),
            _ => new Vector2(1, -1),
        };
    }

    private void Animations()
    {
        if (direction.magnitude != 0)
        {
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
            Rigidbody.linearVelocity = direction.normalized * speed;
        }
    }

    public void StopBehavior()
    {
        StopAllCoroutines();
        direction = Vector2.zero;
        Animations();
    }

    public void ContinueBehavior()
    {
        StartCoroutine(Patrol());
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
