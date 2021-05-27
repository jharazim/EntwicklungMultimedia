using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject Menu;
    private bool menuIsActive;
    private Button btn_return;
    private Button btn_restart;

    // Start is called before the first frame update
    void Start()
    {

        btn_return = GameObject.Find("Return").GetComponent<Button>();
        btn_restart = GameObject.Find("Restart").GetComponent<Button>();

        btn_return.onClick.AddListener(onClickBtnReturn);
        btn_restart.onClick.AddListener(onClickBtnRestart);

        Menu.SetActive(false);
        menuIsActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuIsActive) {
                Menu.SetActive(false);
                menuIsActive = false;
                Time.timeScale = 1;
            } else {
                Menu.SetActive(true);
                menuIsActive = true;
                Time.timeScale = 0;
            }
        }

    }

    void onClickBtnReturn() {
        Menu.SetActive(false);
        menuIsActive = false;
        Time.timeScale = 1;
    }

    void onClickBtnRestart() {
        Menu.SetActive(false);
        menuIsActive = false;
        Time.timeScale = 1;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
