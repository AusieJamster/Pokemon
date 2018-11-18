using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private float faderSpeed = 5;
    public Image fader;

    private TextBoxTyper typer;

    public bool fading;

	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        typer = GetComponent<TextBoxTyper>();
    }

    public IEnumerator FadeScreen(bool toBlack)
    {
        fading = true;

        Color tempColor = fader.color;

        if (toBlack)
            faderSpeed = Mathf.Abs(faderSpeed);
        else
            faderSpeed = Mathf.Abs(faderSpeed) * -1;

        while (fader.color.a >= 0 && fader.color.a <= 1)
        {
            tempColor.a += faderSpeed * Time.deltaTime;
            fader.color = tempColor;
            yield return null;
        }

        tempColor.a = toBlack ? 1 : 0;
        fader.color = tempColor;

        fading = false;
    }

    public void Textbox (string[] text, Player player)
    {
        typer.RunTextbox(text, player);
    }
}
