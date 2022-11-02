using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    //Create damage popup just call DamamgePopUp.create(Vector3 position, float damageAmount);
    public static DamagePopUp Create(Vector3 position, float damageAmount, bool isCrit)
    {
        Transform damagePopUPTransform = Instantiate(GameAssets.instance.pfDamagePopUp, position, Quaternion.identity);
        damagePopUPTransform.LookAt(Camera.main.transform);
        damagePopUPTransform.localScale = new Vector3(-1, 1, 1);
        DamagePopUp damagePopUp = damagePopUPTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damageAmount, isCrit);

        return damagePopUp;

    }

    public TextMeshPro TextMesh;

    float disappearTime;
    Color textColor;

    private void Awake()
    {
        
        TextMesh = transform.GetComponent<TextMeshPro>();   
        Destroy(gameObject, 2);
    }

    public void Setup(float damageAmount, bool isCrit)
    {
        TextMesh.SetText(damageAmount.ToString());
        if (!isCrit)
        {
            TextMesh.fontSize = 18;
            textColor = new Color(243, 156, 18);
        }
        else
        {
            TextMesh.fontSize = 36;
            textColor = Color.red;
        }
        
        TextMesh.color = textColor;
        disappearTime = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 3f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        

        disappearTime -= Time.deltaTime;
        if(disappearTime < 0)
        {
            float disappearSpeed = 4f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            TextMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
