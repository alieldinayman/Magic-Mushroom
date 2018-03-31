using UnityEngine;
using System.Collections;

public class Rock : RepeatBridge{

    [SerializeField] float Speed;
    [SerializeField] Vector3 topPos;
    [SerializeField] Vector3 bottomPos;
    // Use this for initialization
    void Start() {
        StartCoroutine(Move(bottomPos));
    }
    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.4f)
        {
            Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
            if (direction == Vector3.up)
                transform.localPosition += direction * Time.deltaTime * Speed;
            else
                transform.localPosition += direction * Time.deltaTime * Speed * 2.5f;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;
        StartCoroutine(Move(newTarget));
    }

    protected override void Update()
    {
        base.Update();
        if (Player.isDead == true)
        {
            Speed = 0;
        }
    }
    
}
