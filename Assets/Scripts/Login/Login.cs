using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    private TMP_InputField usernameLogin;
    private TMP_InputField passwordLogin;

    public Button loginButton;

    private string _usernameLogin = string.Empty;
    private string _passwordLogin = string.Empty;

    void Start()
    {
        usernameLogin = GameObject.Find("Login_Username_InputField").GetComponent<TMP_InputField>();
        passwordLogin = GameObject.Find("Login_Password_InputField").GetComponent<TMP_InputField>();
    }
    void Awake()
    {
        loginButton.onClick.AddListener(loginAccount);
    }
    
    void Update()
    {
        if(usernameLogin != null || passwordLogin != null)
        {
            if(usernameLogin.isFocused || passwordLogin.isFocused)
            {
                loginButton.GetComponent<Error_Message>().clearError();
            }
        }
    }

    private void loginAccount()
    {
        _usernameLogin = usernameLogin.text;
        _passwordLogin = passwordLogin.text;

        if(!string.IsNullOrEmpty(_usernameLogin) && !string.IsNullOrEmpty(_passwordLogin))
        {
            if(validateUsername())
            {
                if(validatePassword())
                {
                    if(verifyUsername())
                    {
                        // bring in data from database
                        if(verifyPassword())
                        {
                            //allow login
                            // set up player account game object
                            Debug.Log(_usernameLogin + " " + _passwordLogin);
                            // add log in scene to settings
                            // add after merge to avoid conflicts
                            //SceneManager.LoadScene(1);
                        }
                        else
                        {
                            loginButton.GetComponent<Error_Message>().dispayMessage(0);
                        }
                    }
                    else
                    {
                        loginButton.GetComponent<Error_Message>().dispayMessage(0);
                    }
                }
                else
                {
                    loginButton.GetComponent<Error_Message>().dispayMessage(0);
                }
            }
            else
            {
                loginButton.GetComponent<Error_Message>().dispayMessage(0);
            }
        }
        else
        {
            loginButton.GetComponent<Error_Message>().dispayMessage(1);
        }
    }

    private bool validateUsername()
    {
        string pattern = @"^([a-zA-Z0-9-_]{3,15})$";
        Regex rgx = new Regex(pattern);

        return rgx.IsMatch(_usernameLogin);
    }
    private bool verifyUsername()
    {
        // verify username from database
        return true;
    }

    private bool validatePassword()
    {
        string pattern = @"^([a-zA-Z0-9\!\@\#\$\%\-_]{5,20})$";
        Regex rgx = new Regex(pattern);

        return rgx.IsMatch(_passwordLogin);
    }
    private bool verifyPassword()
    {
        // verify password from database
        return true;
    }
}
