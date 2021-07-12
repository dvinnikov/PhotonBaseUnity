using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    private const string _playerNamePrefKey = "PlayerName";
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;

        InputField _inputField = this.GetComponent<InputField>();

        if (_inputField == null)
        {
            if (PlayerPrefs.HasKey(_playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(_playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;

    }

    public void SetPLayerName(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player name is null or empty");
        }

        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(_playerNamePrefKey, value);
    }
}
