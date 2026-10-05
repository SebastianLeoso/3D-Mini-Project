using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    public float gunDamage;
    public float bulletInterval;
    public float magSize;
    private float reloadTime = 2f;

    public LayerMask shootables;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magSize = 30;
        gunDamage = 20;
    }

    public void ShootGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootables))

        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hit.collider.GetComponent<EnemyBehavior>().health -= gunDamage;
            Debug.Log(hit.collider.GetComponent<EnemyBehavior>().health);
        }
        magSize -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && magSize <= 30) 
        {
            StartCoroutine(reloading(reloadTime));
        }
        if (Input.GetMouseButtonDown(0) && magSize > 0) 
        {
            ShootGun();
        }
    }

    public IEnumerator reloading(float reloadTime) 
    {
        yield return new WaitForSeconds(reloadTime);
        magSize = 30;
    }
}
