using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour {
    [SerializeField]
    private GameObject typeWriterGuy, laptopGuy, writerGuy, laptop, typeWriter, book, packagerGuy, smallMachine, bigMachine,
                                        temp1 = null, temp2 = null, temp3 = null;
    [SerializeField]
    private Vector3 firstSlotWriter, secondSlotWriter, thirdSlotWriter, firstSlotPackager, secondSlotPackager, thirdSlotPackager,
                                     firstSlotItem, secondSlotItem, thirdSlotItem;
    private void Start() {
        temp1 = Instantiate(packagerGuy, firstSlotPackager, Quaternion.Euler(0, 90, 0));
        temp2 = Instantiate(writerGuy, firstSlotWriter, Quaternion.Euler(0, 180, 0));
        temp3 = Instantiate(book, firstSlotItem, Quaternion.identity);
    }
    public void ProductionUpgradeHandler() {
        var level = GameManager.Instance.ProductionLevel;
        switch (level) {
            case 4:
                //1.slota daktilo ekle, animasyon hızını default yap(yazar için)
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(typeWriterGuy, firstSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(typeWriter, firstSlotItem, Quaternion.identity);
                break;
            case 7:
                //1.slota laptopcu ekle, animasyon hızını default yap(yazar için)
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(laptopGuy, firstSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(laptop, firstSlotItem, Quaternion.Euler(0, 270, 0));
                break;
            case 10:
                //1.slota büyük makine ekle, animasyon hızını default yap(ambalajcı için)
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(bigMachine, new Vector3(-11.15f, -5.6f, 2.15f), Quaternion.Euler(0, 180, 0));
                break;
            case 13:
                //1.slota küçük makine
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(smallMachine, new Vector3(-10f, -4.075f, -4.3f), Quaternion.identity);
                break;
            case 17:
                //2.slota kitapçı ekle, animasyon hızını default yap(yazar için)
                AnimationSpeedHandler(false);
                temp2 = Instantiate(writerGuy, secondSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(book, secondSlotItem, Quaternion.identity);
                break;
            case 20:
                //2.slota daktilocu ekle, animasyon hızını default yap(yazar için)
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(typeWriterGuy, secondSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(typeWriter, secondSlotItem, Quaternion.identity);
                break;
            case 23:
                //2.slota laptopcu ekle
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(laptopGuy, secondSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(laptop, secondSlotItem, Quaternion.Euler(0, 270, 0));
                break;
            case 26:
                //2.slota ambalajcı
                AnimationSpeedHandler(false);
                temp1 = Instantiate(packagerGuy, secondSlotPackager, Quaternion.Euler(0, 90, 0));
                break;
            case 29:
                //2.slota büyük makine ekle
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(bigMachine, new Vector3(-11.15f, -5.6f, 2.15f), Quaternion.Euler(0, 180, 0));

                break;
            case 31:
                //2.slota küçük makine ekle
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(smallMachine, new Vector3(-10f, -4.075f, -2.2f), Quaternion.identity);
                break;
            case 34:
                //3.slota kitapçı
                AnimationSpeedHandler(false);
                temp2 = Instantiate(writerGuy, thirdSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(book, thirdSlotItem, Quaternion.identity);
                break;
            case 37:
                //3.slota daktilocu
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(typeWriterGuy, thirdSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(typeWriter, thirdSlotItem, Quaternion.identity);
                break;
            case 40:
                //3.slota laptopcu
                AnimationSpeedHandler(false);
                Destroy(temp2);
                Destroy(temp3);
                temp2 = Instantiate(laptopGuy, thirdSlotWriter, Quaternion.Euler(0, 180, 0));
                temp3 = Instantiate(laptop, thirdSlotItem, Quaternion.Euler(0, 270, 0));
                break;
            case 43:
                //3.slota ambalajcı
                AnimationSpeedHandler(false);
                temp1 = Instantiate(packagerGuy, thirdSlotPackager, Quaternion.Euler(0, 90, 0));
                break;
            case 46:
                //3.slota büyük mak
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(bigMachine, new Vector3(-11.15f, -5.6f, 2.15f), Quaternion.Euler(0, 180, 0));
                break;
            case 49:
                //3.slota küçük mak
                AnimationSpeedHandler(false);
                Destroy(temp1);
                temp1 = Instantiate(smallMachine, new Vector3(-10f, -4.075f, -6.4f), Quaternion.identity);
                break;
            default:
                AnimationSpeedHandler(true);
                break;
        }
    }
    public void AnimationSpeedHandler(bool speedUp) {
        var animatedObjects = GameObject.FindGameObjectsWithTag("Production");
        if (speedUp) {
            foreach (var animatedObject in animatedObjects) {
                animatedObject.GetComponent<Animator>().speed++;
            }
        }
        else{
            foreach (var animatedObject in animatedObjects) {
                animatedObject.GetComponent<Animator>().speed = 1;
            }
        }
    }
}
