using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourExistingScript : MonoBehaviour
{
    public GameObject explosionPrefab; // Посилання на об'єкт анімації вибуху
    public LayerMask terrainLayer; // Шар терейну, який будемо використовувати для Raycasting
    public Vector2 explosionCoordinates = new Vector2(0f, 0f); // Горизонтальні координати точки для вибуху

    void Update()
    {
        // Ваш існуючий код...

        // Перевірте, чи була натискана клавіша J
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Викликайте метод для вибуху з затримкою 1 секунда
            Invoke("StartExplosion", 1f);
        }
    }

    public void StartExplosion(int x, int z)
    {
        // Визначте позицію для вибуху на основі вказаних горизонтальних координат
        // float y = GetTerrainHeightAtCoordinates(x, z);

        Vector3 explosionPosition = new Vector3(x, GetTerrainHeightAtCoordinates(x, z), z);

        Debug.Log("Spawned explostion at: " + explosionPosition);

        // Vector3 explosionPosition = new Vector3(x, 50, y);


        Debug.Log("Full coords: " + explosionPosition);
        // Створення екземпляру анімації вибуху на поверхні терейну
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
    }

    float GetTerrainHeightAtCoordinates(float x, float z) 
    {
        // Визначте висоту терейну в точці за горизонтальними координатами
        Ray ray = new Ray(new Vector3(x, 1000f, z), Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
        {
            return hit.point.y;
        }

        return 0f; // Поверніть значення за замовчуванням, якщо Raycasting не вдалося
    }

    // Ваш існуючий код...
}