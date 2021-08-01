using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeShopUpgradeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string upgradeName;
    public string upgradeDescription;

    public PlayerController player;
    public GameObject upgradeText;
    private TextMeshProUGUI upgradeNameText;
    private TextMeshProUGUI upgradeDescriptionText;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        upgradeNameText = upgradeText.transform.Find("UpgradeName").GetComponent<TextMeshProUGUI>();
        upgradeDescriptionText = upgradeText.transform.Find("UpgradeDescription").GetComponent<TextMeshProUGUI>();
        Initialize();

    }


    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        upgradeText.gameObject.SetActive(true);
        RefreshText();
    }

    public void RefreshText()
    {
        upgradeNameText.text = upgradeName;
        upgradeDescriptionText.text = upgradeDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        upgradeText.gameObject.SetActive(false);
    }

    public virtual void Initialize()
    {

    }
}
