using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Canvas canvas;
    //[SerializeField] GameObject placingField;
    [SerializeField] AudioClip SelectEffekt;
    [SerializeField] AudioClip NodePlaceEffekt;
    [SerializeField] AudioClip NodeResetEffekt;

    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    Transform originalParents;
    public Vector3 orginPos;
    public bool placed;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        orginPos = rectTransform.anchoredPosition;
        originalParents = rectTransform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        canvasGroup.blocksRaycasts = false;
        if(!placed)
        rectTransform.SetParent(canvas.GetComponent<RectTransform>());
        SoundManager.instance.PlaySoundCLip(SelectEffekt, 1f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        if (!placed)
        {

            ResetPosition();
            SoundManager.instance.PlaySoundCLip(NodeResetEffekt, 1f);
        }
        SoundManager.instance.PlaySoundCLip(NodePlaceEffekt, 1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        placed = true;
        //rectTransform.SetParent(placingField.GetComponent<RectTransform>());
    }

    public void ResetPosition()
    {
        rectTransform.SetParent(originalParents.GetComponent<RectTransform>());
        rectTransform.anchoredPosition = orginPos;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
