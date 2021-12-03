using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FolderManager : MonoBehaviour
{

    public Text DocumentosTotales;

    public Text Documentos;

    private int DocumentosTotalesInLevel;

   

    public GameObject transition;


    private void Start()
    {
        DocumentosTotalesInLevel = transform.childCount;
    }

    private void Update()
    {
        FolderCollected();

       DocumentosTotales.text = DocumentosTotalesInLevel.ToString();
        Documentos.text = transform.childCount.ToString();
        
    }
    public void FolderCollected ()
    {
        if(transform.childCount==0)
        {
            Debug.Log("No quedan Documentos, nivel completado");
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
            

        }
    }

   void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
