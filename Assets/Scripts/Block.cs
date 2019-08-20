using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] GameObject breakEffectVFX;
    [SerializeField] Sprite[] damageSprites;

    Level level;

    private void Start() { 
        if (tag == "Breakable") {
            level = FindObjectOfType<Level>();
            level.CountBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            timesHit ++;
            if (timesHit >= maxHits) {
                DestroyBlock();
            }
            else {
                ShowNextDamageSprite();
            }
        }
    }

    private void ShowNextDamageSprite() {
        int spriteIndex = timesHit -1;
        GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
    }

    private void DestroyBlock() {
        PlsBreakEffectVFX();
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.SubtractBlocks();
        Destroy(gameObject);
    }

    private void PlsBreakEffectVFX() {
        GameObject sparkles = Instantiate(breakEffectVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
