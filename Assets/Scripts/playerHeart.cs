// using UnityEngine;
// using System.Collections.Generic;
// using System.Collections;
// public class playerHeart : MonoBehaviour
// {
//     public int maxHealth = 3; // Maximum health
//     public int currentHealth; // Current health
//     public HeartUI heartUI; // phần hiển thị trái tim
//     void Start()
//     {
//         currentHealth = maxHealth; // Initialize current health
//         heartUI.SetMaxHealth(maxHealth); // Set the maximum health in the HeartUI
//     }

//     // Update is called once per frame
//    private void OnTriggerEnter2D(Collider2D collision)
//     {
//       Enemy enemy = collision.GetComponent<Enemy>();
//         if (enemy)
//         {
//             TakeDamage();//enemy.damage // Gọi hàm TakeDamage khi va chạm với Enemy
//         }
//     }
//     private void TakeDamage()
//     {
//         currentHealth -= //damage ; // Giảm máu
//         heartUI.UpdatetHealth(currentHealth); // Cập nhật hiển thị trái tim
//         if (currentHealth <= 0)
//         {
//             //game over
//             Debug.Log("Game Over!"); // Thông báo game over
//         }




//     }
// }
