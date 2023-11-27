using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Ilias_Otsman_ASP
{
    public class HangmanClass
    {
        private List<string> palabras = new List<string>{
            "javascript",
            "programacion",
            "tecnologia",
            "web",
            "html",
            "css",
            "nodejs",
            "python",
            "git",
            "backend" };
        private string palabraSeleccionada = "";
        private int vidas = 10;
        private int imgPhase = 0;

        public List<string> Palabras
        { get { return palabras; } set { palabras = value; } }

        public string PalabraSeleccionada
        { get { return palabraSeleccionada; } set { palabraSeleccionada = value; } }

        public int Vidas
        { get { return vidas; } set { vidas = value; } }

        public int ImgPhase
        { get { return imgPhase; } set { imgPhase = value; } }

        public HangmanClass() { }

        public void GetWord()
        {
            Random random = new Random();
            int randNum = random.Next(0, Palabras.Count);

            PalabraSeleccionada = Palabras[randNum];
        }
    }
}