using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    TileData tileData;
    [SerializeField] LayerMask obstacle;
    [SerializeField] Transform springTarget;
    [SerializeField] bool activated = false;
    
    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
    }
    void Update() {
        ChangeSpringColor();
    }
    public void Activate(ISwitch _switch) {
        activated = _switch.IsTriggered();
        LaunchObject();
    }
    void ChangeSpringColor() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(activated)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.white;
        }
    }
    void LaunchObject() {
        Collider2D launchableCheck = Physics2D.OverlapCircle(transform.position, 0.25f);

        if(launchableCheck.TryGetComponent(out IPushable pushable) || launchableCheck.TryGetComponent(out Player player)) {
            launchableCheck.transform.position = springTarget.position;

            Collider2D objectAtLandingPointCheck = Physics2D.OverlapCircle(springTarget.position, 0.25f);
            if(objectAtLandingPointCheck) {
                if(objectAtLandingPointCheck.TryGetComponent(out IPushable obstaclePushable)) {
                    Vector2 springDirection = springTarget.position - transform.position;
                    obstaclePushable.Push(springDirection.normalized);
                }
            }
        }
    }
}
