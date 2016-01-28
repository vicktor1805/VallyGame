using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    Vector3 hit;
    public GameObject torreta;
    private Vector3 newpos;
    public GameObject source;
    public GameObject balloon;
    private Vector3 Click;
    private Vector3 MousePos;
    private float step;
    private Rigidbody rb;
    public float ShootForce;
    public Camera CamaraCanionTorreta;
    // Use this for initialization
    void Start()
    {
        step = 0.5f;
        ShootForce = 20000;
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit golpe = new RaycastHit();


        //if (Physics.Raycast(ray.origin, ray.direction, out golpe) /*&& golpe.transform.tag.Equals("plane")*/)
        //{
        //    print(golpe.transform.tag);
        //    torreta.transform.LookAt(golpe.point);
        //}
        //Debug.DrawRay(ray.origin, golpe.point, Color.red);

        torreta.transform.LookAt(ScreenToWorld(Input.mousePosition));

        //if (torreta.transform.eulerAngles.x >= 10)
        //{
        //    newpos = new Vector3(10, torreta.transform.eulerAngles.y, torreta.transform.eulerAngles.z);
        //    torreta.transform.rotation = Quaternion.Euler(newpos);
        //}
        //if (torreta.transform.rotation.x <= -20)
        //{
        //    newpos = new Vector3(-10, torreta.transform.eulerAngles.y, torreta.transform.eulerAngles.z);
        //    torreta.transform.rotation = Quaternion.Euler(newpos);
        //}

        if (Input.GetMouseButtonUp(0))
        {
            Click = Input.mousePosition;
            Click.z = 10;
            MousePos = CamaraCanionTorreta.ScreenToWorldPoint(Click);
           
            Shoot();
        }

        //Ray ray2 = CamaraCanionTorreta.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray2.origin, MousePos, Color.red);

    }

    Vector3 ScreenToWorld(Vector2 screenPos)
    {
        // Create a ray going into the scene starting 
        // from the screen position provided 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        //RaycastHit hit;

        // ray hit an object, return intersection point
        //if (Physics.Raycast(ray, out hit))
        //    return hit.point;

        // ray didn't hit any solid object, so return the 
        // intersection point between the ray and 
        // the Y=0 plane (horizontal plane)
        float t = -ray.origin.y / ray.direction.y;
        if (t < 0)
            t *= -1;
        return ray.GetPoint(t);
    }

    void Shoot()
    {
        GameObject NuevaBala = Instantiate(balloon, source.transform.position, Quaternion.identity) as GameObject;
        //NuevaBala.transform.position = Vector3.MoveTowards(NuevaBala.transform.position, MousePos, step);
        NuevaBala.transform.LookAt(MousePos);
        rb = NuevaBala.GetComponent<Rigidbody>();
        //rb.AddRelativeForce(source.transform.forward*ShootForce);
        rb.AddForce(    torreta.transform.forward * ShootForce);
        Destroy(NuevaBala, 5);

    }


}

