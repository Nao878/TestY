using System.Collections;
using UnityEngine;

public class RPGScript : MonoBehaviour
{
    public int playerHP = 20;
    public int playerATK = 5;
    public int enemyHP = 15;
    public int enemyATK = 4;
    public bool isPlayerTurn = true;
    public bool isBattleEnd = false;

    void Start()
    {
        Debug.Log("バトル開始！ スペースキーで攻撃");
        ShowStatus();
    }

    void Update()
    {
        if (isBattleEnd) return;

        if (isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // プレイヤーの攻撃
                enemyHP -= playerATK;
                Debug.Log($"プレイヤーの攻撃！ 敵に{playerATK}ダメージ");
                if (enemyHP <= 0)
                {
                    enemyHP = 0;
                    Debug.Log("敵を倒した！ 勝利！");
                    isBattleEnd = true;
                    ShowStatus();
                    return;
                }
                ShowStatus();
                isPlayerTurn = false;
                StartCoroutine(EnemyTurn());
            }
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.0f);
        playerHP -= enemyATK;
        Debug.Log($"敵の攻撃！ プレイヤーに{enemyATK}ダメージ");
        if (playerHP <= 0)
        {
            playerHP = 0;
            Debug.Log("プレイヤーは倒れた… 敗北");
            isBattleEnd = true;
            ShowStatus();
            yield break;
        }
        ShowStatus();
        isPlayerTurn = true;
    }

    void ShowStatus()
    {
        Debug.Log($"プレイヤーHP: {playerHP} / 敵HP: {enemyHP}");
    }
}
