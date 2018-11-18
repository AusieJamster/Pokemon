using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxTyper : MonoBehaviour {

    public Image textboxImage;
    public Text textboxText;
    public float letterDelay = 0.1f;

    public void RunTextbox(string[] text, Player player)
    {
        StartCoroutine(TextBoxProcess(text, player));
    }

    private IEnumerator TextBoxProcess(string[] text, Player player)
    {
        player.acceptInput = false;

        // Display Textbox

        string displayText = "";

        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < text[i].Length; j++)
            {
                displayText += text[j];
                textboxText.text = displayText;

                if (Input.anyKeyDown)
                    break;

                yield return new WaitForSeconds(letterDelay);
            }

            textboxText.text = displayText;

            while (!Input.anyKeyDown)
                yield return null;
        }

        // Close textbox

        player.acceptInput = true;
    }
}
