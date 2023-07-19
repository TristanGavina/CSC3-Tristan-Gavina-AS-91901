using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy {

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update() {
        CheckDistance();
    }

    void CheckDistance (){
        if(Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
}
}
