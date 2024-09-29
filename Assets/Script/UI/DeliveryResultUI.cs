using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprites;
    [SerializeField] private Sprite failedSprites;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        DeliveryManager.instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(POPUP);

        messageText.text = "DELIVERY\nFAILED";
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprites;
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(POPUP);

        messageText.text = "DELIVERY\nSUCCESS";
        backgroundImage.color = successColor;
        iconImage.sprite = successSprites;
    }
}
