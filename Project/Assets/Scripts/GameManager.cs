using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool fading;

	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
	}

    public IEnumerator FadeScreen(bool toBlack)
    {
        fading = true;
        yield return null;
        
        /* while (screenFading)
        {
            // fading screen
            yield return null;
        }
        */

        fading = false;
    }
}
