using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class JsonUse : MonoBehaviour
{
    public Text red;
    public Text green;
    public Text blue;
    public string jsonURL;
    public GameObject colorcube;
    public Jsonclass jsnData;

    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Загрузка...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        Debug.Log("Файл сохранён по пути:" + resultFile);
        jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
        red.text = jsnData.Red.ToString();
        green.text = jsnData.Green.ToString();
        blue.text = jsnData.Blue.ToString();
        colorcube.GetComponent<Renderer>().material.color = new Color32((byte)jsnData.Red, (byte)jsnData.Green, (byte)jsnData.Blue, 1);
        yield return StartCoroutine(getData());
    }
    [System.Serializable]

    public class Jsonclass
    {
        public int Red;
        public int Green;
        public int Blue;
    }
}
