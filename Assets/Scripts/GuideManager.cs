using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    [SerializeField] GameObject _guide;
    [SerializeField] GameObject currentPage;
    [SerializeField] Chapter currentChpt;
    [SerializeField] GameObject curChptBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!TutorialManager.showedTut)
        {
            ToggleDisplay();
            TutorialManager.showedTut = true;
        }
        Button button = curChptBtn.GetComponent<Button>();
        var colors = button.colors;
        colors.normalColor = colors.selectedColor;
        colors.selectedColor = button.colors.normalColor;
        button.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDisplay()
    {
        if (_guide.activeSelf)
        {
            _guide.SetActive(false);
            return;
        }
        _guide.SetActive(true);
    }

    public void FlipToPage(int idx)
    {
        //if (nextPage == null) Debug.Log("Next page is not set!");
        //Chapter chapter = currentChpt.GetComponent<Chapter>();
        currentChpt.Pages[currentChpt.CurrentPageIndex].SetActive(false);
        currentChpt.Pages[idx].SetActive(true);
        currentChpt.CurrentPageIndex = idx;
    }
    
    public void FlipToChapter(Chapter chapter)
    {
        if (chapter == currentChpt || chapter == null) return;
        currentChpt.Pages[currentChpt.CurrentPageIndex].SetActive(false);
        currentChpt = chapter;
        FlipToPage(currentChpt.CurrentPageIndex);
    }
    private void SwitchActiveChptColor(Button button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (button.gameObject == curChptBtn || button == null) return;
        Debug.Log("New Btn:" + button.gameObject.name);
        //Mark selected Chpt
        var colors = button.colors;
        colors.normalColor = colors.selectedColor;
        colors.selectedColor = button.colors.normalColor;
        button.colors = colors;

        //Reset last selected Chpt
        Button lastButton = curChptBtn.GetComponent<Button>();
        colors = lastButton.colors;
        colors.normalColor = colors.selectedColor;
        colors.selectedColor = lastButton.colors.normalColor;
        lastButton.colors = colors;
        Debug.Log("Cur Btn:" + lastButton.gameObject.name);

        curChptBtn = button.gameObject;
    }

    public void OnChptButtonClick(GameObject chpt)
    {
        SwitchActiveChptColor(chpt.GetComponent<Button>());
    }

    public void SetCurChapter(Chapter chapter)
    {
        FlipToChapter(chapter);
    }
    
    //public void ClickOnChapterButton(GameObject chapterButton)
    //{
    //    if (chapterButton == currentChpt) return;
    //    Button button;
    //    if (chapterButton.TryGetComponent<Button>(out button))
    //    {
    //        button.onClick.Invoke();
    //    }
    //}
}
