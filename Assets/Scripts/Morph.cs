using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morph : MonoBehaviour
{
    public float timer;
    [SerializeField]
    private GameObject spherepf;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }

        if (PlayerInteract.isPaused)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blue Cube")
        {
            PlayerInteract.blues -= 1;
            GameObject sphere = Instantiate(spherepf, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Red Cube")
        {
            Debug.Log("GAME OVER");
            PlayerInteract.isPaused = true;
        }
        Destroy(gameObject);
    }
}
