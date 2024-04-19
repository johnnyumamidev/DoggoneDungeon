using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IPushable, ITrigger
{
    [SerializeField] TileData tileData;
    [SerializeField] LayerMask obstacle;
    Vector3 targetPosition;
    [SerializeField] float pushSpeed = 18;
    void Awake() {
        targetPosition = transform.position;
    }
    void Start() {
        if(tileData == null) tileData = FindObjectOfType<TileData>();
    }
    public void Push(Vector2 input)
    {
        Debug.Log(name + " pushed");
        Vector3 target = transform.position + (Vector3)input;

        if(NoObstacles(target) || OnMovingPlatform(target)) {
            if(!OnMovingPlatform(target)) 
                transform.parent = null;
            targetPosition += (Vector3)input;
        }
    }

    public bool NoObstacles(Vector2 target) {
        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f, obstacle);
        if(collider || !tileData.ValidTile(target))
            return false;
        return true;
    }

    public bool OnMovingPlatform(Vector2 target) {
        Collider2D collider = Physics2D.OverlapCircle(target, 0.25f);
        if(collider && collider.TryGetComponent(out MovingPlatform movingPlatform)) {
            transform.parent = movingPlatform.transform;
            return true;
        }
        return false;
    }
    void Update() {
        if(transform.parent != null) 
            targetPosition = transform.parent.position;

        transform.position = Vector3.Lerp(transform.position, targetPosition, pushSpeed * Time.deltaTime);
    }

    IEnumerator DropBoxIntoPit(Vector2 vector) {
        targetPosition += (Vector3)vector;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    public void SetTarget()
    {
        throw new System.NotImplementedException();
    }
}
