using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public LayerMask triggerLayer;

    private void Update()
    {
        if (acceptInput) Move();
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

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);

        if (horizontal != 0 || vertical != 0)
            Move(horizontal, vertical);

        //SoundManager.instance.RandomiseSfx();
    }

    protected override IEnumerator SmoothMovement(Vector3 end)
    {
        yield return base.SmoothMovement(end);
        /*

        boxCollider.enabled = false;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, .5f, Vector2.right, .5f, triggerLayer.value);

        boxCollider.enabled = true;

        Debug.Log(hit.transform);

        if (hit.transform != null)
        {
            hit.transform.GetComponent<TriggerObject>().Trigger(this);
        }
        */
    }
}
