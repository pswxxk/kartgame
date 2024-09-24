using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float rotateSpeed = 100f; 
    public GameObject itemPrefab;   
    public float respawnTime = 10f;  

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touch my body");
            Destroy(gameObject);      
            StartCoroutine(RespawnItem()); 
        }
    }

    IEnumerator RespawnItem()
    {
        yield return new WaitForSeconds(respawnTime);

        Instantiate(itemPrefab, transform.position, transform.rotation);
    }
}