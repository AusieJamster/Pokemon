using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public LayerMask triggerLayer;

    private Vector2 facing;

    private void Update()
    {
        Move();            

        if (Input.GetKeyDown(KeyCode.E) && acceptInput)
            Interact();
    }

    protected void Move()
    {
        int horizontal = 0;
        int vertical = 0;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
            vertical = 0;

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        
#endif

        if (!acceptInput)
        {
            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
            return;
        }
        else
        {
            anim.SetFloat("horizontal", horizontal);
            anim.SetFloat("vertical", vertical);
        }

        if (horizontal != 0 || vertical != 0)
        {
            facing.x = horizontal;
            facing.y = vertical;
            Move(horizontal, vertical);
        }

        //SoundManager.instance.RandomiseSfx();
    }

    private void Interact()
    {
        boxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facing, 1, blockingLayer.value);
        Debug.DrawRay(transform.position, facing, Color.red, 1);
        boxCollider.enabled = true;

        if (hit.transform == null)
            return;

        if(hit.transform.tag == "Interactable")
        {
            hit.transform.GetComponent<Interactable>().Interact(this);
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
