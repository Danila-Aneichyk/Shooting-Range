using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    #region Events

    public event Action<bool> OnPaused;

    #endregion


    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePause();
        }
    }

    #endregion


    #region Public methods

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        IsPaused = false;
        Time.timeScale = 1;
        OnPaused?.Invoke(IsPaused);
    }

    #endregion


    public void TogglePause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke(IsPaused);
    }  
}