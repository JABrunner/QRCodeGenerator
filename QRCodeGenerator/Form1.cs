using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace QRCodeGenerator
{

    public partial class Form1 : Form
    {

        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\laser\OneDrive\Desktop\Coding Projects\C#\QRCodeGenerator\MMZ3Selection.wav");
        bool mouseDown;
        Point lastPoint;


        public Form1()
        {
            InitializeComponent();
        }
        
       
        //allow the form to be draggable
        private void MouseDown_Event(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastPoint = new Point(e.X, e.Y);

        }

        private void MoveMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void MouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        //add a tool tip to give directions to use
        private void MouseHover_Event(object sender, EventArgs e)
        {
            toolTip1.Show("Type or Paste text into here and click Generate QR Code", textBox1);
        }
        //generate the QR code based on user input and play a sound to notify the conversion has started
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            var MyData = qr.CreateQrCode(textBox1.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            QRCodeBox.Image = code.GetGraphic(50);
        }
        //Add confirmation functionality to exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit the program?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                Application.Exit(); 
            }
            if(DialogResult == DialogResult.Cancel)
                {
                this.Close();
            }
        }
    }
}
