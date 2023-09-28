
namespace DALEasy
{
    partial class Form_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxBancoDeDados = new System.Windows.Forms.GroupBox();
            this.comboBoxTipoBanco = new System.Windows.Forms.ComboBox();
            this.labelTpo = new System.Windows.Forms.Label();
            this.buttonImportar = new System.Windows.Forms.Button();
            this.labelBanco = new System.Windows.Forms.Label();
            this.comboBoxBanco = new System.Windows.Forms.ComboBox();
            this.buttonConectar = new System.Windows.Forms.Button();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelUsiario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelServidor = new System.Windows.Forms.Label();
            this.textBoxServidor = new System.Windows.Forms.TextBox();
            this.groupBoxTabelaseColunas = new System.Windows.Forms.GroupBox();
            this.buttonAdicionarColuna = new System.Windows.Forms.Button();
            this.buttonAdicionarTabela = new System.Windows.Forms.Button();
            this.labelColunas = new System.Windows.Forms.Label();
            this.labelTabelas = new System.Windows.Forms.Label();
            this.dataGridViewColunas = new System.Windows.Forms.DataGridView();
            this.ColumnColunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColunaNomeFomatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColunaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColunaTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColunaPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnColunaNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTabelas = new System.Windows.Forms.DataGridView();
            this.ColumnTabelaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTabelaNomeFormatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxClassesEMetodos = new System.Windows.Forms.GroupBox();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonGerarClasse = new System.Windows.Forms.Button();
            this.buttonGerarClasses = new System.Windows.Forms.Button();
            this.labelMetodos = new System.Windows.Forms.Label();
            this.dataGridViewMetodos = new System.Windows.Forms.DataGridView();
            this.ColumnMetodoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMetodosDML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxNameSpace = new System.Windows.Forms.TextBox();
            this.labelNameSpace = new System.Windows.Forms.Label();
            this.labelLinguagem = new System.Windows.Forms.Label();
            this.comboBoxLinguagem = new System.Windows.Forms.ComboBox();
            this.groupBoxBancoDeDados.SuspendLayout();
            this.groupBoxTabelaseColunas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabelas)).BeginInit();
            this.groupBoxClassesEMetodos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetodos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBancoDeDados
            // 
            this.groupBoxBancoDeDados.Controls.Add(this.comboBoxTipoBanco);
            this.groupBoxBancoDeDados.Controls.Add(this.labelTpo);
            this.groupBoxBancoDeDados.Controls.Add(this.buttonImportar);
            this.groupBoxBancoDeDados.Controls.Add(this.labelBanco);
            this.groupBoxBancoDeDados.Controls.Add(this.comboBoxBanco);
            this.groupBoxBancoDeDados.Controls.Add(this.buttonConectar);
            this.groupBoxBancoDeDados.Controls.Add(this.labelSenha);
            this.groupBoxBancoDeDados.Controls.Add(this.textBoxSenha);
            this.groupBoxBancoDeDados.Controls.Add(this.labelUsiario);
            this.groupBoxBancoDeDados.Controls.Add(this.textBoxUsuario);
            this.groupBoxBancoDeDados.Controls.Add(this.labelServidor);
            this.groupBoxBancoDeDados.Controls.Add(this.textBoxServidor);
            this.groupBoxBancoDeDados.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBancoDeDados.Name = "groupBoxBancoDeDados";
            this.groupBoxBancoDeDados.Size = new System.Drawing.Size(776, 72);
            this.groupBoxBancoDeDados.TabIndex = 0;
            this.groupBoxBancoDeDados.TabStop = false;
            this.groupBoxBancoDeDados.Text = "Banco de Dados";
            // 
            // comboBoxTipoBanco
            // 
            this.comboBoxTipoBanco.FormattingEnabled = true;
            this.comboBoxTipoBanco.Items.AddRange(new object[] {
            "MsSQL",
            "PostgreSQL"});
            this.comboBoxTipoBanco.Location = new System.Drawing.Point(18, 35);
            this.comboBoxTipoBanco.Name = "comboBoxTipoBanco";
            this.comboBoxTipoBanco.Size = new System.Drawing.Size(103, 21);
            this.comboBoxTipoBanco.TabIndex = 12;
            // 
            // labelTpo
            // 
            this.labelTpo.AutoSize = true;
            this.labelTpo.Location = new System.Drawing.Point(19, 20);
            this.labelTpo.Name = "labelTpo";
            this.labelTpo.Size = new System.Drawing.Size(28, 13);
            this.labelTpo.TabIndex = 11;
            this.labelTpo.Text = "Tipo";
            // 
            // buttonImportar
            // 
            this.buttonImportar.Location = new System.Drawing.Point(685, 32);
            this.buttonImportar.Name = "buttonImportar";
            this.buttonImportar.Size = new System.Drawing.Size(75, 23);
            this.buttonImportar.TabIndex = 10;
            this.buttonImportar.Text = "Importar";
            this.buttonImportar.UseVisualStyleBackColor = true;
            this.buttonImportar.Click += new System.EventHandler(this.buttonImportar_Click);
            // 
            // labelBanco
            // 
            this.labelBanco.AutoSize = true;
            this.labelBanco.Location = new System.Drawing.Point(526, 18);
            this.labelBanco.Name = "labelBanco";
            this.labelBanco.Size = new System.Drawing.Size(38, 13);
            this.labelBanco.TabIndex = 8;
            this.labelBanco.Text = "Banco";
            // 
            // comboBoxBanco
            // 
            this.comboBoxBanco.FormattingEnabled = true;
            this.comboBoxBanco.Location = new System.Drawing.Point(526, 34);
            this.comboBoxBanco.Name = "comboBoxBanco";
            this.comboBoxBanco.Size = new System.Drawing.Size(153, 21);
            this.comboBoxBanco.TabIndex = 7;
            // 
            // buttonConectar
            // 
            this.buttonConectar.Location = new System.Drawing.Point(445, 33);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(75, 23);
            this.buttonConectar.TabIndex = 6;
            this.buttonConectar.Text = "Conectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.buttonConectar_Click);
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(336, 20);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(38, 13);
            this.labelSenha.TabIndex = 5;
            this.labelSenha.Text = "Senha";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(339, 35);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '*';
            this.textBoxSenha.Size = new System.Drawing.Size(100, 20);
            this.textBoxSenha.TabIndex = 4;
            // 
            // labelUsiario
            // 
            this.labelUsiario.AutoSize = true;
            this.labelUsiario.Location = new System.Drawing.Point(230, 20);
            this.labelUsiario.Name = "labelUsiario";
            this.labelUsiario.Size = new System.Drawing.Size(43, 13);
            this.labelUsiario.TabIndex = 3;
            this.labelUsiario.Text = "Usuário";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(233, 35);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsuario.TabIndex = 2;
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Location = new System.Drawing.Point(124, 20);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(46, 13);
            this.labelServidor.TabIndex = 1;
            this.labelServidor.Text = "Servidor";
            // 
            // textBoxServidor
            // 
            this.textBoxServidor.Location = new System.Drawing.Point(127, 35);
            this.textBoxServidor.Name = "textBoxServidor";
            this.textBoxServidor.Size = new System.Drawing.Size(100, 20);
            this.textBoxServidor.TabIndex = 0;
            // 
            // groupBoxTabelaseColunas
            // 
            this.groupBoxTabelaseColunas.Controls.Add(this.buttonAdicionarColuna);
            this.groupBoxTabelaseColunas.Controls.Add(this.buttonAdicionarTabela);
            this.groupBoxTabelaseColunas.Controls.Add(this.labelColunas);
            this.groupBoxTabelaseColunas.Controls.Add(this.labelTabelas);
            this.groupBoxTabelaseColunas.Controls.Add(this.dataGridViewColunas);
            this.groupBoxTabelaseColunas.Controls.Add(this.dataGridViewTabelas);
            this.groupBoxTabelaseColunas.Location = new System.Drawing.Point(12, 89);
            this.groupBoxTabelaseColunas.Name = "groupBoxTabelaseColunas";
            this.groupBoxTabelaseColunas.Size = new System.Drawing.Size(776, 199);
            this.groupBoxTabelaseColunas.TabIndex = 1;
            this.groupBoxTabelaseColunas.TabStop = false;
            this.groupBoxTabelaseColunas.Text = "Tabelas e Colunas";
            // 
            // buttonAdicionarColuna
            // 
            this.buttonAdicionarColuna.Location = new System.Drawing.Point(736, 13);
            this.buttonAdicionarColuna.Name = "buttonAdicionarColuna";
            this.buttonAdicionarColuna.Size = new System.Drawing.Size(24, 23);
            this.buttonAdicionarColuna.TabIndex = 5;
            this.buttonAdicionarColuna.Text = "+";
            this.buttonAdicionarColuna.UseVisualStyleBackColor = true;
            this.buttonAdicionarColuna.Click += new System.EventHandler(this.buttonAdicionarColuna_Click);
            // 
            // buttonAdicionarTabela
            // 
            this.buttonAdicionarTabela.Location = new System.Drawing.Point(197, 14);
            this.buttonAdicionarTabela.Name = "buttonAdicionarTabela";
            this.buttonAdicionarTabela.Size = new System.Drawing.Size(24, 23);
            this.buttonAdicionarTabela.TabIndex = 4;
            this.buttonAdicionarTabela.Text = "+";
            this.buttonAdicionarTabela.UseVisualStyleBackColor = true;
            this.buttonAdicionarTabela.Click += new System.EventHandler(this.buttonAdicionarTabela_Click);
            // 
            // labelColunas
            // 
            this.labelColunas.AutoSize = true;
            this.labelColunas.Location = new System.Drawing.Point(224, 23);
            this.labelColunas.Name = "labelColunas";
            this.labelColunas.Size = new System.Drawing.Size(45, 13);
            this.labelColunas.TabIndex = 3;
            this.labelColunas.Text = "Colunas";
            // 
            // labelTabelas
            // 
            this.labelTabelas.AutoSize = true;
            this.labelTabelas.Location = new System.Drawing.Point(16, 23);
            this.labelTabelas.Name = "labelTabelas";
            this.labelTabelas.Size = new System.Drawing.Size(45, 13);
            this.labelTabelas.TabIndex = 2;
            this.labelTabelas.Text = "Tabelas";
            // 
            // dataGridViewColunas
            // 
            this.dataGridViewColunas.AllowUserToAddRows = false;
            this.dataGridViewColunas.AllowUserToDeleteRows = false;
            this.dataGridViewColunas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewColunas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColunas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnColunaNome,
            this.ColumnColunaNomeFomatado,
            this.ColumnColunaTipo,
            this.ColumnColunaTamanho,
            this.ColumnColunaPK,
            this.ColumnColunaNull});
            this.dataGridViewColunas.Location = new System.Drawing.Point(227, 39);
            this.dataGridViewColunas.Name = "dataGridViewColunas";
            this.dataGridViewColunas.ReadOnly = true;
            this.dataGridViewColunas.RowHeadersVisible = false;
            this.dataGridViewColunas.Size = new System.Drawing.Size(533, 153);
            this.dataGridViewColunas.TabIndex = 1;
            this.dataGridViewColunas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewColunas_CellDoubleClick);
            // 
            // ColumnColunaNome
            // 
            this.ColumnColunaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnColunaNome.HeaderText = "Nome";
            this.ColumnColunaNome.Name = "ColumnColunaNome";
            this.ColumnColunaNome.ReadOnly = true;
            this.ColumnColunaNome.Width = 60;
            // 
            // ColumnColunaNomeFomatado
            // 
            this.ColumnColunaNomeFomatado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnColunaNomeFomatado.HeaderText = "Nome Formatado";
            this.ColumnColunaNomeFomatado.Name = "ColumnColunaNomeFomatado";
            this.ColumnColunaNomeFomatado.ReadOnly = true;
            this.ColumnColunaNomeFomatado.Width = 104;
            // 
            // ColumnColunaTipo
            // 
            this.ColumnColunaTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColunaTipo.HeaderText = "Tipo";
            this.ColumnColunaTipo.Name = "ColumnColunaTipo";
            this.ColumnColunaTipo.ReadOnly = true;
            // 
            // ColumnColunaTamanho
            // 
            this.ColumnColunaTamanho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColunaTamanho.HeaderText = "Tamanho";
            this.ColumnColunaTamanho.Name = "ColumnColunaTamanho";
            this.ColumnColunaTamanho.ReadOnly = true;
            // 
            // ColumnColunaPK
            // 
            this.ColumnColunaPK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColunaPK.HeaderText = "PK";
            this.ColumnColunaPK.Name = "ColumnColunaPK";
            this.ColumnColunaPK.ReadOnly = true;
            // 
            // ColumnColunaNull
            // 
            this.ColumnColunaNull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnColunaNull.HeaderText = "Null";
            this.ColumnColunaNull.Name = "ColumnColunaNull";
            this.ColumnColunaNull.ReadOnly = true;
            // 
            // dataGridViewTabelas
            // 
            this.dataGridViewTabelas.AllowUserToAddRows = false;
            this.dataGridViewTabelas.AllowUserToDeleteRows = false;
            this.dataGridViewTabelas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTabelaNome,
            this.ColumnTabelaNomeFormatado});
            this.dataGridViewTabelas.Location = new System.Drawing.Point(15, 39);
            this.dataGridViewTabelas.Name = "dataGridViewTabelas";
            this.dataGridViewTabelas.ReadOnly = true;
            this.dataGridViewTabelas.RowHeadersVisible = false;
            this.dataGridViewTabelas.Size = new System.Drawing.Size(206, 153);
            this.dataGridViewTabelas.TabIndex = 0;
            this.dataGridViewTabelas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTabelas_CellMouseClick);
            this.dataGridViewTabelas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTabelas_CellMouseDoubleClick);
            // 
            // ColumnTabelaNome
            // 
            this.ColumnTabelaNome.HeaderText = "Nome";
            this.ColumnTabelaNome.Name = "ColumnTabelaNome";
            this.ColumnTabelaNome.ReadOnly = true;
            // 
            // ColumnTabelaNomeFormatado
            // 
            this.ColumnTabelaNomeFormatado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTabelaNomeFormatado.HeaderText = "Nome Formatado";
            this.ColumnTabelaNomeFormatado.Name = "ColumnTabelaNomeFormatado";
            this.ColumnTabelaNomeFormatado.ReadOnly = true;
            // 
            // groupBoxClassesEMetodos
            // 
            this.groupBoxClassesEMetodos.Controls.Add(this.buttonLimpar);
            this.groupBoxClassesEMetodos.Controls.Add(this.buttonGerarClasse);
            this.groupBoxClassesEMetodos.Controls.Add(this.buttonGerarClasses);
            this.groupBoxClassesEMetodos.Controls.Add(this.labelMetodos);
            this.groupBoxClassesEMetodos.Controls.Add(this.dataGridViewMetodos);
            this.groupBoxClassesEMetodos.Controls.Add(this.textBoxNameSpace);
            this.groupBoxClassesEMetodos.Controls.Add(this.labelNameSpace);
            this.groupBoxClassesEMetodos.Controls.Add(this.labelLinguagem);
            this.groupBoxClassesEMetodos.Controls.Add(this.comboBoxLinguagem);
            this.groupBoxClassesEMetodos.Location = new System.Drawing.Point(12, 287);
            this.groupBoxClassesEMetodos.Name = "groupBoxClassesEMetodos";
            this.groupBoxClassesEMetodos.Size = new System.Drawing.Size(776, 151);
            this.groupBoxClassesEMetodos.TabIndex = 2;
            this.groupBoxClassesEMetodos.TabStop = false;
            this.groupBoxClassesEMetodos.Text = "Classes e Métodos";
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(662, 25);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(98, 23);
            this.buttonLimpar.TabIndex = 8;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // buttonGerarClasse
            // 
            this.buttonGerarClasse.Location = new System.Drawing.Point(662, 89);
            this.buttonGerarClasse.Name = "buttonGerarClasse";
            this.buttonGerarClasse.Size = new System.Drawing.Size(98, 23);
            this.buttonGerarClasse.TabIndex = 7;
            this.buttonGerarClasse.Text = "Gerar Classe";
            this.buttonGerarClasse.UseVisualStyleBackColor = true;
            this.buttonGerarClasse.Click += new System.EventHandler(this.buttonGerarClasse_Click);
            // 
            // buttonGerarClasses
            // 
            this.buttonGerarClasses.Location = new System.Drawing.Point(662, 118);
            this.buttonGerarClasses.Name = "buttonGerarClasses";
            this.buttonGerarClasses.Size = new System.Drawing.Size(98, 23);
            this.buttonGerarClasses.TabIndex = 6;
            this.buttonGerarClasses.Text = "Gerar Classes";
            this.buttonGerarClasses.UseVisualStyleBackColor = true;
            this.buttonGerarClasses.Click += new System.EventHandler(this.buttonGerarClasses_Click);
            // 
            // labelMetodos
            // 
            this.labelMetodos.AutoSize = true;
            this.labelMetodos.Location = new System.Drawing.Point(224, 9);
            this.labelMetodos.Name = "labelMetodos";
            this.labelMetodos.Size = new System.Drawing.Size(48, 13);
            this.labelMetodos.TabIndex = 5;
            this.labelMetodos.Text = "Métodos";
            // 
            // dataGridViewMetodos
            // 
            this.dataGridViewMetodos.AllowUserToAddRows = false;
            this.dataGridViewMetodos.AllowUserToDeleteRows = false;
            this.dataGridViewMetodos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMetodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMetodoNome,
            this.ColumnMetodosDML});
            this.dataGridViewMetodos.Location = new System.Drawing.Point(227, 25);
            this.dataGridViewMetodos.Name = "dataGridViewMetodos";
            this.dataGridViewMetodos.ReadOnly = true;
            this.dataGridViewMetodos.RowHeadersVisible = false;
            this.dataGridViewMetodos.Size = new System.Drawing.Size(325, 116);
            this.dataGridViewMetodos.TabIndex = 4;
            this.dataGridViewMetodos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMetodos_CellMouseDoubleClick);
            // 
            // ColumnMetodoNome
            // 
            this.ColumnMetodoNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMetodoNome.HeaderText = "Nome";
            this.ColumnMetodoNome.Name = "ColumnMetodoNome";
            this.ColumnMetodoNome.ReadOnly = true;
            // 
            // ColumnMetodosDML
            // 
            this.ColumnMetodosDML.HeaderText = "DML";
            this.ColumnMetodosDML.Name = "ColumnMetodosDML";
            this.ColumnMetodosDML.ReadOnly = true;
            // 
            // textBoxNameSpace
            // 
            this.textBoxNameSpace.Location = new System.Drawing.Point(49, 98);
            this.textBoxNameSpace.Name = "textBoxNameSpace";
            this.textBoxNameSpace.Size = new System.Drawing.Size(121, 20);
            this.textBoxNameSpace.TabIndex = 3;
            this.textBoxNameSpace.MouseLeave += new System.EventHandler(this.textBoxNameSpace_MouseLeave);
            // 
            // labelNameSpace
            // 
            this.labelNameSpace.AutoSize = true;
            this.labelNameSpace.Location = new System.Drawing.Point(46, 83);
            this.labelNameSpace.Name = "labelNameSpace";
            this.labelNameSpace.Size = new System.Drawing.Size(66, 13);
            this.labelNameSpace.TabIndex = 2;
            this.labelNameSpace.Text = "NameSpace";
            // 
            // labelLinguagem
            // 
            this.labelLinguagem.AutoSize = true;
            this.labelLinguagem.Location = new System.Drawing.Point(49, 36);
            this.labelLinguagem.Name = "labelLinguagem";
            this.labelLinguagem.Size = new System.Drawing.Size(59, 13);
            this.labelLinguagem.TabIndex = 1;
            this.labelLinguagem.Text = "Linguagem";
            // 
            // comboBoxLinguagem
            // 
            this.comboBoxLinguagem.FormattingEnabled = true;
            this.comboBoxLinguagem.Items.AddRange(new object[] {
            "C#",
            "VB.Net"});
            this.comboBoxLinguagem.Location = new System.Drawing.Point(49, 51);
            this.comboBoxLinguagem.Name = "comboBoxLinguagem";
            this.comboBoxLinguagem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLinguagem.TabIndex = 0;
            this.comboBoxLinguagem.MouseLeave += new System.EventHandler(this.comboBoxLinguagem_MouseLeave);
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxClassesEMetodos);
            this.Controls.Add(this.groupBoxTabelaseColunas);
            this.Controls.Add(this.groupBoxBancoDeDados);
            this.Name = "Form_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAL Easy";
            this.Load += new System.EventHandler(this.Form_Principal_Load);
            this.groupBoxBancoDeDados.ResumeLayout(false);
            this.groupBoxBancoDeDados.PerformLayout();
            this.groupBoxTabelaseColunas.ResumeLayout(false);
            this.groupBoxTabelaseColunas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabelas)).EndInit();
            this.groupBoxClassesEMetodos.ResumeLayout(false);
            this.groupBoxClassesEMetodos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetodos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBancoDeDados;
        private System.Windows.Forms.Label labelBanco;
        private System.Windows.Forms.ComboBox comboBoxBanco;
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label labelUsiario;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelServidor;
        private System.Windows.Forms.TextBox textBoxServidor;
        private System.Windows.Forms.GroupBox groupBoxTabelaseColunas;
        private System.Windows.Forms.Label labelColunas;
        private System.Windows.Forms.Label labelTabelas;
        private System.Windows.Forms.DataGridView dataGridViewColunas;
        private System.Windows.Forms.DataGridView dataGridViewTabelas;
        private System.Windows.Forms.GroupBox groupBoxClassesEMetodos;
        private System.Windows.Forms.Label labelLinguagem;
        private System.Windows.Forms.ComboBox comboBoxLinguagem;
        private System.Windows.Forms.Button buttonImportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTabelaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTabelaNomeFormatado;
        private System.Windows.Forms.DataGridView dataGridViewMetodos;
        private System.Windows.Forms.Label labelMetodos;
        private System.Windows.Forms.Label labelTpo;
        private System.Windows.Forms.ComboBox comboBoxTipoBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColunaNomeFomatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColunaTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColunaTamanho;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnColunaPK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnColunaNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMetodoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMetodosDML;
        private System.Windows.Forms.TextBox textBoxNameSpace;
        private System.Windows.Forms.Label labelNameSpace;
        private System.Windows.Forms.Button buttonGerarClasse;
        private System.Windows.Forms.Button buttonGerarClasses;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Button buttonAdicionarTabela;
        private System.Windows.Forms.Button buttonAdicionarColuna;
    }
}

