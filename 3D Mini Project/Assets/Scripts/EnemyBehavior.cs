using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{

    public float health = 100;
    [SerializeField] private float speed;
    private GameObject player;
    private List<Vector3> directions = new List<Vector3>();
    public Vector3 randomMov;
    public Coroutine coRoutineCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        directions.Add(Vector3.forward);
        directions.Add(Vector3.left);
        directions.Add(Vector3.right);
        directions.Add(Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, randomMov, speed * Time.deltaTime);

        if (coRoutineCheck == null) 
        {
            coRoutineCheck = StartCoroutine(ChangeDirection());
        }

        
    }

    public IEnumerator ChangeDirection()
    {
        randomMov = new Vector3(player.transform.position.x * (Random.Range(-10.0f, 10.0f)), player.transform.position.y, player.transform.position.z * (Random.Range(-10.0f, 10.0f)));
        yield return new WaitForSeconds(2);
        coRoutineCheck = null; 
    }

}
