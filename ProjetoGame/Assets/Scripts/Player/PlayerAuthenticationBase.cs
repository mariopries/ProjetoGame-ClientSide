using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;
using Microsoft.Xbox.Services.Social.Manager;
using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAuthenticationBase : MonoBehaviour
{
    public GameObject Menu;

    [Header("Xbox Live Settings")]
    public int PlayerNumber = 1;

    [Header("Display Settings")]
    public Theme Theme = Theme.Light;


    [Header("UI Component References")]
    public GameObject signInPanel;

    public GameObject profileInfoPanel;

    public Image gamerpic;

    public Image gamerpicMask;

    public Image signInPanelImage;

    public Image profileInfoPanelImage;

    public Text gamertag;

    public Text playerNumberText;

    private string signInInputButton;

    private string signOutInputButton;


    public readonly Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    private XboxLiveUser xboxLiveUser;

    private XboxSocialUserGroup userGroup;

    private bool AllowSignInAttempt = true;

    private bool ConfigAvailable = true;

    private bool isSignedIn = false;
    private bool isPlaying = false;

    private bool initialized;

    public bool IsSignedIn
    {
        get => isSignedIn;
    }

    public bool IsPlaying
    {
        get => player.isPlaying;
    }

    private Player player; // The Rewired Player
    private CharacterController characterController;

    public void Awake()
    {
   
        // Obter o controlador de caracteres 
        characterController = GetComponent<CharacterController>();

        //Carrega dados do xbox live
        this.EnsureEventSystem();
        XboxLiveServicesSettings.EnsureXboxLiveServicesSettings();


    }

    // Start is called before the first frame update
    void Start()
    {
        // Disable the sign-in button if there's no configuration available.
        if (!XboxLiveServicesSettings.EnsureXboxLiveServiceConfiguration())
        {
            this.ConfigAvailable = false;

            Text signInButtonText = this.signInPanel.GetComponentInChildren<Button>().GetComponentInChildren<Text>(true);
            if (signInButtonText != null)
            {
                signInButtonText.fontSize = 16;
                signInButtonText.text = "Xbox Live is not enabled.\nSee errors for detail.";
            }
        }
        this.playerNumberText.text = "P" + this.PlayerNumber;
        this.Refresh();

        try
        {
            SocialManagerComponent.Instance.EventProcessed += SocialManagerEventProcessed;
            SignInManager.Instance.OnPlayerSignOut(this.PlayerNumber, this.OnPlayerSignOut);
            SignInManager.Instance.OnPlayerSignIn(this.PlayerNumber, this.OnPlayerSignIn);
            this.xboxLiveUser = SignInManager.Instance.GetPlayer(this.PlayerNumber);
            if (this.xboxLiveUser != null)
            {
                this.LoadProfileInfo();
            }
        }
        catch (Exception ex)
        {
            ExceptionManager.Instance.ThrowException(
                       ExceptionSource.PlayerAuthentication,
                       ExceptionType.UnexpectedException,
                       ex);
        }

        this.StartCoroutine(this.LoadTheme());
    }

    public void Update()
    {
        if (!ReInput.isReady) return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
        if (!initialized) Initialize(); // Reinitialize after a recompile in the editor

        while (ExecuteOnMainThread.Count > 0)
        {
            ExecuteOnMainThread.Dequeue().Invoke();
        }

        if ( (isSignedIn && !player.isPlaying) || (!isSignedIn && player.isPlaying))
            player.isPlaying = isSignedIn;

        GetInput();
        ProcessInput();

    }

    private void OnPlayerSignOut(XboxLiveUser xboxLiveUser, XboxLiveAuthStatus authStatus, string errorMessage)
    {
        if (authStatus == XboxLiveAuthStatus.Succeeded)
        {
            this.signInPanel.GetComponentInChildren<Button>().interactable = true;
            this.AllowSignInAttempt = true;
            this.xboxLiveUser = null;
            this.Refresh();
        }
        else
        {
            ExceptionManager.Instance.ThrowException(
                        ExceptionSource.PlayerAuthentication,
                        ExceptionType.UnexpectedException,
                        new Exception(errorMessage));
        }
    }

    public void SignIn()
    {
        // Disable the sign-in button
        this.signInPanel.GetComponentInChildren<Button>().interactable = false;

        // Don't allow subsequent sign in attempts until the current attempt completes
        this.AllowSignInAttempt = false;
        this.StartCoroutine(SignInManager.Instance.SignInPlayer(this.PlayerNumber));
    }

    private void LoadProfileInfo(bool userAdded = true)
    {
        this.gamertag.text = this.xboxLiveUser.Gamertag;
        if (userAdded)
        {
            try
            {
                userGroup = XboxLive.Instance.SocialManager.CreateSocialUserGroupFromList(this.xboxLiveUser, new List<string> { this.xboxLiveUser.XboxUserId });
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ThrowException(
                        ExceptionSource.PlayerAuthentication,
                        ExceptionType.CreateSocialUserGroupFailed,
                        ex);
            }
        }
    }

    private void SocialManagerEventProcessed(object sender, SocialEvent socialEvent)
    {
        if (this.xboxLiveUser == null)
        {
            this.xboxLiveUser = SignInManager.Instance.GetPlayer(this.PlayerNumber);
        }

        if (this.xboxLiveUser == null || (socialEvent.User.XboxUserId != this.xboxLiveUser.XboxUserId))
        {
            // Ignore the social event
            return;
        }

        if (socialEvent.EventType == SocialEventType.LocalUserAdded)
        {
            if (socialEvent.ErrorCode != 0)
            {
                ExceptionManager.Instance.ThrowException(
                        ExceptionSource.SocialManager,
                        ExceptionType.AddLocalUserFailed,
                        new Exception(socialEvent.ErrorMessge));
                LoadProfileInfo(false);
            }
            else
            {
                LoadProfileInfo();
            }
        }
        else if (socialEvent.EventType == SocialEventType.SocialUserGroupLoaded &&
                 ((SocialUserGroupLoadedEventArgs)socialEvent.EventArgs).SocialUserGroup == userGroup)
        {
            if (socialEvent.ErrorCode != 0)
            {
                ExceptionManager.Instance.ThrowException(
                       ExceptionSource.SocialManager,
                       ExceptionType.LoadSocialUserGroupFailed,
                       new Exception(socialEvent.ErrorMessge));
            }
            else
            {
                StartCoroutine(FinishLoadingProfileInfo());
            }
        }
    }


    private IEnumerator FinishLoadingProfileInfo()
    {
        this.playerNumberText.color = ThemeHelper.GetThemeBaseFontColor(this.Theme);
        var socialUser = userGroup.GetUsersFromXboxUserIds(new List<string> { this.xboxLiveUser.XboxUserId })[0];

        var www = new WWW(socialUser.DisplayPicRaw + "&w=128");
        yield return www;

        try
        {
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                var t = www.texture;
                var r = new Rect(0, 0, t.width, t.height);
                this.gamerpic.sprite = Sprite.Create(t, r, Vector2.zero);
            }

        }
        catch (Exception ex)
        {
            ExceptionManager.Instance.ThrowException(
                        ExceptionSource.PlayerAuthentication,
                        ExceptionType.LoadGamerPicFailed,
                        ex);
        }
        this.Refresh();
    }


    public static Color ColorFromHexString(string color)
    {
        var r = (float)byte.Parse(color.Substring(0, 2), NumberStyles.HexNumber) / 255;
        var g = (float)byte.Parse(color.Substring(2, 2), NumberStyles.HexNumber) / 255;
        var b = (float)byte.Parse(color.Substring(4, 2), NumberStyles.HexNumber) / 255;

        return new Color(r, g, b);
    }

    private void OnPlayerSignIn(XboxLiveUser xboxLiveUser, XboxLiveAuthStatus authStatus, string errorMessage)
    {
        if (authStatus == XboxLiveAuthStatus.Succeeded && xboxLiveUser != null)
        {
            this.xboxLiveUser = xboxLiveUser;
        }
        else
        {
            if (authStatus != XboxLiveAuthStatus.Canceled)
            {
                ExceptionManager.Instance.ThrowException(
                            ExceptionSource.PlayerAuthentication,
                            ExceptionType.SignInFailed,
                            new Exception(errorMessage));
            }
        }
        this.ExecuteOnMainThread.Enqueue(Refresh);
    }

    private void Refresh()
    {
        this.isSignedIn = this.xboxLiveUser != null && this.xboxLiveUser.IsSignedIn;
        this.AllowSignInAttempt = !isSignedIn && this.ConfigAvailable;
        this.signInPanel.GetComponentInChildren<Button>().interactable = this.AllowSignInAttempt;
        this.signInPanel.SetActive(!isSignedIn);
        this.profileInfoPanel.SetActive(isSignedIn);

    }


    private IEnumerator LoadTheme()
    {
        yield return null;

        var backgroundColor = ThemeHelper.GetThemeBackgroundColor(this.Theme);
        this.profileInfoPanelImage.color = backgroundColor;
        this.gamerpicMask.color = backgroundColor;
        this.signInPanelImage.sprite = ThemeHelper.LoadSprite(this.Theme, "RowBackground-Highlighted");
        this.gamertag.color = ThemeHelper.GetThemeBaseFontColor(this.Theme);
    }

    private void SignOut()
    {
        this.playerNumberText.color = Color.white;
        this.StartCoroutine(SignInManager.Instance.SignOutPlayer(this.PlayerNumber));
    }

    private void OnDestroy()
    {
        if (SignInManager.Instance != null)
        {
            SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignOut);
            SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignIn);
        }
        if (SocialManagerComponent.Instance != null)
        {
            SocialManagerComponent.Instance.EventProcessed -= SocialManagerEventProcessed;
        }
    }

    private void Initialize()
    {
        //Carrega dados dos controladores
        // Pega o objeto Rewired Player para este jogador e o mantém enquanto durar o tempo de vida do personagem 
        player = ReInput.players.GetPlayer(PlayerNumber-1); // o numero do controle sempre é -1 (começa com zero)

        initialized = true;
    }

    private void GetInput()
    {

        if (player.GetButtonDown("Move Horizontal"))
            Debug.Log("Move Horizontal");
        if (player.GetButtonDown("Move Vertical"))
            Debug.Log("Move Vertical");
        if (player.GetButtonDown("A"))
            Debug.Log("A");
        if (player.GetButtonDown("UICancel"))
            Debug.Log("UICancel");
        if (player.GetButtonDown("X"))
            Debug.Log("X");
        if (player.GetButtonDown("Start"))
            Debug.Log("Start");
        if (player.GetButtonDown("Select"))
            Debug.Log("Select");

    }

    private void ProcessInput()
    {
        if (this.AllowSignInAttempt && player.GetButtonDown("Start"))
        {
            this.SignIn();
        }

        if (!this.AllowSignInAttempt && player.GetButtonDown("Select"))
        {
            this.SignOut();
        }

        if (IsPlaying && IsSignedIn && player.GetButtonDown("UICancel"))
        {
            PlayerConnected playerConnected = Menu.GetComponent<PlayerConnected>();
            playerConnected.BackMenu();
        }
    }

}
