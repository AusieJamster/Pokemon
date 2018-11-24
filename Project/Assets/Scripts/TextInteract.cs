using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteract : Interactable {

    public string[] text;

    public override void Interact(Player player)
    {
        if (text == null)
            return;

        GameManager.instance.Textbox(text, player);
    }
}
