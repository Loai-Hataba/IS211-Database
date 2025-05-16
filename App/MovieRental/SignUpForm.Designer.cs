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
        private System.Windows.Forms.Label headerLabel;

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
            headerLabel = new Label();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            headerLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            headerLabel.Location = new System.Drawing.Point(120, 15);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new System.Drawing.Size(300, 60);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Sign Up";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelName.ForeColor = System.Drawing.Color.White;
            labelName.Location = new System.Drawing.Point(50, 90);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(77, 32);
            labelName.TabIndex = 1;
            labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            textBoxName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxName.Location = new System.Drawing.Point(250, 87);
            textBoxName.MaxLength = 20;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(250, 39);
            textBoxName.TabIndex = 2;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelEmail.ForeColor = System.Drawing.Color.White;
            labelEmail.Location = new System.Drawing.Point(50, 140);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(65, 32);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEmail.Location = new System.Drawing.Point(250, 137);
            textBoxEmail.MaxLength = 30;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(250, 39);
            textBoxEmail.TabIndex = 4;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelPassword.ForeColor = System.Drawing.Color.White;
            labelPassword.Location = new System.Drawing.Point(50, 190);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(104, 32);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.Location = new System.Drawing.Point(250, 187);
            textBoxPassword.MaxLength = 18;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new System.Drawing.Size(250, 39);
            textBoxPassword.TabIndex = 6;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelConfirmPassword.ForeColor = System.Drawing.Color.White;
            labelConfirmPassword.Location = new System.Drawing.Point(50, 240);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new System.Drawing.Size(196, 32);
            labelConfirmPassword.TabIndex = 7;
            labelConfirmPassword.Text = "Confirm Password:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxConfirmPassword.Location = new System.Drawing.Point(250, 237);
            textBoxConfirmPassword.MaxLength = 18;
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new System.Drawing.Size(250, 39);
            textBoxConfirmPassword.TabIndex = 8;
            // 
            // labelResidenceAddress
            // 
            labelResidenceAddress.AutoSize = true;
            labelResidenceAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelResidenceAddress.ForeColor = System.Drawing.Color.White;
            labelResidenceAddress.Location = new System.Drawing.Point(50, 290);
            labelResidenceAddress.Name = "labelResidenceAddress";
            labelResidenceAddress.Size = new System.Drawing.Size(210, 32);
            labelResidenceAddress.TabIndex = 9;
            labelResidenceAddress.Text = "Residence Address:";
            // 
            // textBoxResidenceAddress
            // 
            textBoxResidenceAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxResidenceAddress.Location = new System.Drawing.Point(250, 287);
            textBoxResidenceAddress.MaxLength = 70;
            textBoxResidenceAddress.Name = "textBoxResidenceAddress";
            textBoxResidenceAddress.Size = new System.Drawing.Size(250, 39);
            textBoxResidenceAddress.TabIndex = 10;
            // 
            // labelBusinessAddress
            // 
            labelBusinessAddress.AutoSize = true;
            labelBusinessAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelBusinessAddress.ForeColor = System.Drawing.Color.White;
            labelBusinessAddress.Location = new System.Drawing.Point(50, 340);
            labelBusinessAddress.Name = "labelBusinessAddress";
            labelBusinessAddress.Size = new System.Drawing.Size(202, 32);
            labelBusinessAddress.TabIndex = 11;
            labelBusinessAddress.Text = "Business Address:";
            // 
            // textBoxBusinessAddress
            // 
            textBoxBusinessAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxBusinessAddress.Location = new System.Drawing.Point(250, 337);
            textBoxBusinessAddress.MaxLength = 70;
            textBoxBusinessAddress.Name = "textBoxBusinessAddress";
            textBoxBusinessAddress.Size = new System.Drawing.Size(250, 39);
            textBoxBusinessAddress.TabIndex = 12;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelPhoneNumber.ForeColor = System.Drawing.Color.White;
            labelPhoneNumber.Location = new System.Drawing.Point(50, 390);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new System.Drawing.Size(172, 32);
            labelPhoneNumber.TabIndex = 13;
            labelPhoneNumber.Text = "Phone Number:";
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPhoneNumber.Location = new System.Drawing.Point(250, 387);
            textBoxPhoneNumber.MaxLength = 11;
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new System.Drawing.Size(250, 39);
            textBoxPhoneNumber.TabIndex = 14;
            // 
            // labelCreditCard
            // 
            labelCreditCard.AutoSize = true;
            labelCreditCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelCreditCard.ForeColor = System.Drawing.Color.White;
            labelCreditCard.Location = new System.Drawing.Point(50, 440);
            labelCreditCard.Name = "labelCreditCard";
            labelCreditCard.Size = new System.Drawing.Size(136, 32);
            labelCreditCard.TabIndex = 15;
            labelCreditCard.Text = "Credit Card:";
            // 
            // textBoxCreditCard
            // 
            textBoxCreditCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxCreditCard.Location = new System.Drawing.Point(250, 437);
            textBoxCreditCard.MaxLength = 16;
            textBoxCreditCard.Name = "textBoxCreditCard";
            textBoxCreditCard.Size = new System.Drawing.Size(250, 39);
            textBoxCreditCard.TabIndex = 16;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            signup_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            signup_btn.ForeColor = System.Drawing.Color.White;
            signup_btn.Location = new System.Drawing.Point(250, 500);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new System.Drawing.Size(180, 50);
            signup_btn.TabIndex = 17;
            signup_btn.Text = "Sign Up";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            ClientSize = new System.Drawing.Size(600, 580);
            Controls.Add(headerLabel);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelEmail);
            Controls.Add(textBoxEmail);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelConfirmPassword);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(labelResidenceAddress);
            Controls.Add(textBoxResidenceAddress);
            Controls.Add(labelBusinessAddress);
            Controls.Add(textBoxBusinessAddress);
            Controls.Add(labelPhoneNumber);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(labelCreditCard);
            Controls.Add(textBoxCreditCard);
            Controls.Add(signup_btn);
            Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignUpForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sign Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}