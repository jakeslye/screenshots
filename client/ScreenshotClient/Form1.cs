using Microsoft.Toolkit.Uwp.Notifications;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ScreenshotClient
{
    public partial class Form1 : Form
    {

        bool logedIn = false;

        [DllImport("User32.dll")]
        public static extern bool GetAsyncKeyState(int key);

        public Form1()
        {
            InitializeComponent();
            tick.Start();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string url = "https://Screenshot-server.jakethethe1.repl.co/";

            var client = new RestClient(url);
            var request = new RestRequest("login");
            request.AddParameter("username", username.Text);
            request.AddParameter("password", password.Text);

            var response = client.Post(request);
            var content = response.Content;
            if(content == "good")
            {
                logedIn = true;
                loginText.Text = "You are logged in!";
                loginText.ForeColor = Color.Green;
            }
            else
            {
                loginText.Text = "Login fail!";
            }
        }

        bool keyActive = false;
        private void tick_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(0x11)&&GetAsyncKeyState(0x10)&&GetAsyncKeyState(0x53) && !keyActive&&logedIn)
            {
                keyActive = true;
                Rectangle bounds = Screen.GetBounds(Point.Empty);

                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    bitmap.Save("image.jpg", ImageFormat.Jpeg);
                }

                byte[] imageArray = System.IO.File.ReadAllBytes("image.jpg");
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                string url = "https://Screenshot-server.jakethethe1.repl.co/";

                var client = new RestClient(url);
                var request = new RestRequest("upload");
                request.AddParameter("username", username.Text);
                request.AddParameter("password", password.Text);
                request.AddParameter("image", base64ImageRepresentation);

                var response = client.Post(request);
                var content = response.Content;
                if (!discord.Checked)
                {
                    Clipboard.SetText("https://Screenshot-server.jakethethe1.repl.co/images/" + content);
                }
                else
                {
                    Clipboard.SetText("https://Screenshot-server.jakethethe1.repl.co/http/?id=" + content);
                }

                new ToastContentBuilder()
                .AddText("Picture uploaded")
                .Show();
            }
            if (!GetAsyncKeyState(0x11) && !GetAsyncKeyState(0x10) && !GetAsyncKeyState(0x53))
            {
                keyActive = false;
            }

            if (GetAsyncKeyState(0x11) && GetAsyncKeyState(0x10) && GetAsyncKeyState(0x50))
            {
                this.Show();
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
