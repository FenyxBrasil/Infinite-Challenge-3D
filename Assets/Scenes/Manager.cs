using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class Manager : MonoBehaviour
{

    public GameObject bolaMetal;
    public GameObject bolaBorracha;

    public Transform localInstanciar;


    int NumOrder = 0;  //numero das Ordens 

    int pontos = 0;  //numero das Ordens 

    string OrderName;

    public TextMeshProUGUI pontosGanhosScore;


    public void Start()
    {
        pontos = 0;

        NumOrder = 0;

        pontosGanhosScore.text = pontos.ToString();

    }




    // Update is called once per frame
    void Update()
    {
        OrderName = "(" + NumOrder + ")";

        InstantiateGameObject1();  //void
        InstantiateGameObject2();  //void

    }


    void InstantiateGameObject1()
    {

        if (Input.GetMouseButtonDown(0))  //
        {

            NumOrder += 1;

            GameObject NewObj = Instantiate(bolaMetal, localInstanciar.transform.position, Quaternion.identity);

            NewObj.name = bolaMetal.name + OrderName;

            Destroy(NewObj, 25f);

            //Debug.Log("criando Prefab bolaMetal");


        }

    }



    void InstantiateGameObject2()
    {

        if (Input.GetMouseButtonDown(1))  //
        {
            NumOrder += 1;

            GameObject NewObj = Instantiate(bolaBorracha, localInstanciar.transform.position, Quaternion.identity);

            NewObj.name = bolaBorracha.name + OrderName;

            Destroy(NewObj, 25f);

            //Debug.Log("criando Prefab bolaBorracha");


        }

    }


    public void FecharPrograma()
    {

        StartCoroutine(Sair());

    }



    IEnumerator Sair()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }



    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ball>().pontuar == true)
        {

            pontos = pontos + 1;

            pontosGanhosScore.text = pontos.ToString();

            other.GetComponent<ball>().pontuar = false;

        }





    }




}
