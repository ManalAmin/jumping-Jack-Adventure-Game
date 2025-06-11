using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPoaition;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //chnage position of arrow

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            changePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            changePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }
    private void changePosition(int _change)
    {
        currentPoaition += _change;

        if(_change !=0)
            SoundManager.instance.PlaySound(changeSound);
       
        if (currentPoaition < 0)

            currentPoaition = options.Length - 1;

        else if (currentPoaition > options.Length - 1)
            currentPoaition = 0;
        rect.position = new Vector3(rect.position.x, options[currentPoaition].position.y, 0);
    }
    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        //access the button component on each option andf call its function 
        options[currentPoaition].GetComponent<Button>().onClick.Invoke();
    }
}
