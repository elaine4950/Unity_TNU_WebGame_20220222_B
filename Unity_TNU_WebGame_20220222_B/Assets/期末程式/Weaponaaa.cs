using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengFan
{
    public class Weaponaaa : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;
        [SerializeField, Header("武器刪除時間"), Range(0, 10)]
        private float destroyWeapenTime = 3.5f;
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
                Gizmos.DrawSphere(transform.position + dataWeapon.v35pawnPoint[i], 0.1f);
            }
            
        }

        private void Start()
        {
            // 2D 物理.忽略圖層碰撞(圖層1，圖層2)
            Physics2D.IgnoreLayerCollision(3, 6); // 玩家 與 武器 不碰撞
            Physics2D.IgnoreLayerCollision(6, 6); // 武器 與 武器 不碰撞
            Physics2D.IgnoreLayerCollision(6, 7); // 武器 與 牆壁 不碰撞
        }
        private void Update()
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                // 隨機值 = 隨機.範圍(最小值，最大值) - 整數不包含最大值
                int random = Random.Range(0, dataWeapon.v35pawnPoint.Length);
                //座標
                Vector3 pos = transform.position + dataWeapon.v35pawnPoint[random];
                // Quaternion 四位元 : 紀錄角度資訊類型
                // Quaternion.Identity 零度角(0，0，0)
                // 暫存武器 = 生成(物件、座標、角度)
                GameObject temp = Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);
                // 暫存武器.取得元件<剛體>().添加推力( 方向 * 速度)
                temp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Direction * dataWeapon.speed);
                timer = 0;
                // 刪除物件(要刪除的物件，延遲刪除時間)
                Destroy(temp, destroyWeapenTime);
                // 取得武器.攻擊力 = 武器資料.攻擊力
                temp.GetComponent<Weapon>().attack = dataWeapon.attack;
            }
        }
    }
}