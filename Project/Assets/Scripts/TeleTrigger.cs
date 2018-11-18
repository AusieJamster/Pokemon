using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleTrigger : TriggerObject {

    public Transform teleportTo;

    private float delay = 0.1f;

    protected override void Trigger(Player player)
    {
        StartCoroutine(Teleport(player));
    }

    protected IEnumerator Teleport(Player player)
    {
        player.acceptInput = false;

        GameManager.instance.FadeScreen(true);

        while (GameManager.instance.fading)
            yield return new WaitForSeconds(delay);
        
        player.transform.position = teleportTo.position;

        GameManager.instance.FadeScreen(true);

        while (GameManager.instance.fading)
            yield return new WaitForSeconds(delay);

        player.acceptInput = true;
    }
}
