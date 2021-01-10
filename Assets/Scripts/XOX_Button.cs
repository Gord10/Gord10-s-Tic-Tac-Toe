using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XOX_Button : MonoBehaviour
{
    public int id;
    private Button button;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportClick(bool isPlayerClick = true)
    {
        if(!GameManager.IsInputAllowed() && isPlayerClick)
        {
            return;
        }

        MarkButtonAsPressed();
        GameManager.MakeMove(id);
    }

    public void MarkButtonAsPressed()
    {
        image.sprite = GameManager.GetSideSprite();
        button.interactable = false;
    }

}
