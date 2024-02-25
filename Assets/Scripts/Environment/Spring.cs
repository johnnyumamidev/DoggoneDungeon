using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] Transform springTarget;
    [SerializeField] bool activated = false;
    public float cooldownLength = 2f; 
    float springRange;
    void Update() {
        ChangeSpringColor();
    }
    public void Activate(bool b) {
        if(activated || !b) 
            return;
        
        activated = true;
        StartCoroutine(SpringCooldown());

        Vector3 pushDirection = springTarget.position - transform.position;
        springRange = pushDirection.magnitude;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, pushDirection, springRange);
            if(hits.Length == 0) { 
                return;
            }
            for(int i = 0; i < hits.Length; i++) {
                Transform hit = hits[i].transform;
                if(hit.TryGetComponent(out IPushable pushable)) {
                    pushable.Push(pushDirection);
                }
            }
    }
    void ChangeSpringColor() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(activated)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.white;
        }
    }
    IEnumerator SpringCooldown() {
        float timer = 0;
        while(timer < cooldownLength) {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        activated = false;
    }
    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(springTarget.position, 0.2f);
    }
}
