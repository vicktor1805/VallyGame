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
    void Start()
    {
        step = 0.5f;
        ShootForce = 20000;
    }


    void Update()
    {
    
        torreta.transform.LookAt(ScreenToWorld(Input.mousePosition));

        torreta.transform.LookAt(ScreenToWorld(Input.mousePosition));
        UnityEngine.EventSystems.EventSystem ct = UnityEngine.EventSystems.EventSystem.current;

        if (Input.GetMouseButtonUp(0) && !ct.IsPointerOverGameObject())
        {
            print(ct.IsPointerOverGameObject());
            Click = Input.mousePosition;
            Click.z = 10;
            MousePos = CamaraCanionTorreta.ScreenToWorldPoint(Click);
            Shoot();
        }

    }

    Vector3 ScreenToWorld(Vector2 screenPos)
    {

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        float t = -ray.origin.y / ray.direction.y;
        if (t < 0)
            t *= -1;
        return ray.GetPoint(t);
    }

    void Shoot()
    {
		var rotation = Quaternion.AngleAxis (90f, Vector3.forward);
		GameObject NuevaBala = Instantiate(balloon, source.transform.position, rotation) as GameObject;
        NuevaBala.transform.LookAt(MousePos);
        rb = NuevaBala.GetComponent<Rigidbody>();
        rb.AddForce(    torreta.transform.forward * ShootForce);
		rb.AddTorque (Vector3.right * ShootForce);
        Destroy(NuevaBala, 5);

    }


}

