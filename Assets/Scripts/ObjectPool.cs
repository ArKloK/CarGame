using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pool = new List<GameObject>(); // Lista de objetos en la piscina
    private bool objectSelected;

    public GameObject GetObject()
    {
        // Encuentra un objeto aleatorio inactivo en la piscina
        do
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            int selectedObject = Random.Range(0, pool.Count);

            if (!pool[selectedObject].activeInHierarchy)
            {
                // Activa el objeto y lo devuelve
                pool[selectedObject].SetActive(true);
                objectSelected = true;
                return pool[selectedObject];
            }
        } while (!objectSelected);



        // Si no hay objetos disponibles, devuelve null (esto no debería ocurrir si tu pool es suficientemente grande)
        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        // Devuelve un objeto a la piscina desactivándolo
        obj.SetActive(false);
    }
}
