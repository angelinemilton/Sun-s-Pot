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
        ingredientsCanvas.gameObject.SetActive(true);
    }

     public void OpenDecorCanvas(){
        CloseAllCanvases();
        decorCanvas.gameObject.SetActive(true);
    }

    void SetBankBalance(){
        bankBalance.text = "$" + GameStats.GetBankAmount();
    }

    public void CloseAllCanvases(){
        menuCanvas.gameObject.SetActive(false);
        ingredientsCanvas.gameObject.SetActive(false);
        decorCanvas.gameObject.SetActive(false);
    }

    public void Return(){
        SceneManager.LoadScene("EndDay");
    }


}