using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // 引用 系統.集合(資料結構、協同程序)

namespace MengFan
{

    public class HurtNumberEffect : MonoBehaviour
    {
        [SerializeField, Header("淡入數值"), Range(0, 0.5f)]
        private float valueFade = 0.1f;
        [SerializeField, Header("縮放數值"), Range(0, 0.5f)]
        private float valueScale = 0.001f;
        [SerializeField, Header("位移數值"), Range(0, 0.5f)]
        private float valueOffset = 0.1f;
        private CanvasGroup group;
        private RectTransform rect;
        private Text textHurtNumber;
        private void Awake()
        {
            group = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();
            textHurtNumber = transform.Find("傷害數值").GetComponent<Text>();

            //StartCoroutine(Test());
            StartCoroutine(Fade());
            StartCoroutine(Scale());
            StartCoroutine(Offset());
            
            StartCoroutine(Fade(-1,0.8f));
            StartCoroutine(Scale(-1,0.8f));
            StartCoroutine(Offset(-1,0.8f));
        }

        // 協同程序:控制系統等待、停止
        // 1. 引用 System.Collections
        // 2. 定義協同程序方法，傳回類型 IEumerator
        // 3. 使用 yield return new WaitForSeconds(等待秒數)
        // 4. 使用啟動協同程序 StartCoroutine(協同程序方法)

        public void UpdateHurtNumber(float damage)
        {
            textHurtNumber.text = damage.ToString();
        }
        private IEnumerator Test()
        {
            print("第一行");

            yield return new WaitForSeconds(2);

            print("兩秒後，第二行");
        }
 	    private IEnumerator Fade(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);
            for (int i = 0; i < 10 ; i++)
            {
                group.alpha += valueFade * add;
                yield return new WaitForSeconds(0.02f);
            }
        }
        private IEnumerator Scale(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);
            for (int i = 0; i < 5 ; i++)
            {
                rect.localScale += new Vector3(valueScale, valueScale, 0) * add;
                yield return new WaitForSeconds(0.02f);
            }
        }
        private IEnumerator Offset(float add = 1, float wait = 0)
        {
            yield return new WaitForSeconds(wait);
            for(int i = 0; i < 10; i++)
            {
                rect.anchoredPosition += Vector2.up * valueOffset * add;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
