using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    #region singleton
    public static StoreManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject Shop;
    public float ShowShopTime = 1.5f;

    private void Start()
    {
        Shop.SetActive(false);
        StartCoroutine(ShowShop());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1;
            CloseShop();
        }
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        GameManager.instance.DestroyItemInfo();
    }

    IEnumerator ShowShop()
    {
        yield return new WaitForSeconds(ShowShopTime);
        Shop.SetActive(true);
        Time.timeScale = 0;
    }

}
