namespace MovieRental
{
    partial class SignUpForm
    {
        /// <summary>  
        /// Required designer variable.  
        /// </summary>  
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelResidenceAddress;
        private System.Windows.Forms.TextBox textBoxResidenceAddress;
        private System.Windows.Forms.Label labelBusinessAddress;
        private System.Windows.Forms.TextBox textBoxBusinessAddress;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label labelCreditCard;
        private System.Windows.Forms.TextBox textBoxCreditCard;
        private System.Windows.Forms.Button signup_btn;
        private System.Windows.Forms.Label labelPassword; 
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;

        /// <summary>  
        /// Clean up any resources being used.  
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
        /// Required method for Designer support - do not modify  
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()
        {
            labelName = new Label();
            textBoxName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelResidenceAddress = new Label();
            textBoxResidenceAddress = new TextBox();
            labelBusinessAddress = new Label();
            textBoxBusinessAddress = new TextBox();
            labelPhoneNumber = new Label();
            textBoxPhoneNumber = new TextBox();
            labelCreditCard = new Label();
            textBoxCreditCard = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            signup_btn = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(50, 30);
            labelName.Name = "labelName";
            labelName.Size = new Size(48, 19);
            labelName.TabIndex = 0;
            labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(200, 27);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 26);
            textBoxName.TabIndex = 1;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(50, 150);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 19);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(200, 147);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 26);
            textBoxEmail.TabIndex = 7;
            // 
            // labelResidenceAddress
            // 
            labelResidenceAddress.AutoSize = true;
            labelResidenceAddress.Location = new Point(50, 190);
            labelResidenceAddress.Name = "labelResidenceAddress";
            labelResidenceAddress.Size = new Size(125, 19);
            labelResidenceAddress.TabIndex = 8;
            labelResidenceAddress.Text = "Residence Address:";
            // 
            // textBoxResidenceAddress
            // 
            textBoxResidenceAddress.Location = new Point(200, 187);
            textBoxResidenceAddress.Name = "textBoxResidenceAddress";
            textBoxResidenceAddress.Size = new Size(200, 26);
            textBoxResidenceAddress.TabIndex = 9;
            // 
            // labelBusinessAddress
            // 
            labelBusinessAddress.AutoSize = true;
            labelBusinessAddress.Location = new Point(50, 230);
            labelBusinessAddress.Name = "labelBusinessAddress";
            labelBusinessAddress.Size = new Size(117, 19);
            labelBusinessAddress.TabIndex = 10;
            labelBusinessAddress.Text = "Business Address:";
            // 
            // textBoxBusinessAddress
            // 
            textBoxBusinessAddress.Location = new Point(200, 227);
            textBoxBusinessAddress.Name = "textBoxBusinessAddress";
            textBoxBusinessAddress.Size = new Size(200, 26);
            textBoxBusinessAddress.TabIndex = 11;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Location = new Point(50, 270);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(105, 19);
            labelPhoneNumber.TabIndex = 12;
            labelPhoneNumber.Text = "Phone Number:";
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Location = new Point(200, 267);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(200, 26);
            textBoxPhoneNumber.TabIndex = 13;
            // 
            // labelCreditCard
            // 
            labelCreditCard.AutoSize = true;
            labelCreditCard.Location = new Point(50, 310);
            labelCreditCard.Name = "labelCreditCard";
            labelCreditCard.Size = new Size(82, 19);
            labelCreditCard.TabIndex = 14;
            labelCreditCard.Text = "Credit Card:";
            // 
            // textBoxCreditCard
            // 
            textBoxCreditCard.Location = new Point(200, 307);
            textBoxCreditCard.Name = "textBoxCreditCard";
            textBoxCreditCard.Size = new Size(200, 26);
            textBoxCreditCard.TabIndex = 15;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(50, 70);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 19);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(200, 67);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 26);
            textBoxPassword.TabIndex = 3;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Location = new Point(50, 110);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(123, 19);
            labelConfirmPassword.TabIndex = 4;
            labelConfirmPassword.Text = "Confirm Password:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(200, 107);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(200, 26);
            textBoxConfirmPassword.TabIndex = 5;
            // 
            // signup_btn
            // 
            signup_btn.Location = new Point(226, 360);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(149, 50);
            signup_btn.TabIndex = 16;
            signup_btn.Text = "Sign Up";
            signup_btn.UseVisualStyleBackColor = true;
            signup_btn.Click += signup_btn_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 482);
            Controls.Add(signup_btn);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelConfirmPassword);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(labelEmail);
            Controls.Add(textBoxEmail);
            Controls.Add(labelResidenceAddress);
            Controls.Add(textBoxResidenceAddress);
            Controls.Add(labelBusinessAddress);
            Controls.Add(textBoxBusinessAddress);
            Controls.Add(labelPhoneNumber);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(labelCreditCard);
            Controls.Add(textBoxCreditCard);
            Name = "SignUpForm";
            Text = "Sign Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}