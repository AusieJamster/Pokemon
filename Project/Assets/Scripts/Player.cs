using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    
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

        if (horizontal != 0 || vertical != 0)
            base.Move(horizontal, vertical);

        //SoundManager.instance.RandomiseSfx();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trigger")
        {
            collision.GetComponent<TriggerObject>().TriggerActive(this);

        }
    }
}
