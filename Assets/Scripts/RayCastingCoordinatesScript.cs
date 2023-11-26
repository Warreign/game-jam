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

    void StartExplosion()
    {
        // Визначте позицію для вибуху на основі вказаних горизонтальних координат
        Vector3 explosionPosition = new Vector3(explosionCoordinates.x, GetTerrainHeightAtCoordinates(), explosionCoordinates.y);

        // Створення екземпляру анімації вибуху на поверхні терейну
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
    }

    float GetTerrainHeightAtCoordinates()
    {
        // Визначте висоту терейну в точці за горизонтальними координатами
        Ray ray = new Ray(new Vector3(explosionCoordinates.x, 1000f, explosionCoordinates.y), Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
        {
            return hit.point.y;
        }

        return 0f; // Поверніть значення за замовчуванням, якщо Raycasting не вдалося
    }

    // Ваш існуючий код...
}