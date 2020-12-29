using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nav : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void incidencias()
    {
        SceneManager.LoadScene("incidencias");
    }

    public void Denunciar()
    {
        SceneManager.LoadScene("denuncia");
    }
}
