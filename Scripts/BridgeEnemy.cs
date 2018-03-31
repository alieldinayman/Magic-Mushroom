using UnityEngine;
using System.Collections;

public class BridgeEnemy : MonoBehaviour {

    static public bool Colliding = false;
    static public bool TookDamage = false;
    public float EnemyHP = 10;
    bool isDead = false;
    //public GameObject player;
    //public Vector3 playerPos;
    NavMeshAgent nav;
    Transform player;
    Animator enemyAnimator;
    AudioSource enemyAudio;


    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();

    }

    IEnumerator takeDamage()
    {
        yield return new WaitForEndOfFrame();
        TookDamage = false;
        yield return new WaitForSeconds(1.0f);
        Colliding = false;
    }

    // Update is called once per frame
    void Update() {
        nav.SetDestination(player.position);
        /*if (Colliding == true)
            transform.Translate(playerPos.x, 0f, 0f * Time.deltaTime);
        else
            //transform.Translate(0f, 0f, playerPos.x * Time.deltaTime);*/
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, 4f * Time.deltaTime);
        if (EnemyHP <= 0 && isDead == false)
        {
            Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && Colliding == false && Player.HP >= 0 && EnemyHP >= 0 && isDead == false)
        {
            TookDamage = true;
            Colliding = true;
            Player.HP -= 10;
            StartCoroutine(takeDamage());
        }

        else if (collision.gameObject.tag == "Bullet" && Player.HP >= 0 && EnemyHP >= 0 && isDead == false)
        {
            EnemyHP -= Shooting.bulletDamage;
        }
    }

    private void Death()
    {
        Score.score += 10;
        isDead = true;
        Colliding = false;
        enemyAudio.Play();
        enemyAnimator.Play("Death");
        Destroy(gameObject, 1.5f);

    }
}
