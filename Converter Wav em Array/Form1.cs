using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter_Wav_em_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpando tudo
                txtSaida.Text = string.Empty;

                //Verificações
                if (txtArquivo.Text == string.Empty)
                {
                    throw new Exception("É necessário indicar um arquivo.");
                }

                //Pegando os bytes
                byte[] lSomEmArray = File.ReadAllBytes(txtArquivo.Text);


                //Gerando a saída
                string lSaida = string.Empty;
                lSaida = "{";
                for (int i = 0; i < lSomEmArray.Length; i++)
                {
                    if (i < lSomEmArray.Length - 1)
                    {
                        lSaida += lSomEmArray[i] + ", ";
                    }
                    else
                    {
                        lSaida += lSomEmArray[i];
                    }

                }
                lSaida += "}";

                //Saída
                txtSaida.Text = lSaida;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtArquivo.Text = "";
            }
            catch
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                txtSaida.Text = "";
            }
            catch
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtSaida.Text);
            }
            catch
            {
                return;
            }
        }
    }
}
