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
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 2f;
    [SerializeField] float maxHeightY;
    void OnEnable() {
        if(tileData == null)
            tileData = FindObjectOfType<TileData>();
    }
    void Update() {
        ChangeSpringColor();
    }
    public void Activate(ISwitch _switch) {
        activated = _switch.IsTriggered();
        LaunchObject(CheckForLaunchable());
    }
    void ChangeSpringColor() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(activated)
            spriteRenderer.color = Color.red;
        else {
            spriteRenderer.color = Color.white;
        }
    }
    Transform CheckForLaunchable() {
        Collider2D launchableCheck = Physics2D.OverlapCircle(transform.position, 0.25f);

        if(launchableCheck.TryGetComponent(out IPushable pushable) || launchableCheck.TryGetComponent(out Player player))
            return launchableCheck.transform;
        return null;
    }
    void LaunchObject(Transform launchable) {
        if(launchable == null)
            return;
        
        //disable launchable obj collider2D until landing
        

        StartCoroutine(LaunchArc(launchable, springTarget.position));

        //push any objects upon landing
        Collider2D objectAtLandingPointCheck = Physics2D.OverlapCircle(springTarget.position, 0.25f);
        if(objectAtLandingPointCheck) {
            if(objectAtLandingPointCheck.TryGetComponent(out IPushable obstaclePushable)) {
                Vector2 springDirection = springTarget.position - transform.position;
                obstaclePushable.Push(springDirection.normalized);
            }
        }
    }

    IEnumerator LaunchArc(Transform launchable, Vector3 end) {
        float timeElapsed = 0;
        float distanceAllowed = 0.4f;
        Collider2D launchableCollider = launchable.GetComponent<Collider2D>();
        launchableCollider.enabled = false;
        
        while(timeElapsed < duration && Vector2.Distance(launchable.position, end) > distanceAllowed) {
            timeElapsed += Time.deltaTime;

            var linearTime = timeElapsed / duration; //0 to 1 time
            var heightTime = curve.Evaluate(linearTime); //value from curve

            var height = Mathf.Lerp(0f, maxHeightY, heightTime); //clamped between the max height and 0

            launchable.position = Vector3.Lerp(launchable.position, end, linearTime) + new Vector3(0, height,0);
            yield return null;
        }
        launchable.position = Vector3.Lerp(launchable.position, end, 1);
        launchableCollider.enabled = true;
    }
}
