using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxCharge;
    public float charge;
    public bool canCharge;

    public Image chargeBar;
    public Image black;
    public Text youwin;

    public Camera topCam;
    public Camera bottomCam;

    public GameObject[] doors;

    public LayerMask everything;
    public LayerMask cubeLayer;
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        charge = maxCharge;
    }

    void Update()
    {
        barFillAmount();
        RevealLayer();
    }

    void RevealLayer()
    {
        if (charge < 0)
        {
            charge = 0;
        }
        if (charge > maxCharge)
        {
            charge = maxCharge;
        }

        // when mouse is clicked
        if (Input.GetMouseButton(1) && charge > 0)
        {
            canCharge = false;
            bottomCam.cullingMask = cubeLayer;
            charge -= 4f * Time.deltaTime;
            
            black.enabled = false;
            foreach (GameObject gameObject in doors)
            {
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(1) && charge >= 0)
            {
                canCharge = true;
                
            }

            if (charge <= maxCharge && canCharge == true)
            {
                charge += Time.deltaTime * 0.5f;
            }

            foreach (GameObject gameObject in doors)
            {
                gameObject.GetComponent<Collider>().enabled = true;
            }
            bottomCam.cullingMask = everything;
            black.enabled = true;
        }
    }

    public void barFillAmount()
    {
        chargeBar.fillAmount = charge / maxCharge;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameEnd"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
}
