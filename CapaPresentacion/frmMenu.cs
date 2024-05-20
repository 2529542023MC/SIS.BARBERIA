using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class frmMenu : Form
    {
        //Campos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public frmMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,48);
            panelMenu.Controls.Add(leftBorderBtn);
            //Formulario
            this.Text = string.Empty;
            this.ControlBox = false; 
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBColors
        {

            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(224, 151, 255);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(152, 245, 249);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(255, 236, 161);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(185, 254, 158);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(255, 164, 165);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(158, 154, 254);
        }

        //Metodos
        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn!=null)
            {
                DisableButton();
                //Boton
                currentBtn = (IconButton)senderBtn;     
                currentBtn.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Borde izquierdo del boton
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //activeBtn
             /*   activeBtn.IconChar = currentBtn.IconChar;
                activeBtn.IconColor = color;*/
            }
        }
        private void DisableButton()
        {
            if(currentBtn!=null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = System.Drawing.Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenForm(Form childForm)
        {
            if (currentChildForm!=null)
            {
                //Abrir
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelEscritorio.Controls.Add(childForm);
            panelEscritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //frmHomeMenu.Text = childForm.Text;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenForm(new frmEmpleado());
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenForm(new Form1());

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenForm(new frmProducto());

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenForm(new frmMovimiento());

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenForm(new frmReporte());

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenForm(new frmCliente());

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();

            }
            else
            {
                Reset();
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            //activeBtn
          /*  activeBtn.IconChar = IconChar.Home;
            activeBtn.IconColor = System.Drawing.Color.Thistle;
            frmHomeMenu.Text = "Home";*/
        }

        //Importacion para hacer drag en el formulario
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;

            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
