using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas howToPlayCanvas;
    [SerializeField] Canvas settingsCanvas;

    [Header("Button")]
    [SerializeField] Button buttonStart;
    [SerializeField] Button buttonHowToPlay;
    [SerializeField] Button buttonBack;
    [SerializeField] Button buttonQuit;
    [SerializeField] Button buttonSettings;
    [SerializeField] Button buttonBackSettings;

    [SerializeField] Slider bgVolumeSlider;
    [SerializeField] Slider effectVolumeSlider;


    private void OnEnable()
    {
        ButtonPressedBehavior.buttonFunctionTable.Add(buttonStart.gameObject.name, OnButtonStartClick);
        ButtonPressedBehavior.buttonFunctionTable.Add(buttonHowToPlay.gameObject.name, OnButtonHowToPlayClick);
        ButtonPressedBehavior.buttonFunctionTable.Add(buttonQuit.gameObject.name, OnButtonQuitClick);
        ButtonPressedBehavior.buttonFunctionTable.Add(buttonBack.gameObject.name, OnButtonBackClick);

        ButtonPressedBehavior.buttonFunctionTable.Add(buttonSettings.gameObject.name, OnButtonSettingsClick);
        ButtonPressedBehavior.buttonFunctionTable.Add(buttonBackSettings.gameObject.name, OnButtonBackSettingsClick);
    }

    private void OnDisable()
    {
        ButtonPressedBehavior.buttonFunctionTable.Clear();
    }

    void Start()
    {
        Time.timeScale = 1f;
        GameManager.GameState = GameState.Playing;
        UIInput.Instance.SelectUI(buttonStart);
        buttonBackSettings.enabled = false;
        buttonBack.enabled = false;
        bgVolumeSlider.enabled = false;
        effectVolumeSlider.enabled = false;
    }
    void OnButtonStartClick()
    {
        mainMenuCanvas.enabled = false;
        howToPlayCanvas.enabled = false;
        settingsCanvas.enabled = false;
        // mainMenuCanvas.SetActive(false);
        // howToPlayCanvas.SetActive(false);
        SceneLoader.Instance.LoadGamePlayScene();
    }

    void OnButtonHowToPlayClick()
    {
        mainMenuCanvas.enabled = false;
        howToPlayCanvas.enabled = true;
        buttonBack.enabled = true;
        buttonHowToPlay.enabled = false;
        buttonSettings.enabled = false;
        buttonStart.enabled = false;
        buttonQuit.enabled =false;
        // mainMenuCanvas.SetActive(false);
        // howToPlayCanvas.SetActive(true);
        // UIInput.Instance.SelectUI(buttonHowToPlay);
        UIInput.Instance.SelectUI(buttonBack);

    }

    void OnButtonBackClick()
    {
        mainMenuCanvas.enabled = true;
        howToPlayCanvas.enabled = false;
        buttonBack.enabled = false;
        buttonHowToPlay.enabled = true;
        buttonSettings.enabled = true;
        buttonStart.enabled = true;
        buttonQuit.enabled =true;
        // mainMenuCanvas.SetActive(true);
        // howToPlayCanvas.SetActive(false);
        UIInput.Instance.SelectUI(buttonStart);

    }

    void OnButtonSettingsClick()
    {
        mainMenuCanvas.enabled = false;
        settingsCanvas.enabled = true;
        buttonBackSettings.enabled = true;
        bgVolumeSlider.enabled = true;
        effectVolumeSlider.enabled = true;
        buttonStart.enabled = false;
        buttonHowToPlay.enabled = false;
        buttonSettings.enabled = false;
        buttonQuit.enabled =false;
        UIInput.Instance.SelectUI(bgVolumeSlider);

    }

    void OnButtonBackSettingsClick()
    {
        mainMenuCanvas.enabled = true;
        settingsCanvas.enabled = false;
        buttonBackSettings.enabled = false;
        bgVolumeSlider.enabled = false;
        effectVolumeSlider.enabled = false;
        buttonStart.enabled = true;
        buttonSettings.enabled = true;
        buttonHowToPlay.enabled = true;
        buttonQuit.enabled =true;
        AudioManager.Instance.SaveSoundSettings();
        // mainMenuCanvas.SetActive(true);
        // howToPlayCanvas.SetActive(false);
        UIInput.Instance.SelectUI(buttonStart);

    }

    void OnButtonQuitClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
