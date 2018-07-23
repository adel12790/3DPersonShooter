using System;
using UnityEngine;

public class Gun : MonoBehaviour {
    [SerializeField]
    [Range(0.3f, 1.5f)]
    private float fireRate = 0.3f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleParticle;


    private float timer;
    

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0; //reset the timer to be able to fire every 1s

                FireGun();
            }
        }
	}

    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, transform.forward * 100, Color.red, 2f);

        muzzleParticle.Play();

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
