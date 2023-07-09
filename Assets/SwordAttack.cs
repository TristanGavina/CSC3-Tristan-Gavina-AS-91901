using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{


    Vector2 AttackOffset;
    Collider2D swordCollider;

    // Start is called before the first frame update
    private void Start () {
        swordCollider = GetComponent<Collider2D>();
        AttackOffset = transform.position;
    }

    // Update is called once per frame
    public void AttackRight() {
        swordCollider.enabled = true;
        transform.position = AttackOffset;
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.position = AttackOffset;
     }

    public void AttackBack() {
        swordCollider.enabled = true;
        transform.position = AttackOffset;
    }

    public void AttackFront() {
        swordCollider.enabled = true;
        transform.position = AttackOffset;
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }
}
