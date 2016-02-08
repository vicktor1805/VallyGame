using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jugador : MonoBehaviour
{
    int pos = 1;
    Vector3 EndPoint;
    bool IsMoving;
    private int Anforas;
    public Text AnforasText;
    void Start()
    {
       
        Anforas = 100;
        AnforasText.text = "Anforas: <color=RED>" + Anforas+"%</color>";
    }


    void Update()
    {

        //#if UNITY_STANDALONE
        //if (Input.GetKeyUp(KeyCode.RightArrow) && pos != 2 && IsMoving == false)
        float Acceleration = Input.acceleration.x;
        //GameObject.Find("Text").GetComponent<Text>().text = Acceleration.ToString();
        if(Acceleration > 0.3 && Acceleration != 0 && pos != 2 && IsMoving == false)
        {
            pos += 1;
            EndPoint = Data.Carriles[pos];
            StartCoroutine(MoveToPosition(this.transform, EndPoint, Data.duration));
        }

        //if (Input.GetKeyUp(KeyCode.LeftArrow) && pos != 0 && IsMoving == false)
        if(Input.acceleration.x < -0.2 && Acceleration != 0 && pos != 0 && IsMoving == false)
        {
            pos -= 1;
            EndPoint = Data.Carriles[pos];
            StartCoroutine(MoveToPosition(this.transform, EndPoint, Data.duration));
        }
//#endif
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag.Equals("wheel")) 
		{
			Destroy (collision.gameObject);
			StartCoroutine(DoBlinks(1f, 0.2f));
			print ("choco con llanta!");
            Damage();
		}
	}

	IEnumerator DoBlinks(float duration, float blinkTime)
    {

		MeshRenderer[] camion = GetComponentsInChildren<MeshRenderer>();
		while (duration > 0f) 
		{
			duration -= 0.2f;

			//toggle renderer
			foreach (var item in camion) 
			{
				item.GetComponent<Renderer> ().enabled = !item.GetComponent<Renderer> ().enabled;
			}

			//wait for a bit
			yield return new WaitForSeconds(blinkTime);
		}

		//make sure renderer is enabled when we exit
		foreach (var item in camion) 
		{
			item.GetComponent<Renderer> ().enabled = true;
		}
	}

    void Damage()
    {
        Anforas -= 3;
        AnforasText.text = "Anforas: <color=RED>" + Anforas + "%</color>";
        print(Anforas);

    }

    public void MoveToDirection(bool direction)
    {
        if (direction && pos != 2 && IsMoving == false)
        {
            pos += 1;
            EndPoint = Data.Carriles[pos];
            StartCoroutine(MoveToPosition(this.transform, EndPoint, Data.duration));
        }
        else
        {
            if (!direction && pos != 0 && IsMoving == false)
            {
                pos -= 1;
                EndPoint = Data.Carriles[pos];
                StartCoroutine(MoveToPosition(this.transform, EndPoint, Data.duration));
            }

        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            IsMoving = true;
            yield return null;
        }
        IsMoving = false;

    }
}
