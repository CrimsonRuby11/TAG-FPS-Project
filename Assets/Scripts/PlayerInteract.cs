using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private GameObject bulletpf;
    [SerializeField]
    private GameObject morphpf;
    [SerializeField]
    private GameObject bulletpoint;
    [SerializeField]
    private float bulletSpeed = 35f;
    

    public bool isShot;
    public bool isMorph;

    // Game Score
    public static int reds = 5;
    public static int blues = 5;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);

        if(isShot && !PlayerInteract.isPaused)
        {
            shoot(hitInfo);
            isShot = false;
        }

        if(isMorph && !PlayerInteract.isPaused)
        {
            morph(hitInfo);
            isMorph = false;
        }

        //Debug.Log(isPaused);
    }

    public void shoot(RaycastHit rinfo)
    {
        GameObject b = Instantiate(bulletpf, bulletpoint.transform.position, transform.rotation);
        Vector3 bdir = (rinfo.point - bulletpoint.transform.position).normalized;
        b.GetComponent<Rigidbody>().velocity = bdir * bulletSpeed;
    }

    public void morph(RaycastHit rinfo)
    {
        GameObject m = Instantiate(morphpf, bulletpoint.transform.position, transform.rotation);
        Vector3 bdir = (rinfo.point - bulletpoint.transform.position).normalized;
        m.GetComponent<Rigidbody>().velocity = bdir * bulletSpeed;
    }
}
