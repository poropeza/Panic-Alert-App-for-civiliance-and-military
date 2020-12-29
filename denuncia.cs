using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class denuncia : MonoBehaviour
{

    public ImagePickAndSave imageCtr;


    public Sprite listo;
    public Sprite no_listo;


    int renderMode = 0;

    // Use this for initialization
    void Start()
    {
        //GameObject.Find("listo").GetComponent<Image>().sprite = no_listo;
        //imageCtr.PickCompleted += OnPickCompleted;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPickCompleted(string path)
    {
        GameObject.Find("listo").GetComponent<Image>().sprite = listo;

        if (renderMode == 1)
        {
            StartCoroutine(LoadImage(path));
        }
        else if (renderMode == 2)
        {
            StartCoroutine(LoadImage(path));
        }
    }

    public void GalleryLoad()
    {
        renderMode = 1;
        imageCtr.Browse();
    }

    public void CameraLoad()
    {
        renderMode = 2;
        imageCtr.OpenCamera();
    }

    IEnumerator LoadImage(string path)
    {

        var url = "file://" + path;
        #if UNITY_EDITOR || UNITY_STANDLONE
                url = "file:/" + path;
        #endif
        Debug.Log("current path is " + url);
        //GameObject.Find("texto").GetComponent<Text>().text = "current path is " + url;

        var www = new WWW(url);
        yield return www;

        /*var texture = www.texture;
     
        if (texture == null)
        {
            Debug.LogError("Failed to load texture url:" + url);
            //GameObject.Find("texto").GetComponent<Text>().text = "Failed to load texture url:" + url;
        }
        Renderer render = renderObj.GetComponent<Renderer>();

        DestroyImmediate(render.material.mainTexture);
        render.material.mainTexture = texture;
        texture = null;*/
    }

  
}
