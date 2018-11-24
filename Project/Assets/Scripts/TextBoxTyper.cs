using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxTyper : MonoBehaviour {

    public Image textboxImage;
    public Text textboxText;

    private float letterDelay = 0.1f;
    private bool speedUp = false;

    private void Update()
    {
        if (textboxImage.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            speedUp = true;
        }
    }

    public void RunTextbox(string[] text, Player player)
    {
        StartCoroutine(TextBoxProcess(text, player));
    }

    private IEnumerator TextBoxProcess(string[] text, Player player)
    {
        player.acceptInput = false;
        textboxImage.gameObject.SetActive(true);

        string displayText = "";
        
        for (int i = 0; i < text.Length; i++)
        {
            displayText = "";
            speedUp = false;

            for (int j = 0; j < text[i].Length; j++)
            {
                displayText += text[i][j];

                if (textboxText.text.Length > 30)
                    textboxText.alignment = TextAnchor.LowerLeft;
                else
                    textboxText.alignment = TextAnchor.UpperLeft;

                textboxText.text = displayText;

                yield return new WaitForSeconds(speedUp ? Mathf.Pow(letterDelay,2) : letterDelay);

                if (j == text[i].Length - 1)
                {
                    while (!Input.GetKeyDown(KeyCode.E))
                        yield return null;
                }
            }

            textboxText.text = displayText;                
        }

        textboxImage.gameObject.SetActive(false);

        player.acceptInput = true;
    }
}
