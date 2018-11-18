using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleTrigger : TriggerObject {

    public Transform teleportTo;

    private float delay = 1f;

    public override void Trigger(Player player)
    {
        StartCoroutine(Teleport(player));
    }

    protected IEnumerator Teleport(Player player)
    {
        player.acceptInput = false;
        StartCoroutine(GameManager.instance.FadeScreen(true));

        while (GameManager.instance.fading)
            yield return new WaitForSeconds(delay);
        
        player.transform.position = teleportTo.position;

        StartCoroutine(GameManager.instance.FadeScreen(false));

        player.acceptInput = true;
    }
}
