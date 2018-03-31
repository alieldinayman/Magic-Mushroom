using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    AudioSource bulletSound;
    Light gunLight;
    ParticleSystem gunParticles;
    float effectsTime = 0.2f;
    float Timer;
    public GameObject gunCap;
    public GameObject Bullet;
    public float bulletForce = 5000f;
    static public float bulletDamage = 10f;
    public float gunCooldown = 0.75f;

    // Use this for initialization
    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        gunParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && Timer >= gunCooldown)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        
        GameObject tempCap;
        Rigidbody tempBody;
        tempCap = Instantiate(Bullet, gunCap.transform.position, gunCap.transform.rotation) as GameObject;
        tempBody = tempCap.GetComponent<Rigidbody>();
        tempBody.AddForce(transform.forward * bulletForce);
        Destroy(tempCap, 0.5f);
        if (Timer >= gunCooldown)
            Timer = 0f;
    }
}