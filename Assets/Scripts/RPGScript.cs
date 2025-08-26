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
    public TMP_Text battleText; // TextMeshPro�̃e�L�X�g�Q��

    void Start()
    {
        SetBattleText("�o�g���J�n�I �X�y�[�X�L�[�ōU��");
        ShowStatus();
    }

    void Update()
    {
        if (isBattleEnd) return;

        if (isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // �v���C���[�̍U��
                enemyHP -= playerATK;
                SetBattleText($"�v���C���[�̍U���I �G��{playerATK}�_���[�W\n");
                if (enemyHP <= 0)
                {
                    enemyHP = 0;
                    SetBattleText(battleText.text + "�G��|�����I �����I\n");
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
        SetBattleText(battleText.text + $"�G�̍U���I �v���C���[��{enemyATK}�_���[�W\n");
        if (playerHP <= 0)
        {
            playerHP = 0;
            SetBattleText(battleText.text + "�v���C���[�͓|�ꂽ�c �s�k\n");
            isBattleEnd = true;
            ShowStatus();
            yield break;
        }
        ShowStatus();
        isPlayerTurn = true;
    }

    void ShowStatus()
    {
        SetBattleText(battleText.text + $"�v���C���[HP: {playerHP} / �GHP: {enemyHP}\n");
    }

    void SetBattleText(string msg)
    {
        if (battleText != null)
            battleText.text = msg;
    }
}
