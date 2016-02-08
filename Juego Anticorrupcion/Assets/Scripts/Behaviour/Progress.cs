using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

	public Sprite bar;
	public float waitTime;
	// Use this for initialization
	void Start () {
//		waitTime = 50.0f;

	}
	
	// Update is called once per frame
	void Update () {
		//cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
		this.GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime; ;


	}
}
