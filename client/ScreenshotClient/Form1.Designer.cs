
namespace ScreenshotClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.loginText = new System.Windows.Forms.Label();
            this.hide = new System.Windows.Forms.Button();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.discord = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(82, 16);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 23);
            this.username.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(82, 45);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 23);
            this.password.TabIndex = 4;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(13, 74);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(156, 23);
            this.login.TabIndex = 6;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // loginText
            // 
            this.loginText.AutoSize = true;
            this.loginText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.loginText.Location = new System.Drawing.Point(25, 100);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(130, 15);
            this.loginText.TabIndex = 7;
            this.loginText.Text = "You are not logged in :(";
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(189, 13);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(173, 124);
            this.hide.TabIndex = 8;
            this.hide.Text = "Hide Window";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // tick
            // 
            this.tick.Interval = 1;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // discord
            // 
            this.discord.AutoSize = true;
            this.discord.Location = new System.Drawing.Point(34, 118);
            this.discord.Name = "discord";
            this.discord.Size = new System.Drawing.Size(111, 19);
            this.discord.TabIndex = 9;
            this.discord.Text = "Discord Embeds";
            this.discord.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 147);
            this.Controls.Add(this.discord);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Name = "Form1";
            this.Text = "Screen Shots";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label loginText;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.CheckBox discord;
    }
}

