using UnityEngine;

public class Bala : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name.Contains ("Obstaculo")) 
		{
			Destroy (collision.gameObject);
		}

		Destroy (this.gameObject);
	}

}