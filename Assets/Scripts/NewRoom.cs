using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewRoom : MonoBehaviour, IPointerDownHandler
{
    public GameObject spawnObject;
    public Vector3 spawnPosition;
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Instantiate(spawnObject, spawnPosition, Quaternion.identity);
    }
}
