using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class CardPicker : MonoBehaviour
{
    public Canvas canvas; // Canvas referansı
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Start()
    {
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = EventSystem.current;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    Debug.Log("Dokunulan element: " + result.gameObject.name);
                    if (result.gameObject.name=="Card")
                    {
                      //  StartCoroutine(CardResizer(result.gameObject));
                    }               
                }
            }
        }
    }

    IEnumerator CardResizer(GameObject card)
    {
        card.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.25f);
        yield return new WaitForSeconds(0.3f);
        card.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.25f);

    }
}
