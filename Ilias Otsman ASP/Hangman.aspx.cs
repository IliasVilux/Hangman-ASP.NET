using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ilias_Otsman_ASP
{
    public partial class Hangman : Page
    {
        private static HangmanClass hMan;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hMan = new HangmanClass();
                hMan.GetWord();
                hMan.Vidas = 10;
                hMan.ImgPhase = 0;
                PhaseImage.ImageUrl = $"https://www.oligalma.com/downloads/images/hangman/hangman/{hMan.ImgPhase}.jpg";
            }
            PhaseImage.ImageUrl = (hMan.ImgPhase > 9)
                ? $"https://www.oligalma.com/downloads/images/hangman/hangman/10.jpg"
                : $"https://www.oligalma.com/downloads/images/hangman/hangman/{hMan.ImgPhase}.jpg";

            VidasRestantes.Text = (hMan.Vidas < 1)
                ? $"Vidas restantes: 0"
                : $"Vidas restantes: {hMan.Vidas}";

            GenerateInputs();
            GenerateAlphabet();
        }

        public void GenerateInputs()
        {
            for (int i = 0; i < hMan.PalabraSeleccionada.Length; i++)
            {
                TextBox btnLetter = new TextBox();
                btnLetter.ID = "btn" + i.ToString();
                btnLetter.Enabled = false;
                btnLetter.Attributes["data-name"] = hMan.PalabraSeleccionada[i].ToString();
                btnLetter.CssClass = "inputLetter ms-1 mt-1 text-center m-1";
                btnLetter.Width = 50;

                WordSpaces.Controls.Add(btnLetter);
            }
        }

        public void GenerateAlphabet()
        {
            List<Char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            for (int i = 0; i < alphabet.Count; i++)
            {
                Button btnAlph = new Button();
                btnAlph.ID = "btn" + alphabet[i].ToString();
                btnAlph.CssClass = "btn btn-primary me-1 mt-1 text-center";
                btnAlph.Width = 50;
                btnAlph.Text = alphabet[i].ToString().ToUpper();
                btnAlph.Click += AlphBtn_Click;

                alphabetChars.Controls.Add(btnAlph);
            }
        }

        public void AlphBtn_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            clicked.Enabled = false;

            ComprobarLetra(clicked);

            if (CheckDefeat())
                EndGame("lose");
            if (CheckWin())
                EndGame("win");
        }

        public void ComprobarLetra(Button clicked)
        {
            bool checkFound = false;
            int count = 0;
            foreach (TextBox letter in WordSpaces.Controls)
            {
                if (clicked.Text.ToUpper() == hMan.PalabraSeleccionada[count].ToString().ToUpper())
                {
                    letter.Text = hMan.PalabraSeleccionada[count].ToString().ToUpper();
                    checkFound = true;
                    break;
                }
                count++;
            }

            if (!checkFound)
            {
                hMan.Vidas--;
                hMan.ImgPhase++;
            }

            clicked.CssClass = (checkFound)
                ? "btn btn-success me-1 mt-1 text-center"
                : "btn btn-danger me-1 mt-1 text-center";
        }

        private bool CheckWin()
        {
            foreach (TextBox letter in WordSpaces.Controls)
            {
                if (string.IsNullOrEmpty(letter.Text))
                    return false;
            }
            return true;
        }

        private bool CheckDefeat()
        {
            if (hMan.Vidas == 0 || hMan.ImgPhase == 10)
                return true;
            return false;
        }

        private void EndGame(string opc)
        {
            string mssg = (opc == "lose") ? "Has perdido" : "Has ganado";

            if (opc == "lose")
                VidasRestantes.Text = "Vidas restantes: 0";

            foreach (Button btn in alphabetChars.Controls)
            {
                btn.Enabled = false;
                ResultTxt.InnerText = mssg;
            }
        }
    }
}