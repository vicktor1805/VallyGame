using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject Explosion;
	void OnCollisionEnter(Collision collision)
	{

        GameObject Nuevaexp =  Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(Nuevaexp, 0.5f); 
        if (collision.transform.name.Contains ("Obstaculo")) 
		{
			Destroy (collision.gameObject);
        }

		Destroy (this.gameObject);
	}



}