using UnityEngine;
using System.Collections;

public class RepeatBridge : MonoBehaviour {

    [SerializeField] private float BridgeObjectSpeed = 10;
    [SerializeField] private float StartPosition = 68.26f;
    [SerializeField] private float ResetPosition = -77.5f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame

    protected virtual void Update() {
        if (Player.isDead == true)
        {
            BridgeObjectSpeed = 0;
        }

        transform.Translate(Vector3.left * (BridgeObjectSpeed * Time.deltaTime));
        if (transform.localPosition.x <= ResetPosition)
        {
            
            Vector3 newPos = new Vector3(StartPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

        
 
	
	}
}
