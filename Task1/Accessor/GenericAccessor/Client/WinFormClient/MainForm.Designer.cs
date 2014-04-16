namespace WinFormClient
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.entityGridView = new System.Windows.Forms.DataGridView();
            this.groupFindById = new System.Windows.Forms.GroupBox();
            this.labelFindId = new System.Windows.Forms.Label();
            this.groupRemoveById = new System.Windows.Forms.GroupBox();
            this.labelRemoveId = new System.Windows.Forms.Label();
            this.textFindId = new System.Windows.Forms.TextBox();
            this.textRemoveId = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.errorId = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.entityGridView)).BeginInit();
            this.groupFindById.SuspendLayout();
            this.groupRemoveById.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorId)).BeginInit();
            this.SuspendLayout();
            // 
            // entityGridView
            // 
            this.entityGridView.AllowUserToAddRows = false;
            this.entityGridView.AllowUserToDeleteRows = false;
            this.entityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entityGridView.Location = new System.Drawing.Point(12, 12);
            this.entityGridView.Name = "entityGridView";
            this.entityGridView.ReadOnly = true;
            this.entityGridView.Size = new System.Drawing.Size(490, 132);
            this.entityGridView.TabIndex = 0;
            // 
            // groupFindById
            // 
            this.groupFindById.Controls.Add(this.buttonFind);
            this.groupFindById.Controls.Add(this.textFindId);
            this.groupFindById.Controls.Add(this.labelFindId);
            this.groupFindById.Location = new System.Drawing.Point(12, 159);
            this.groupFindById.Name = "groupFindById";
            this.groupFindById.Size = new System.Drawing.Size(208, 100);
            this.groupFindById.TabIndex = 1;
            this.groupFindById.TabStop = false;
            this.groupFindById.Text = "Найти по id";
            // 
            // labelFindId
            // 
            this.labelFindId.AutoSize = true;
            this.labelFindId.Location = new System.Drawing.Point(6, 16);
            this.labelFindId.Name = "labelFindId";
            this.labelFindId.Size = new System.Drawing.Size(19, 13);
            this.labelFindId.TabIndex = 0;
            this.labelFindId.Text = "Id:";
            // 
            // groupRemoveById
            // 
            this.groupRemoveById.Controls.Add(this.buttonDelete);
            this.groupRemoveById.Controls.Add(this.textRemoveId);
            this.groupRemoveById.Controls.Add(this.labelRemoveId);
            this.groupRemoveById.Location = new System.Drawing.Point(271, 159);
            this.groupRemoveById.Name = "groupRemoveById";
            this.groupRemoveById.Size = new System.Drawing.Size(231, 100);
            this.groupRemoveById.TabIndex = 2;
            this.groupRemoveById.TabStop = false;
            this.groupRemoveById.Text = "Удалить по id";
            // 
            // labelRemoveId
            // 
            this.labelRemoveId.AutoSize = true;
            this.labelRemoveId.Location = new System.Drawing.Point(6, 16);
            this.labelRemoveId.Name = "labelRemoveId";
            this.labelRemoveId.Size = new System.Drawing.Size(19, 13);
            this.labelRemoveId.TabIndex = 1;
            this.labelRemoveId.Text = "Id:";
            // 
            // textFindId
            // 
            this.textFindId.Location = new System.Drawing.Point(9, 32);
            this.textFindId.Name = "textFindId";
            this.textFindId.Size = new System.Drawing.Size(100, 20);
            this.textFindId.TabIndex = 0;
            // 
            // textRemoveId
            // 
            this.textRemoveId.Location = new System.Drawing.Point(9, 32);
            this.textRemoveId.Name = "textRemoveId";
            this.textRemoveId.Size = new System.Drawing.Size(100, 20);
            this.textRemoveId.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(9, 58);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(59, 25);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(6, 58);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(57, 25);
            this.buttonFind.TabIndex = 1;
            this.buttonFind.Text = "найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // errorId
            // 
            this.errorId.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 262);
            this.Controls.Add(this.groupRemoveById);
            this.Controls.Add(this.groupFindById);
            this.Controls.Add(this.entityGridView);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Form Client";
            ((System.ComponentModel.ISupportInitialize)(this.entityGridView)).EndInit();
            this.groupFindById.ResumeLayout(false);
            this.groupFindById.PerformLayout();
            this.groupRemoveById.ResumeLayout(false);
            this.groupRemoveById.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView entityGridView;
        private System.Windows.Forms.GroupBox groupFindById;
        private System.Windows.Forms.Label labelFindId;
        private System.Windows.Forms.GroupBox groupRemoveById;
        private System.Windows.Forms.Label labelRemoveId;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textFindId;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textRemoveId;
        private System.Windows.Forms.ErrorProvider errorId;
    }
}

