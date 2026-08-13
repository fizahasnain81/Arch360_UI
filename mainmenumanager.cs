using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenumanager : MonoBehaviour
{
    public TextMeshProUGUI profilename;
    public TimedEvent timedEvent;
    public Animator splashscreen;
    public GameObject errorScreen, loginContent, signupError, signUpContent, signedUPContent;
    public TMP_InputField loginEmail, password, signupEmail, signUpPassword, signUpnickname;

   

    public void ONPlayStoryButtonClicked()
    {
        
    }
    public void OnNewScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void OnLogin()
    {
        if (!string.IsNullOrEmpty(loginEmail.text) && loginEmail.text == PlayerPrefs.GetString("Email"))
        {
            if (!string.IsNullOrEmpty(password.text) && password.text == PlayerPrefs.GetString("Password"))
            {
                profilename.text = PlayerPrefs.GetString("NickName");
                timedEvent.StartIEnumerator();
                splashscreen.Play("Login to Loading");
            }
            else
            {
                errorScreen.SetActive(true);
                loginContent.SetActive(false);
            }
        }
        else
        {
            Debug.Log("in Else");
            errorScreen.SetActive(true);
            loginContent.SetActive(false);
        }

    }
    public void signedup()
    {
        signedUPContent.SetActive(false);
        splashscreen.Play("Sign Up to Login");
    }
   
    public void ONPressYes()
    {
        errorScreen.SetActive(false);
        loginContent.SetActive(true);
    }
    public void OnPressYesSignUp()
    {
        signupError.SetActive(false);
        signUpContent.SetActive(true);
    }
    public void OnSignup() 
    {
        if (!string.IsNullOrEmpty(signupEmail.text))
        {
            if (!string.IsNullOrEmpty(signUpPassword.text))
            {
                if (!string.IsNullOrEmpty(signUpnickname.text))
                {
                    PlayerPrefs.SetString("Email", signupEmail.text);
                    PlayerPrefs.SetString("Password", signUpPassword.text);
                    PlayerPrefs.SetString("NickName", signUpnickname.text);
                    signUpContent.SetActive(false);
                    signedUPContent.SetActive(true);
                }
                else
                {
                    signupError.SetActive(true);
                    signUpContent.SetActive(false);
                }
            }
            else
            {
                signupError.SetActive(true);
                signUpContent.SetActive(false);
            }
        }
        else
        {
            signupError.SetActive(true);
            signUpContent.SetActive(false);
        }
    }
}
