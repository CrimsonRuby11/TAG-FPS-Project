using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;
        if(timer > 4)
        {
            Destroy(gameObject);
        }

        if(PlayerInteract.isPaused)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Red Cube")
        {
            PlayerInteract.reds -= 1;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Blue Cube")
        {
            Debug.Log("GAME OVER");
            PlayerInteract.isPaused = true;
        }
        Destroy(gameObject);
    }
}
