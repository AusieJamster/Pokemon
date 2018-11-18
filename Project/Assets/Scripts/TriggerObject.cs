using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerObject : MonoBehaviour {
    public void TriggerActive(Player player)
    {
        StartCoroutine(WaitForPlayer(player));
    }

    private IEnumerator WaitForPlayer(Player player)
    {
        while (!player.acceptInput)
            yield return null;

        Trigger(player);
    }

    protected abstract void Trigger(Player player);
}
