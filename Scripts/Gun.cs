using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform camera;

    public CinemachineVirtualCamera aimCamera;

    public Animator animator;

    private bool isAttacking = false;

    // public LayerMask layerMask;
    public float damage = 10f;

    public float range = 100f;

    public GameObject impactEffect;

    BoxCollider colliderWeapon;

    private GameObject objWeapon;

    public AudioSource swordAudio;

    public int maxBullet;

    int currentBullet;

    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        animator = GetComponent<Animator>();
        objWeapon = GameObject.FindGameObjectsWithTag("PlayerWeapon")[0];
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;

        manaBar.SetMaxBullet (maxBullet);
        currentBullet = maxBullet;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * 100, Color.red);
        if (aimCamera.enabled && Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }

        if (!aimCamera.enabled && Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }

    void Shoot()
    {
        RaycastHit target;
        if (Physics.Raycast(camera.position, camera.forward, out target, range))
        {
            
            if (currentBullet >= 0)
            {
                GameObject bullet = GameObject.Instantiate(bulletPrefab);
                currentBullet--;
                Debug.Log (currentBullet);
                manaBar.SetBullet (currentBullet);

                GameObject ImpactGO =
                    Instantiate(impactEffect,
                    target.point,
                    Quaternion.LookRotation(target.normal));
                bullet.transform.position = target.point;

                Destroy(ImpactGO, 2f);
                Destroy(bullet, 1f);
                if (target.transform.name == "Enemy")
                    target.transform.SendMessage("Die");
            }
        }
    }

    public void AttackStart()
    {
        swordAudio.Play();

        colliderWeapon.enabled = true;
    }

    public void AttackEnd()
    {
        colliderWeapon.enabled = false;
    }
}
