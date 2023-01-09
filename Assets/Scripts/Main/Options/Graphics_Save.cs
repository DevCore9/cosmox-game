using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class Graphics_Save : MonoBehaviour
{
    const string PrefName = "optionvalue";

    private Dropdown _dropdown;

    void Awake()
    {
        _dropdown = GetComponent<Dropdown>();

        _dropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }
	
	void Start ()
    {
        _dropdown.value = PlayerPrefs.GetInt(PrefName, 0);
	}
}
