using UnityEngine;
using System.Collections;

public class Jugador:MonoBehaviour
{
    int pos = 1;
    Vector3 EndPoint;
    Vector3 StartPoint;
    float duration;
    float StartTime;
    bool IsMoving;
    Vector3[] Carriles;

    void Start()
    {
        duration = (float)0.3;
        StartPoint = transform.position;
        StartTime = Time.time;
        Carriles = new Vector3[3];
        Carriles[0] = new Vector3((float)-8.90, (float)0.85, (float)-107.8);
        Carriles[1] = new Vector3((float)-0.08, (float)0.85, (float)-107.8);
        Carriles[2] = new Vector3((float)8.77, (float)0.85, (float)-107.8);
    }


    void Update()
    {

        if (Input.GetKeyUp(KeyCode.RightArrow) && pos != 2 && IsMoving == false)
        {
            pos += 1;
            EndPoint = Carriles[pos];
            StartCoroutine(MoveToPosition(this.transform, EndPoint, duration));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && pos != 0 && IsMoving == false)
        {
            pos -= 1;
            EndPoint = Carriles[pos];
            StartCoroutine(MoveToPosition(this.transform, EndPoint, duration));
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
