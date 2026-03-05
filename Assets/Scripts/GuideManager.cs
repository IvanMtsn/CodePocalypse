using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    [SerializeField] GameObject _guide;
    [SerializeField] GameObject currentPage;
    [SerializeField] GameObject currentChpt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!TutorialManager.showedTut)
        {
            ToggleDisplay();
            TutorialManager.showedTut = true;
        }
        Button button = currentChpt.GetComponent<Button>();
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

    public void FlipToPage(GameObject nextPage)
    {
        if (nextPage == null) Debug.Log("Next page is not set!");
        if (nextPage == currentPage || nextPage == null) return;
        nextPage.SetActive(true);
        currentPage.SetActive(false);
        currentPage = nextPage;
    }
    
    public void FlipToChapter(GameObject chapterButton)
    {
        if (chapterButton == currentChpt) return;
        currentChpt = chapterButton;
        FlipToPage(chapterButton.GetComponent<Chapter>().firstPage);
    }
    public void SwitchActiveChptColor(Button button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (button.gameObject == currentChpt || button == null) return;
        //Mark selected Chpt
        var colors = button.colors;
        colors.normalColor = colors.selectedColor;
        colors.selectedColor = button.colors.normalColor;
        button.colors = colors;

        //Reset last selected Chpt
        button = currentChpt.GetComponent<Button>();
        colors = button.colors;
        colors.normalColor = colors.selectedColor;
        colors.selectedColor = button.colors.normalColor;
        button.colors = colors;
    }

    public void OnChptButtonClick(GameObject chpt)
    {
        if (chpt == currentChpt) { return; }
        SwitchActiveChptColor(chpt.GetComponent<Button>());
        FlipToChapter(chpt);
    }
    
    public void ClickOnChapterButton(GameObject chapterButton)
    {
        if (chapterButton == currentChpt) return;
        Button button;
        if (chapterButton.TryGetComponent<Button>(out button))
        {
            button.onClick.Invoke();
        }
    }
}
