using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bankBalance;

    //canvases
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas ingredientsCanvas;
    [SerializeField] Canvas decorCanvas;

    void Start()
    {
        OpenMenuCanvas();
    }

    void Update()
    {
        SetBankBalance();
    }

    public void OnClickBackButton(){
        SceneManager.LoadScene("EndDay");
    }

    public void OpenMenuCanvas(){
        CloseAllCanvases();
        menuCanvas.gameObject.SetActive(true);
    }

     public void OpenIngredientCanvas(){
        CloseAllCanvases();
        ingredientsCanvas.enabled = true;
    }

     public void OpenDecorCanvas(){
        CloseAllCanvases();
        decorCanvas.enabled = true;
    }

    void SetBankBalance(){
        bankBalance.text = "$" + GameStats.GetBankAmount();
    }

    public void CloseAllCanvases(){
        menuCanvas.gameObject.SetActive(false);
        ingredientsCanvas.enabled = false;
        decorCanvas.enabled = false;
    }


}