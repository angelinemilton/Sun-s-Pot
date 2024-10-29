using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesHandler : MonoBehaviour
{
    [SerializeField] Button palmButton;
    [SerializeField] TextMeshProUGUI bankBalance;

    void Start()
    {
        SetPalmButton();
    }

    void Update()
    {
        SetBankBalance();
    }

    public void OnClickBackButton(){
        SceneManager.LoadScene("EndDay");
    }

    public void OnClickPurchasePalm(){
        PlayerPrefs.SetInt("PalmTree", 1);
        float balance = PlayerPrefs.GetFloat("BankAmount");
        PlayerPrefs.SetFloat("BankAmount", balance - 50);
        palmButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Owned");
        palmButton.GetComponentInChildren<TextMeshProUGUI>().color = new Color(248f / 255f, 80f / 255f, 177 / 255f);
        palmButton.GetComponent<Image>().color = new Color(248f / 255f, 116f / 255f, 177 / 255f);
        Debug.Log("Palm owned: " + PlayerPrefs.GetInt("PalmTree"));
    }

    void SetPalmButton(){
        if(PlayerPrefs.GetInt("PalmTree", 0) == 1){
            //already owned
            palmButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Owned");
            palmButton.GetComponentInChildren<TextMeshProUGUI>().color = new Color(248f / 255f, 80f / 255f, 177 / 255f);
            palmButton.GetComponent<Image>().color = new Color(248f / 255f, 116f / 255f, 177 / 255f);
        }
    }

    void SetBankBalance(){
        bankBalance.SetText("Bank Balance $" + PlayerPrefs.GetFloat("BankAmount"));
    }
}