using UnityEngine;

namespace MengFan
{
    public class Exp : MonoBehaviour
    {
        public TypeExp typeExp;
         
        private float rangetoPlayer = 2;
        private float speedtoPlayer = 2;
        private LayerMask layerPlayer = 1 << 3;
        private float destroyDistance = 0.5f;

        private Color colorSmall = new Color(0.5f,0.3f,0.8f);
        private Color colorMiddle = new Color(0.2f,0.8f,0.1f);
        private Color colorBig = new Color(0.8f,0.3f,0.2f);
        
        private Transform traPlayer;
        private SpriteRenderer spr;
        private int exp;
        private LevelManager lvManager;
        
        private void Awake()
        {
            spr = GetComponent<SpriteRenderer>();
            traPlayer = GameObject.Find("貓咪").transform;
            lvManager = GameObject.Find("等級管理器").GetComponent<LevelManager>();
        }

        private void Start()
        {
            SettingExp();
        }

        private void Update()
        {
            CheckPlayerInRange();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.2f, 0.2f);
            Gizmos.DrawSphere(transform.position, rangetoPlayer);
        }

        private void SettingExp()
        {
            switch(typeExp)
            {
                case TypeExp.small:
                    spr.color = colorSmall;
                    exp = 20;
                    break;
                case TypeExp.middle:
                    spr.color = colorMiddle;
                    exp = 100;
                    break;
                case TypeExp.big:
                    spr.color = colorBig;
                    exp = 200;
                    break;
            }
        }

        private void CheckPlayerInRange()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, rangetoPlayer, layerPlayer);

            if(hit)
            {
                FlyToPlayer();
            }
        }

        private void FlyToPlayer()
        {
            Vector3 posExp = transform.position;
            Vector3 posPlayer = traPlayer.position;

            posExp = Vector3.Lerp(posExp, posPlayer, speedtoPlayer * Time.deltaTime);

            transform.position = posExp;

            float dis = Vector3.Distance(posExp, posPlayer);

            if (dis <= destroyDistance)
            {
                lvManager.GetExp(exp);
                Destroy(gameObject);
            }
        }
    }

}