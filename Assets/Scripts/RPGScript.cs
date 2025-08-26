using System.Collections;
using UnityEngine;
using TMPro;

public class RPGScript : MonoBehaviour
{
    public int playerHP = 20;
    public int playerATK = 5;
    public int enemyHP = 15;
    public int enemyATK = 4;
    public bool isPlayerTurn = true;
    public bool isBattleEnd = false;
    public TMP_Text battleText; // TextMeshProのテキスト参照

    void Start()
    {
        SetBattleText("バトル開始！ スペースキーで攻撃");
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
                SetBattleText($"プレイヤーの攻撃！ 敵に{playerATK}ダメージ\n");
                if (enemyHP <= 0)
                {
                    enemyHP = 0;
                    SetBattleText(battleText.text + "敵を倒した！ 勝利！\n");
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
        SetBattleText(battleText.text + $"敵の攻撃！ プレイヤーに{enemyATK}ダメージ\n");
        if (playerHP <= 0)
        {
            playerHP = 0;
            SetBattleText(battleText.text + "プレイヤーは倒れた… 敗北\n");
            isBattleEnd = true;
            ShowStatus();
            yield break;
        }
        ShowStatus();
        isPlayerTurn = true;
    }

    void ShowStatus()
    {
        SetBattleText(battleText.text + $"プレイヤーHP: {playerHP} / 敵HP: {enemyHP}\n");
    }

    void SetBattleText(string msg)
    {
        if (battleText != null)
            battleText.text = msg;
    }
}
