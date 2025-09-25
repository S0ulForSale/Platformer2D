using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance = null;

    void Awake()
    {
        // ����������, �� ���� ��� ����� MusicManager
        if (instance != null)
        {
            // ���� ���, ������� ��� ��'���, ��� �������� ����������
            Destroy(gameObject);
            return;
        }

        // ���� �� ������ � ������ MusicManager, �������� ����
        instance = this;

        // "����������" ��'���, ��� �� �� ���������� ��� ������� �� �������
        DontDestroyOnLoad(gameObject);
    }
}
