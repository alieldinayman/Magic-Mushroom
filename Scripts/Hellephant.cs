using UnityEngine;
using System.Collections;

public class Hellephant : MonoBehaviour {

    AudioSource Hellsound;
    Animator Anim;

    // Use this for initialization
    void Start() {
        InvokeRepeating("Hellscream", 5.0f, 5.0f);
        Hellsound = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
    }

    IEnumerator triggerAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        Anim.Play("Idle");
    }

    void Hellscream()
    {
        Hellsound.Play();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0f, 0f, 0.2f * Time.deltaTime);
        if (Player.isDead == true)
        {
            StartCoroutine(triggerAnimation());
          
        }
            
    }
}
