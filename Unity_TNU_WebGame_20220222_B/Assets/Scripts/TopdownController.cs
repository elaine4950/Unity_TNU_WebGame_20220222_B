using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // 引用UnityEngine 命名空間

// 命名空間 空間名稱
// 多人開發可以使用命名空間區隔系統避免衝突
namespace MengFan
{
    // 公開 類別 腳本名稱 (與左上角檔案名稱相同，大小寫一樣，不能使用空格與特殊字元#@!?)
    // summary 摘要，可以在類別、資料、事件與方法上方添加三條線 ///
    // 簡短說明
    /// <summary>
    /// 角色控制器:Top Down 類型
    /// </summary>
    public class TopdownController : MonoBehaviour
    {
        #region 資料:保存系統需要的基本資料，例如:移動速度、動畫參數名稱與元件等等
        // 欄位 field 語法:
        // 修飾詞 資料類型 欄位名稱 (指定 初始值);
        // private 私人，與public相反:允許其他系統存取

        // [] Attribute 屬性 : 輔助類別、資料、事件與方法
        // SertializeField 序列畫欄位 : 讓私人欄位顯示在屬性面板上
        // Header("標題") 標題
        // Ranger(最小值，最大值) 範圍限制
        [SerializeField, Header("移動速度"), Range(0,100)]
        private float speed = 10.5f;
        private string parameteRun = "開關跑步";
        private string parameterDead = "開關死亡";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;
        #endregion

        #region 事件:程式人口(Unity)．提供開發者驅動系統的窗口
        //喚醒事件:撥放遊戲後執行一次，處理初始化，取得資料，資料初始值
        private void Awake()
        {
            //輸出(訊息)，將訊息輸出到Unity Console(儀錶板)Ctrl+Shift+c
           // print("我是喚醒事件~");

            //欄位 指定為 取得元件<元件名稱>()
            // <泛型> 泛型:指任何類型
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }
        //更新事件:撥放遊戲後以每秒約60次執行，60FPS (Frame Per Second)
        //處理:持續性行為 - 移動、旋轉、縮放，玩家輸入 - 滑鼠、鍵盤、觸控、搖桿
        private void Update()
        {
            //print("我在 Update 事件內~");
            GetInput();
            Move();
        }
        #endregion

        #region 方法:較複雜的功能(陳述式、演算法或程式區塊)
        
        // 方法 method 語法 :
        // 修飾詞 傳回資料類型 方法名稱 (參數) { 程式區塊 }
        // void 無傳回

        /// <summary>
        /// 取得玩家輸入資料
        /// 左右AD Horizontal
        /// 上下WS Vertical
        /// </summary>
        private void GetInput()
        {
            // 使用靜態方法語法 static
            // 類別名稱.靜態方法名稱(對應引數);
            // float h = *****; - 區域變數 : 僅能在該結構(大括號內) 存取
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            // 輸出訊息(訊息) - Ctrl + Shift + C 儀錶板 (Console)
            // print("取得水平軸像值:" + h); 
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            // 使用非靜態屬性 non-static
            // 欄位名稱.靜態屬性名稱 指定 值
            // 鋼體.加速度 = 新 二維向量(水平，垂直) * 速度
            rig.velocity = new Vector2(h, v) * speed;
            // 動畫控制器.設定布林值(參數名稱，布林值)
            // 水平 不等於 零 或者 重值 不等於 零
            ani.SetBool(parameteRun, h != 0 || v != 0);

            // 三元運算子語法
            // 布林值 ? 布林值 等於 True ; 布林值 等於 false
            //  水平 >= 0 角度 0 否則 角度 180
            // 變形元件 ,歐拉角 = 新 三圍向量(X、Y、Z)
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
            
        }
        #endregion
    }
}
