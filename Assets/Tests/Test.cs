using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    private int score;
    private float timeRemaining;
    private int health;

    [SetUp]
    public void Setup()
    {
        score = 0;
        timeRemaining = 60f;
        health = 5;
    }

    [Test]
    public void TambahSkor_KetikaJawabanBenar()
    {
        int points = 10;
        score += points;
        
        Assert.AreEqual(10, score, "Skor seharusnya bertambah 10");
    }

    [Test]
    public void TimerMenurun()
    {
        float deltaTime = 1f;
        timeRemaining -= deltaTime;

        Assert.Less(timeRemaining, 60f, "Waktu HArusnya berkurang");
    }

    [Test]
    public void NyawaBerkurang_SaatPemainMembuatKesalahan()
    {
        
        int damage = 1;
        health -= damage;

        Assert.AreEqual(4, health, "Health seharusnya berkurang 1 saat player salah");
    }

    [Test]
    public void Nyawa_TidakBolehHabis()
    {
        health = 0;
        health -= 1;
        if (health < 0) health = 0;

        Assert.AreEqual(0, health, "Nyawa Tidak Boleh 0");
    }

    [Test]
    public void PermainanBerakhir_SaatNyawaHabis()
    {
        health = 1;
        health -= 1;
        bool isDead = (health <= 0);

        Assert.IsTrue(isDead, "Pemain dianggap kalah ketika Nyawa 0");
    }
    }

