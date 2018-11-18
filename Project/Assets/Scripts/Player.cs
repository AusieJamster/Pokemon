using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public LayerMask triggerLayer;

    private Vector2 facing;

    private void Update()
    {
        if (acceptInput)
            Move();

        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    protected void Move()
    {
        facing = Vector2.zero;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        facing.x = (int)(Input.GetAxisRaw("Horizontal"));
        facing.y = (int)(Input.GetAxisRaw("Vertical"));

        if (facing.x != 0)
            facing.y = 0;

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        
#endif

        anim.SetFloat("horizontal", facing.x);
        anim.SetFloat("vertical", facing.y);

        if (facing.x != 0 || facing.y != 0)
        {
            Move((int)facing.x, (int)facing.y);
        }

        //SoundManager.instance.RandomiseSfx();
    }

    private void Interact()
    {
        boxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facing, 1, blockingLayer.value);
        boxCollider.enabled = true;

        if(hit.transform.tag == "Interactable")
        {
            hit.transform.GetComponent<Interactable>();
        }
    }

    protected override IEnumerator SmoothMovement(Vector3 end)
    {
        yield return base.SmoothMovement(end);
        
        boxCollider.enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f,triggerLayer.value);;

        boxCollider.enabled = true;

        if (hit.transform != null)
        {
            hit.transform.GetComponent<TriggerObject>().Trigger(this);
        }
    }
}
