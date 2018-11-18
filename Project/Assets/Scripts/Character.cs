using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public float moveTime = 0.1f;
    public LayerMask blockingLayer;
    public float cantMoveDelay = 0.01f;

    public bool acceptInput = true;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Animator anim;
    private float inverseMoveTime;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        inverseMoveTime = 1f / moveTime;
    }

    protected bool Move (int xDir, int yDir)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        anim.SetInteger("horizontal", xDir);
        anim.SetInteger("vertical", yDir);

        boxCollider.enabled = false;

        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);
        
        boxCollider.enabled = true;

        if(hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }

        return false;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        acceptInput = false;

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);

            rb.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            yield return null;
        }
        acceptInput = true;
    }
}
