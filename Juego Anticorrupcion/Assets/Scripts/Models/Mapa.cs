using System.Collections;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private int Separador = 18;
    private int SeparadorCarrtera = 80;
    private Vector3 SpawnPositionLeft;
    private Vector3 SpawnPositionRight;
    private Vector3 SpawnPOsitionHighWay;
    private float SpeedCreation;
    private Vector3[] ObstaculoSpawn;
    public GameObject Obstaculo;
    public GameObject casa;

    //IEnumerator MoveTowards(Vector3 NewPosition)
    //{
    //    float timeSinceStarted = 0f;
    //    while (true)
    //    {
    //        timeSinceStarted += Time.deltaTime;
    //        transform.position = Vector3.Lerp(transform.position, NewPosition, timeSinceStarted);

    //        if (transform.position == NewPosition)
    //        {
    //            yield break;
    //        }

    //        yield return null;
    //    }
    //}


    void GenerarDivisores()
    {
        Transform UltimoIzquierda = GetChild("Ultimo_Izquierda", this.transform);
        Transform UltimoDerecha = GetChild("Ultimo_Derecha", this.transform);

        UltimoIzquierda.name = "Divisor_Izquierda";
        UltimoDerecha.name = "Divisor_Derecha";


        SpawnPositionLeft = UltimoIzquierda.position + new Vector3(0, 0, Separador);
        SpawnPositionRight = UltimoDerecha.position + new Vector3(0, 0, Separador);


        GameObject NuevoDivisorIzquierda = Instantiate(UltimoIzquierda.gameObject, SpawnPositionLeft, Quaternion.identity) as GameObject;
        GameObject NuevoDivisorDerecha = Instantiate(UltimoDerecha.gameObject, SpawnPositionRight, Quaternion.identity) as GameObject;

        NuevoDivisorDerecha.transform.SetParent(GetChild("Division_Derecha", this.transform));
        NuevoDivisorDerecha.name = "Ultimo_Derecha";

        NuevoDivisorIzquierda.transform.SetParent(GetChild("Division_Izquierda", this.transform));
        NuevoDivisorIzquierda.name = "Ultimo_Izquierda";
            
    }

    void GenerarCarretera()
    {
        Transform UltimaCarretera = GetChild("Ultimo_Carretera", this.transform);
        SpawnPOsitionHighWay = UltimaCarretera.position + new Vector3(0, 0, SeparadorCarrtera);

        GameObject NuevaCarretera = Instantiate(UltimaCarretera.gameObject, SpawnPOsitionHighWay, Quaternion.identity) as GameObject;
        NuevaCarretera.name = "Ultimo_Carretera";
        NuevaCarretera.transform.SetParent(GetChild("Carretera", this.transform));
        UltimaCarretera.name = "Carretera";

    }

    void GenerarObstaculo()
    {
        System.Random r = new System.Random();
        int pos = r.Next(0,3);
        GameObject NuevoObstaculo = Instantiate(Obstaculo, ObstaculoSpawn[pos], Quaternion.identity) as GameObject;
        NuevoObstaculo.name = "Obstaculo" + pos.ToString();

    }

    void GenerarCasa()
    {
        GameObject Nuevacasa = Instantiate(casa, new Vector3(-21,6,57), Quaternion.identity) as GameObject;
        GameObject Nuevacasa2 = Instantiate(casa, new Vector3(21,6,57), Quaternion.identity) as GameObject;

    }
    void Start()
    {
        ObstaculoSpawn = new Vector3[3];
        ObstaculoSpawn[0] = new Vector3(-12,(float)-2.5,50);
        ObstaculoSpawn[1] = new Vector3(0, (float)-2.5, 50);
        ObstaculoSpawn[2] = new Vector3(+12, (float)-2.5, 50);

        InvokeRepeating("GenerarDivisores", 1, 0.42f);
        InvokeRepeating("GenerarCarretera", 1, 1.88f);
        InvokeRepeating("GenerarObstaculo",1,1f);
        InvokeRepeating("GenerarCasa", 1, 1f);

    }

    Transform GetChild(string name,Transform p)
    {
        Transform[] T = p.GetComponentsInChildren<Transform>(false);

        foreach (var item in T)
        {
            if (item.name.Equals(name))
                return item;
        }

        return null;   
    }
}