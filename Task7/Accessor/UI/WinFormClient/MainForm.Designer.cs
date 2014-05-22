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
            this.buttonFind = new System.Windows.Forms.Button();
            this.textFindId = new System.Windows.Forms.TextBox();
            this.labelFindId = new System.Windows.Forms.Label();
            this.groupRemoveById = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textRemoveId = new System.Windows.Forms.TextBox();
            this.labelRemoveId = new System.Windows.Forms.Label();
            this.errorId = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupEntities = new System.Windows.Forms.GroupBox();
            this.groupDAL = new System.Windows.Forms.GroupBox();
            this.radioBook = new System.Windows.Forms.RadioButton();
            this.radioAuthor = new System.Windows.Forms.RadioButton();
            this.radioMyORM = new System.Windows.Forms.RadioButton();
            this.radioADONet = new System.Windows.Forms.RadioButton();
            this.radioMemory = new System.Windows.Forms.RadioButton();
            this.radioFile = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.entityGridView)).BeginInit();
            this.groupFindById.SuspendLayout();
            this.groupRemoveById.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorId)).BeginInit();
            this.groupEntities.SuspendLayout();
            this.groupDAL.SuspendLayout();
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
            // textFindId
            // 
            this.textFindId.Location = new System.Drawing.Point(9, 32);
            this.textFindId.Name = "textFindId";
            this.textFindId.Size = new System.Drawing.Size(100, 20);
            this.textFindId.TabIndex = 0;
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
            // textRemoveId
            // 
            this.textRemoveId.Location = new System.Drawing.Point(9, 32);
            this.textRemoveId.Name = "textRemoveId";
            this.textRemoveId.Size = new System.Drawing.Size(100, 20);
            this.textRemoveId.TabIndex = 0;
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
            // errorId
            // 
            this.errorId.ContainerControl = this;
            // 
            // groupEntities
            // 
            this.groupEntities.Controls.Add(this.radioAuthor);
            this.groupEntities.Controls.Add(this.radioBook);
            this.groupEntities.Location = new System.Drawing.Point(12, 265);
            this.groupEntities.Name = "groupEntities";
            this.groupEntities.Size = new System.Drawing.Size(208, 72);
            this.groupEntities.TabIndex = 3;
            this.groupEntities.TabStop = false;
            this.groupEntities.Text = "Сущьность";
            // 
            // groupDAL
            // 
            this.groupDAL.Controls.Add(this.radioFile);
            this.groupDAL.Controls.Add(this.radioMemory);
            this.groupDAL.Controls.Add(this.radioADONet);
            this.groupDAL.Controls.Add(this.radioMyORM);
            this.groupDAL.Location = new System.Drawing.Point(271, 265);
            this.groupDAL.Name = "groupDAL";
            this.groupDAL.Size = new System.Drawing.Size(231, 72);
            this.groupDAL.TabIndex = 4;
            this.groupDAL.TabStop = false;
            this.groupDAL.Text = "DAL";
            // 
            // radioBook
            // 
            this.radioBook.AutoSize = true;
            this.radioBook.Checked = true;
            this.radioBook.Location = new System.Drawing.Point(9, 19);
            this.radioBook.Name = "radioBook";
            this.radioBook.Size = new System.Drawing.Size(54, 17);
            this.radioBook.TabIndex = 0;
            this.radioBook.TabStop = true;
            this.radioBook.Text = "книги";
            this.radioBook.UseVisualStyleBackColor = true;
            // 
            // radioAuthor
            // 
            this.radioAuthor.AutoSize = true;
            this.radioAuthor.Location = new System.Drawing.Point(9, 42);
            this.radioAuthor.Name = "radioAuthor";
            this.radioAuthor.Size = new System.Drawing.Size(62, 17);
            this.radioAuthor.TabIndex = 1;
            this.radioAuthor.Text = "авторы";
            this.radioAuthor.UseVisualStyleBackColor = true;
            // 
            // radioMyORM
            // 
            this.radioMyORM.AutoSize = true;
            this.radioMyORM.Checked = true;
            this.radioMyORM.Location = new System.Drawing.Point(9, 19);
            this.radioMyORM.Name = "radioMyORM";
            this.radioMyORM.Size = new System.Drawing.Size(64, 17);
            this.radioMyORM.TabIndex = 0;
            this.radioMyORM.TabStop = true;
            this.radioMyORM.Text = "MyORM";
            this.radioMyORM.UseVisualStyleBackColor = true;
            // 
            // radioADONet
            // 
            this.radioADONet.AutoSize = true;
            this.radioADONet.Location = new System.Drawing.Point(9, 42);
            this.radioADONet.Name = "radioADONet";
            this.radioADONet.Size = new System.Drawing.Size(73, 17);
            this.radioADONet.TabIndex = 1;
            this.radioADONet.TabStop = true;
            this.radioADONet.Text = "ADO.NET";
            this.radioADONet.UseVisualStyleBackColor = true;
            // 
            // radioMemory
            // 
            this.radioMemory.AutoSize = true;
            this.radioMemory.Location = new System.Drawing.Point(100, 19);
            this.radioMemory.Name = "radioMemory";
            this.radioMemory.Size = new System.Drawing.Size(62, 17);
            this.radioMemory.TabIndex = 2;
            this.radioMemory.TabStop = true;
            this.radioMemory.Text = "Memory";
            this.radioMemory.UseVisualStyleBackColor = true;
            // 
            // radioFile
            // 
            this.radioFile.AutoSize = true;
            this.radioFile.Location = new System.Drawing.Point(100, 42);
            this.radioFile.Name = "radioFile";
            this.radioFile.Size = new System.Drawing.Size(41, 17);
            this.radioFile.TabIndex = 3;
            this.radioFile.TabStop = true;
            this.radioFile.Text = "File";
            this.radioFile.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 349);
            this.Controls.Add(this.groupDAL);
            this.Controls.Add(this.groupEntities);
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
            this.groupEntities.ResumeLayout(false);
            this.groupEntities.PerformLayout();
            this.groupDAL.ResumeLayout(false);
            this.groupDAL.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupDAL;
        private System.Windows.Forms.RadioButton radioMyORM;
        private System.Windows.Forms.GroupBox groupEntities;
        private System.Windows.Forms.RadioButton radioAuthor;
        private System.Windows.Forms.RadioButton radioBook;
        private System.Windows.Forms.RadioButton radioFile;
        private System.Windows.Forms.RadioButton radioMemory;
        private System.Windows.Forms.RadioButton radioADONet;
    }
}

