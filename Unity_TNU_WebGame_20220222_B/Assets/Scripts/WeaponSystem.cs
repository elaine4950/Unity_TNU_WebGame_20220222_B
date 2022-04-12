using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;

        /// <summary>
        /// 計時器
        /// </summary>
        private float timer;
        // 繪製圖示事件 ODG
        // 左用 : 在編輯器內輔助用，執行黨內不會出現
        private void OnDrawGizmos()
        {
            // 1.決定顏色
            // Color(紅，綠，藍，透明度) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            // 2. 繪製圖示
            // 圖示 繪製球體(中心點，半徑)
            // 取得陣列資料與法 : 陣列資料名稱[索引值]

            // for 迴圈 : 重複處理程式區塊
            // (初始值 ; 條件 ; 迴圈結束會執行程式)
            for (int i = 0; i < dataWeapon.v35pawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(dataWeapon.v35pawnPoint[i], 0.1f);
            }
            
        }

        private void Update()
        {
            SpawnWeapon();
        }
        /// <summary>
        /// 生成武器
        /// 1.計算時間
        /// 2.時間累積到間隔時間
        /// 3.生成武器
        /// 4.指定在生成位置上
        /// 5.發射武器
        /// 6.賦予武器攻擊力
        /// </summary>
        private void SpawnWeapon()
        {
            // Time.deltaTime 一個影格的時間
            timer += Time.deltaTime;
            // print("經過的時間:" + timer);

            // 如果計時器 大於等於 間隔時間 就生成 武器
            if (timer >= dataWeapon.interval)
            {
                //print("生成武器");
                //座標
                Vector3 pos = transform.position + dataWeapon.v35pawnPoint[0];
                // Quaternion 四位元 : 紀錄角度資訊類型
                // Quaternion.Identity 零度角(0，0，0)
                // 生成(物件、座標、角度)
                Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
