using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RoomCreator : MonoBehaviour
{
    private GameObject spawnObject;
    private GameObject cube;
    TMP_InputField[] inputFields;
    Slider[] sliders;
    public Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        inputFields = GetComponentsInChildren<TMP_InputField>();
        sliders = GetComponentsInChildren<Slider>();
        for(int i=0; i<inputFields.Length; i++)
        {
            inputFields[i].onValueChanged.AddListener(delegate {InputChangeCheck(); });
            sliders[i].onValueChanged.AddListener(delegate {SliderChangeCheck(); });
        }
        cube  = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = spawnPosition;
    }

    public void InputChangeCheck()
    {
        Debug.Log("Input Changed");
        if(!Input.GetKeyDown("."))
        {
            cube.transform.localScale = new Vector3 (float.Parse(inputFields[0].text), float.Parse(inputFields[2].text), float.Parse(inputFields[1].text));
            //update slider
            for(int i=0; i<inputFields.Length; i++)
            {
                sliders[i].value = float.Parse(inputFields[i].text);
            }
        }
    }

    public void SliderChangeCheck()
    {
        Debug.Log("Slider Changed");
        sliders = GetComponentsInChildren<Slider>();
        cube.transform.localScale = new Vector3 (sliders[0].value, sliders[2].value, sliders[1].value);

        //update input
        for(int i=0; i<sliders.Length; i++)
        {
            inputFields[i].text = Math.Round(sliders[i].value, 2).ToString();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
