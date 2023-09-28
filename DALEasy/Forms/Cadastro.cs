using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Cadastro : Panel
{
    public static Label Label;
    public static bool LabelNegrito = false;
    public static bool LabelSublinhado = false;
    public static Color LabelCor = Color.Black;

    public static Control UltimoControle;
    public static int QuantidadeControles;

    public static Dictionary<string, bool> ListaControlesObrigatorios;


    public void VerificaControleObrigatorio(string Nome, bool Obrigatorio)
    {
        if (ListaControlesObrigatorios == null)
            ListaControlesObrigatorios = new Dictionary<string, bool>();

        var ControleExiste = ListaControlesObrigatorios.ContainsKey(Nome);

        if (ControleExiste == false & Obrigatorio == true)
            ListaControlesObrigatorios.Add(Nome, Obrigatorio);
    }

    public void AjustarAlturaRichTextBox(object sender, EventArgs e)
    {
        var rtb = (RichTextBox)sender;

        var NovaAltura = 20;

        foreach (var texto in rtb.Lines)
        {
            var TamanhoTexto = TextRenderer.MeasureText(texto.Replace(" ", "-"), rtb.Font);

            var LinhasSemEnter = Math.Ceiling((decimal)TamanhoTexto.Width / (decimal)rtb.Size.Width);

            if (LinhasSemEnter == 0)
            {
                TamanhoTexto = TextRenderer.MeasureText("A", rtb.Font);
                NovaAltura = NovaAltura + TamanhoTexto.Height;
            }
            else if (LinhasSemEnter == 1)
                NovaAltura = NovaAltura + TamanhoTexto.Height;
            else if (LinhasSemEnter > 1)
                NovaAltura = (int)NovaAltura + TamanhoTexto.Height * (int)LinhasSemEnter;
        }

        var DiferencaAltura = NovaAltura - rtb.Height;
        rtb.Height = NovaAltura;

        bool AlterarLocalizaoY = false;

        foreach (var Controle in this.Controls)
        {
            if (Controle is TextBox)
            {
                var ctrl = (TextBox)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is RichTextBox)
            {
                var ctrl = (RichTextBox)Controle;

                if (ctrl.Name == rtb.Name)
                    AlterarLocalizaoY = true;
            }
            else if (Controle is Label)
            {
                var ctrl = (Label)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is NumericUpDown)
            {
                var ctrl = (NumericUpDown)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is DateTimePicker)
            {
                var ctrl = (DateTimePicker)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is CheckBox)
            {
                var ctrl = (CheckBox)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is ComboBox)
            {
                var ctrl = (ComboBox)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is ListBox)
            {
                var ctrl = (ListBox)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
            else if (Controle is Panel)
            {
                var ctrl = (Panel)Controle;

                if (AlterarLocalizaoY == true)
                    ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + DiferencaAltura);
            }
        }

        this.Refresh();
    }

    public void VerificarUltimoControle(Panel Painel)
    {
        UltimoControle = new Control();
        QuantidadeControles = 0;

        foreach (var Controle in this.Controls)
        {
            UltimoControle = (Control)Controle;

            if (Controle is Label)
                QuantidadeControles = QuantidadeControles + 1;
        }
    }

    public void AlterarFonteLabel(bool Negrito, bool Sublinhado, Color Cor)
    {
        LabelNegrito = Negrito;
        LabelSublinhado = Sublinhado;
        LabelCor = Cor;
    }


    public void AddLabel(string TextoLabel, bool ExibirObrigatorio = false)
    {
        var NovaLabel = new Label();
        NovaLabel.Name = "Lbl_" + QuantidadeControles;
        NovaLabel.Text = TextoLabel;

        NovaLabel.Font = new Font(NovaLabel.Font, FontStyle.Regular);
        NovaLabel.ForeColor = LabelCor;

        if (LabelNegrito == true)
            NovaLabel.Font = new Font(NovaLabel.Font, FontStyle.Bold);

        if (LabelSublinhado == true)
            NovaLabel.Font = new Font(NovaLabel.Font, FontStyle.Underline);

        //if (LabelNegrito & LabelSublinhado)
        //    NovaLabel.Font = new Font(NovaLabel.Font, +FontStyle.Bold + FontStyle.Underline);

        var TamanhoTexto = TextRenderer.MeasureText(TextoLabel, NovaLabel.Font);

        NovaLabel.Size = new Size(TamanhoTexto.Width, 15);
        NovaLabel.Location = new Point(this.Location.X, (UltimoControle.Location.Y + UltimoControle.Size.Height) + 20);
        this.Controls.Add(NovaLabel);




        Label = NovaLabel;
    }

    public void AddRodape(decimal altura = 20)
    {
        VerificarUltimoControle(this);

        var NovaLabel = new Label();
        NovaLabel.Name = "Rodape_" + QuantidadeControles;
        NovaLabel.Size = new Size(10, (int)altura);
        NovaLabel.Location = new Point(this.Location.X, (UltimoControle.Location.Y + UltimoControle.Size.Height) + 20);
        this.Controls.Add(NovaLabel);
    }

    public void AddTextBox(string Nome, int TabIndex, string TextoLabel, bool Obrigatorio, string TextoPadrao = "")
    {
        VerificaControleObrigatorio(Nome, Obrigatorio);
        VerificarUltimoControle(this);
        AddLabel(TextoLabel, true);

        var NovoTextBox = new TextBox();
        NovoTextBox.Name = Nome;
        NovoTextBox.Text = TextoPadrao;
        NovoTextBox.Size = new Size(this.Width - (this.Width / 10), 30);
        NovoTextBox.Location = new Point(this.Location.X, Label.Location.Y + 20);
        NovoTextBox.TabIndex = TabIndex;
        this.Controls.Add(NovoTextBox);
    }

    public void AddRichTextBox(string Nome, int TabIndex, string TextoLabel, bool Obrigatorio, string TextoPadrao = "")
    {
        VerificaControleObrigatorio(Nome, Obrigatorio);
        VerificarUltimoControle(this);
        AddLabel(TextoLabel, true);

        var NovoRichTextBox = new RichTextBox();
        NovoRichTextBox.Name = Nome;
        NovoRichTextBox.Text = TextoPadrao;
        NovoRichTextBox.Size = new Size(this.Width - (this.Width / 10), 100);
        NovoRichTextBox.Location = new Point(this.Location.X, Label.Location.Y + 20);
        NovoRichTextBox.TabIndex = TabIndex;
        //NovoRichTextBox.Anchor = (AnchorStyles.Top , AnchorStyles.Right , AnchorStyles.Left) ;

        // AddHandler CType(NovoRichTextBox, Control).KeyDown, AddressOf AjustarAlturaRichTextBox

        this.Controls.Add(NovoRichTextBox);
    }

    public void AddNumericUpDown(string Nome, int TabIndex, string TextoLabel, string Unidade, int CasasDecimais = 0, decimal ValorMinimo = 0, decimal ValorMaximo = 10, decimal ValorPadrao = 1)
    {
        VerificarUltimoControle(this);
        AddLabel(TextoLabel);

        var NovoNumericUpDown = new NumericUpDown();
        NovoNumericUpDown.Name = Nome;
        NovoNumericUpDown.Minimum = ValorMinimo;
        NovoNumericUpDown.Maximum = ValorMaximo;
        NovoNumericUpDown.Value = ValorPadrao;
        NovoNumericUpDown.DecimalPlaces = CasasDecimais;
        NovoNumericUpDown.Size = new Size(((ValorMaximo.ToString().Length + CasasDecimais) * 5) + 50, 100);
        NovoNumericUpDown.Location = new Point(this.Location.X, Label.Location.Y + 20);
        NovoNumericUpDown.TabIndex = TabIndex;

        //(Control)NovoNumericUpDown.Enter = SelecionarTextoNumericUpDown;

        this.Controls.Add(NovoNumericUpDown);

        var LabelUnidade = new Label();
        var TamanhoTexto = TextRenderer.MeasureText(Unidade, LabelUnidade.Font);

        LabelUnidade.Name = "Lbl_Und_" + QuantidadeControles;
        LabelUnidade.Text = Unidade;
        LabelUnidade.Size = new Size(TamanhoTexto.Width, 15);
        LabelUnidade.Location = new Point(this.Location.X + NovoNumericUpDown.Size.Width, Label.Location.Y + 22);
        this.Controls.Add(LabelUnidade);
    }

    public void AddDateTimePicker(string Nome, int TabIndex, string TextoLabel, DateTimePickerFormat Format, string FormatoPeronalizado = "hh:mm")
    {
        VerificarUltimoControle(this);
        AddLabel(TextoLabel);

        var NovoDateTimePicker = new DateTimePicker();


        var Largura = 200.0;
        if (Format == DateTimePickerFormat.Long)
            Largura = 250.0;
        else if (Format == DateTimePickerFormat.Short)
            Largura = 100.0;
        else if (Format == DateTimePickerFormat.Time)
            Largura = 75.0;
        else if (Format == DateTimePickerFormat.Custom)
        {
            NovoDateTimePicker.ShowUpDown = true;
            NovoDateTimePicker.CustomFormat = FormatoPeronalizado;
            var TamanhoTexto = TextRenderer.MeasureText(FormatoPeronalizado, NovoDateTimePicker.Font);
            Largura = TamanhoTexto.Width + 10;
        }


        NovoDateTimePicker.Name = Nome;
        NovoDateTimePicker.Format = Format;
        NovoDateTimePicker.Size = new Size((int)Largura + 10, 100);
        NovoDateTimePicker.Location = new Point(this.Location.X, Label.Location.Y + 20);
        NovoDateTimePicker.TabIndex = TabIndex;
        this.Controls.Add(NovoDateTimePicker);
    }

    public void AddCheckBox(string Nome, int TabIndex, string TextoLabel, string Texto, bool Marcado)
    {
        VerificarUltimoControle(this);

        if (!string.IsNullOrEmpty(TextoLabel))
            AddLabel(TextoLabel);

        var NovoCheckBox = new CheckBox();
        NovoCheckBox.Name = Nome;
        NovoCheckBox.Text = Texto;
        NovoCheckBox.Checked = Marcado;

        if (string.IsNullOrEmpty(TextoLabel))
        {
            NovoCheckBox.Size = new Size(this.Width - 40, 28);
            NovoCheckBox.Location = new Point(this.Location.X, UltimoControle.Location.Y + 25);
        }
        else
        {
            NovoCheckBox.Size = new Size(this.Width - 40, 30);
            NovoCheckBox.Location = new Point(this.Location.X, Label.Location.Y + 20);
        }

        NovoCheckBox.TabIndex = TabIndex;
        this.Controls.Add(NovoCheckBox);
    }

    public void AddRadioButton(string Nome, int TabIndex, string TextoLabel, Dictionary<string, string> Lista, bool Horizontal, string ValorPadrao = "")
    {
        VerificarUltimoControle(this);
        AddLabel(TextoLabel);


        var LocalizacaoX = 0;
        var LocalizacaoY = 0;
        var Largura = 0;
        var Altura = 0;
        var AlturaSubPainel = 0;

        if (Horizontal == true)
        {
            AlturaSubPainel = 50;
            LocalizacaoX = 0;
            LocalizacaoY = 10;
            Largura = 0;
            Altura = 20;
        }
        else
        {
            AlturaSubPainel = Lista.Count * 30;
            LocalizacaoX = 0;
            LocalizacaoY = 10;
            Largura = 0;
            Altura = 20;
        }


        var NovoSubPainel = new Panel();
        NovoSubPainel.Name = "Pnl_" + Nome + "_" + QuantidadeControles;
        NovoSubPainel.Text = Nome;
        NovoSubPainel.Size = new Size(this.Width - 100, AlturaSubPainel);
        NovoSubPainel.Location = new Point(this.Location.X, Label.Location.Y + 10);

        foreach (var Rdb in Lista)
        {
            var NovoRadioButton = new RadioButton();
            NovoRadioButton.Name = NovoSubPainel.Name + "_rdb_" + Rdb.Key;
            NovoRadioButton.Text = Rdb.Value;

            var TamanhoTexto = TextRenderer.MeasureText(Rdb.Value, NovoRadioButton.Font);

            Largura = TamanhoTexto.Width + 20;
            NovoRadioButton.Size = new Size(Largura, Altura);

            if (Horizontal == true)
            {
                NovoRadioButton.Location = new Point(LocalizacaoX, LocalizacaoY);
                LocalizacaoX = LocalizacaoX + Largura + 10; // A Localização X é igual a Localização + a Largura do Rdb anterior + 10 do espaçamento entre eles
            }
            else
            {
                NovoRadioButton.Location = new Point(LocalizacaoX, LocalizacaoY);
                LocalizacaoY = LocalizacaoY + 25;
            }

            if (!string.IsNullOrEmpty(ValorPadrao))
            {
                if (ValorPadrao == Rdb.Value)
                    NovoRadioButton.Checked = true;
            }

            NovoSubPainel.Controls.Add(NovoRadioButton);
        }

        NovoSubPainel.TabIndex = TabIndex;

        this.Controls.Add(NovoSubPainel);
    }

    public void AddComboBox(string Nome, int TabIndex, string TextoLabel, Dictionary<string, string> Lista, string ValorPadrao = "")
    {
        VerificarUltimoControle(this);
        AddLabel(TextoLabel);

        var NovoComboBox = new ComboBox();

        var TamanhoMaior = 0;
        foreach (var item in Lista)
        {
            NovoComboBox.Items.Add(item.Value);
            if (item.Value.Length > TamanhoMaior)
                TamanhoMaior = item.Value.Length;
        }

        NovoComboBox.Name = Nome;
        NovoComboBox.Size = new Size((TamanhoMaior * 8), 100);
        NovoComboBox.Location = new Point(this.Location.X, Label.Location.Y + 20);
        NovoComboBox.TabIndex = TabIndex;

        if (!string.IsNullOrEmpty(ValorPadrao))
            NovoComboBox.Text = ValorPadrao;


        this.Controls.Add(NovoComboBox);
    }



    public void CarregarDadosDoObjeto(object _Objeto) 
    {
        var PropIndex = 0;

        foreach (var property in _Objeto.GetType().GetProperties())
        {
            PropIndex += 1;
            var PropNome = property.Name;
            var PropTipo = property.PropertyType.Name;
            var PropValor = property.GetValue(_Objeto, null).ToString();

            this.AlterarFonteLabel(false, false, Color.Black);

            if (PropTipo.ToLower() == "string")
            {
                this.AddTextBox(PropNome, PropIndex, PropNome, false, PropValor);
            }
            else if (PropTipo.ToLower() == "int32")
            {
                this.AddNumericUpDown(PropNome, PropIndex, PropNome, "", 0, 0, 5000, Convert.ToDecimal(PropValor));
            }
            else if (PropTipo.ToLower() == "boolean")
            {
                var Bolean = bool.Parse(PropValor);

                this.AddCheckBox(PropNome, PropIndex, null, PropNome, Bolean);
            }

        }

    }

    public void CarregarDadosParaObjeto(object _Objeto)
    {
        foreach (var ObjetoControle in this.Controls)
        {

            if (ObjetoControle.GetType() == typeof(TextBox))
            {
                var Controle = (TextBox)ObjetoControle;

                var propertyInfo = _Objeto.GetType().GetProperty(Controle.Name);
                propertyInfo.SetValue(_Objeto, Convert.ChangeType(Controle.Text, propertyInfo.PropertyType), null);

            }
            else if (ObjetoControle.GetType() == typeof(NumericUpDown))
            {
                var Controle = (NumericUpDown)ObjetoControle;

                var propertyInfo = _Objeto.GetType().GetProperty(Controle.Name);
                propertyInfo.SetValue(_Objeto, Convert.ChangeType(Controle.Text, propertyInfo.PropertyType), null);

            }
            else if (ObjetoControle.GetType() == typeof(CheckBox))
            {
                var Controle = (CheckBox)ObjetoControle;

                var propertyInfo = _Objeto.GetType().GetProperty(Controle.Name);
                propertyInfo.SetValue(_Objeto, Convert.ChangeType(Controle.Checked, propertyInfo.PropertyType), null);

            }

        }

    }



    public class ResultadoDetalhamento
    {
        public string Nome { get; set; }
        public string Texto { get; set; }
        public string Tipo { get; set; }
        public Size Tamanho { get; set; }
        public Point Localizacao { get; set; }
        public bool Obrigatorio { get; set; }

        public TextBox TipoTextBox { get; set; }
        public RichTextBox TipoRichTextBox { get; set; }
        public NumericUpDown TipoNumericUpDown { get; set; }
        public DateTimePicker TipoDateTimePicker { get; set; }
        public CheckBox TipoCheckBox { get; set; }
        public ComboBox TipoComboBox { get; set; }
        public ListBox TipoListBox { get; set; }
        public RadioButton TipoRadioButton { get; set; }
        public Label TipoLabel { get; set; }
    }


    



}
