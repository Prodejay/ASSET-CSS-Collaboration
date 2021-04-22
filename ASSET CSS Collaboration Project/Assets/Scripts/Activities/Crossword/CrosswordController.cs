using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrosswordController : MonoBehaviour
{ 
    public GameObject grid;
    public Button skipButton;
    public GameObject roundEndPanel;

    private Button[] buttons;
    private TextMeshProUGUI[] tiles;
    private TextMeshProUGUI selectedTile;
    private bool finished = false;
    private bool toNext = true;

    private void Start()
    {
        buttons = grid.GetComponentsInChildren<Button>();
        tiles = grid.GetComponentsInChildren<TextMeshProUGUI>();
        roundEndPanel.SetActive(false);
    }
    void Update()
    {
        CheckProgress();

        if (finished && toNext)
        {
            toNext = false;
            skipButton.gameObject.SetActive(false);
            roundEndPanel.SetActive(true);
        }

        // Sets the selected tile's input
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && (vKey >= KeyCode.A && vKey <= KeyCode.Z))
            {
                selectedTile.SetText(vKey.ToString());
            }
        }
    }

    // Sets the clicked tile to be the active and selected tile
    public void tileClicked(Button selected)
    {
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }

        selectedTile = selected.GetComponentInChildren<TextMeshProUGUI>();
        selected.GetComponent<Image>().color = Color.grey;
    }

    // Fills in the puzzle
    public void Skip()
    {
        if (tiles != null)
        {
            tiles[0].text = "H"; tiles[1].text = "C"; tiles[2].text = "E"; tiles[3].text = "L"; tiles[4].text = "L";
            tiles[5].text = "G"; tiles[6].text = "A"; tiles[7].text = "M"; tiles[8].text = "E"; tiles[9].text = "T";
            tiles[10].text = "E"; tiles[11].text = "M"; tiles[12].text = "T"; tiles[13].text = "N"; tiles[14].text = "I";
            tiles[15].text = "E"; tiles[16].text = "C"; tiles[17].text = "O"; tiles[18].text = "S"; tiles[19].text = "Y";
            tiles[20].text = "S"; tiles[21].text = "T"; tiles[22].text = "E"; tiles[23].text = "M"; tiles[24].text = "O";
            tiles[25].text = "C"; tiles[26].text = "R"; tiles[27].text = "R"; tiles[28].text = "M"; tiles[29].text = "R";
            tiles[30].text = "O"; tiles[31].text = "D"; tiles[32].text = "G"; tiles[33].text = "N"; tiles[34].text = "O";
            tiles[35].text = "T"; tiles[36].text = "A"; tiles[37].text = "X"; tiles[38].text = "O"; tiles[39].text = "N";
            tiles[40].text = "O"; tiles[41].text = "M"; tiles[42].text = "Y"; tiles[43].text = "I"; tiles[44].text = "S";
            tiles[45].text = "R"; tiles[46].text = "M"; tiles[47].text = "R"; tiles[48].text = "B"; tiles[49].text = "V";
            tiles[50].text = "C"; tiles[51].text = "O"; tiles[52].text = "A"; tiles[53].text = "G"; tiles[54].text = "I";
            tiles[55].text = "O"; tiles[56].text = "O"; tiles[57].text = "P"; tiles[58].text = "I"; tiles[59].text = "A";
            tiles[60].text = "U"; tiles[61].text = "T"; tiles[62].text = "O"; tiles[63].text = "T"; tiles[64].text = "R";
            tiles[65].text = "O"; tiles[66].text = "P"; tiles[67].text = "H"; tiles[68].text = "H"; tiles[69].text = "N";
            tiles[70].text = "N"; tiles[71].text = "L"; tiles[72].text = "E"; tiles[73].text = "E"; tiles[74].text = "I";
            tiles[75].text = "O"; tiles[76].text = "M"; tiles[77].text = "A"; tiles[78].text = "M"; tiles[79].text = "M";
            tiles[80].text = "A"; tiles[81].text = "L"; tiles[82].text = "S"; tiles[83].text = "G"; tiles[84].text = "M";
            tiles[85].text = "K"; tiles[86].text = "I"; tiles[87].text = "N"; tiles[88].text = "G"; tiles[89].text = "D";
            tiles[90].text = "O"; tiles[91].text = "M"; tiles[92].text = "S"; tiles[93].text = "Z"; tiles[94].text = "Y";
            tiles[95].text = "G"; tiles[96].text = "O"; tiles[97].text = "T"; tiles[98].text = "E";
        }
    }

    // Checks if player has answered the puzzle correctly
    private void CheckProgress()
    {
        if (tiles != null)
        {
            if (tiles[0].text == "H" && tiles[1].text == "C" && tiles[2].text == "E" && tiles[3].text == "L" && tiles[4].text == "L" &&
                tiles[5].text == "G" && tiles[6].text == "A" && tiles[7].text == "M" && tiles[8].text == "E" && tiles[9].text == "T" &&
                tiles[10].text == "E" && tiles[11].text == "M" && tiles[12].text == "T" && tiles[13].text == "N" && tiles[14].text == "I" &&
                tiles[15].text == "E" && tiles[16].text == "C" && tiles[17].text == "O" && tiles[18].text == "S" && tiles[19].text == "Y" &&
                tiles[20].text == "S" && tiles[21].text == "T" && tiles[22].text == "E" && tiles[23].text == "M" && tiles[24].text == "O" &&
                tiles[25].text == "C" && tiles[26].text == "R" && tiles[27].text == "R" && tiles[28].text == "M" && tiles[29].text == "R" &&
                tiles[30].text == "O" && tiles[31].text == "D" && tiles[32].text == "G" && tiles[33].text == "N" && tiles[34].text == "O" &&
                tiles[35].text == "T" && tiles[36].text == "A" && tiles[37].text == "X" && tiles[38].text == "O" && tiles[39].text == "N" &&
                tiles[40].text == "O" && tiles[41].text == "M" && tiles[42].text == "Y" && tiles[43].text == "I" && tiles[44].text == "S" &&
                tiles[45].text == "R" && tiles[46].text == "M" && tiles[47].text == "R" && tiles[48].text == "B" && tiles[49].text == "V" &&
                tiles[50].text == "C" && tiles[51].text == "O" && tiles[52].text == "A" && tiles[53].text == "G" && tiles[54].text == "I" &&
                tiles[55].text == "O" && tiles[56].text == "O" && tiles[57].text == "P" && tiles[58].text == "I" && tiles[59].text == "A" &&
                tiles[60].text == "U" && tiles[61].text == "T" && tiles[62].text == "O" && tiles[63].text == "T" && tiles[64].text == "R" &&
                tiles[65].text == "O" && tiles[66].text == "P" && tiles[67].text == "H" && tiles[68].text == "H" && tiles[69].text == "N" &&
                tiles[70].text == "N" && tiles[71].text == "L" && tiles[72].text == "E" && tiles[73].text == "E" && tiles[74].text == "I" &&
                tiles[75].text == "O" && tiles[76].text == "M" && tiles[77].text == "A" && tiles[78].text == "M" && tiles[79].text == "M" &&
                tiles[80].text == "A" && tiles[81].text == "L" && tiles[82].text == "S" && tiles[83].text == "G" && tiles[84].text == "M" &&
                tiles[85].text == "K" && tiles[86].text == "I" && tiles[87].text == "N" && tiles[88].text == "G" && tiles[89].text == "D" &&
                tiles[90].text == "O" && tiles[91].text == "M" && tiles[92].text == "S" && tiles[93].text == "Z" && tiles[94].text == "Y" &&
                tiles[95].text == "G" && tiles[96].text == "O" && tiles[97].text == "T" && tiles[98].text == "E")
            {
                finished = true;
            }
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("Day3");
    }
}