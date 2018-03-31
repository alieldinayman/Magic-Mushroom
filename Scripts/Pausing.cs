using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pausing : MonoBehaviour {
    public Image pauseImage;
    public Text pauseText;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseImage.enabled = false;
                pauseText.enabled = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseImage.enabled = true;
                pauseText.enabled = true;
            }
        }

    }
}
