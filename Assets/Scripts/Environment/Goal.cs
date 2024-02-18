using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void Start()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.25f);
        if(collider) {
            Player player = collider.GetComponent<Player>();
            if(player != null) {
                PlayerProgress.instance.OnLevelCompleted();
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
}
