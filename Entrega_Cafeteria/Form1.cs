using System;
using System.Drawing;
using System.Windows.Forms;

namespace Examen_Cafeteria_Julio
{
    public partial class frmPedidos : Form
    {
        // Valores del negocio
        const decimal recGrande = 25m;
        const decimal recExtra = 30m;
        const decimal descFrec = 0.10m;
        const decimal precioEmp = 20m;
        const decimal tasaItbis = 0.18m;

        decimal acumSub = 0m;

        // Controles del formulario
        TextBox txtCliente;
        DateTimePicker dtpFecha;
        CheckBox chkFrecuente;
        TextBox txtProducto;
        TextBox txtPrecio;
        NumericUpDown nudCantidad;
        RadioButton rbtNormal;
        RadioButton rbtGrande;
        CheckBox chkPorcionExtra;
        RadioButton rbtLocal;
        RadioButton rbtLlevar;
        Label lblEncabezado;
        ListBox lstPedido;
        Label lblSubtotal;
        Label lblDescuento;
        Label lblEmpaque;
        Label lblItbis;
        Label lblTotal;
        Button btnAgregar;
        Button btnCalcular;
        Button btnLimpiar;
        Button btnSalir;

        public frmPedidos()
        {
            InitializeComponent();
            ArmarPantalla();
        }

        void ArmarPantalla()
        {
            this.Text = "Cafetería El Buen Sabor - Pedidos";
            this.Size = new Size(900, 470);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblCli = new Label { Text = "Cliente:", Location = new Point(20, 20), AutoSize = true };
            txtCliente = new TextBox { Name = "txtCliente", Location = new Point(100, 17), Size = new Size(200, 23) };
            chkFrecuente = new CheckBox { Name = "chkFrecuente", Text = "Cliente frecuente", Location = new Point(315, 18), AutoSize = true };

            Label lblFec = new Label { Text = "Fecha:", Location = new Point(20, 52), AutoSize = true };
            dtpFecha = new DateTimePicker { Name = "dtpFecha", Location = new Point(100, 49), Size = new Size(200, 23), Format = DateTimePickerFormat.Short };

            Label lblProd = new Label { Text = "Producto:", Location = new Point(20, 84), AutoSize = true };
            txtProducto = new TextBox { Name = "txtProducto", Location = new Point(100, 81), Size = new Size(200, 23) };

            Label lblPre = new Label { Text = "Precio:", Location = new Point(20, 116), AutoSize = true };
            txtPrecio = new TextBox { Name = "txtPrecio", Location = new Point(100, 113), Size = new Size(110, 23) };

            Label lblCant = new Label { Text = "Cantidad:", Location = new Point(20, 148), AutoSize = true };
            nudCantidad = new NumericUpDown { Name = "nudCantidad", Location = new Point(100, 145), Size = new Size(70, 23), Minimum = 1, Maximum = 20, Value = 1 };

            GroupBox grpTam = new GroupBox { Text = "Tamaño", Location = new Point(20, 185), Size = new Size(185, 85) };
            rbtNormal = new RadioButton { Name = "rbtNormal", Text = "Normal", Location = new Point(12, 22), AutoSize = true, Checked = true };
            rbtGrande = new RadioButton { Name = "rbtGrande", Text = "Grande (+RD$25)", Location = new Point(12, 48), AutoSize = true };
            grpTam.Controls.Add(rbtNormal);
            grpTam.Controls.Add(rbtGrande);

            GroupBox grpServ = new GroupBox { Text = "Servicio", Location = new Point(220, 185), Size = new Size(210, 85) };
            rbtLocal = new RadioButton { Name = "rbtLocal", Text = "Consumir en local", Location = new Point(12, 22), AutoSize = true, Checked = true };
            rbtLlevar = new RadioButton { Name = "rbtLlevar", Text = "Para llevar (+RD$20)", Location = new Point(12, 48), AutoSize = true };
            grpServ.Controls.Add(rbtLocal);
            grpServ.Controls.Add(rbtLlevar);

            chkPorcionExtra = new CheckBox { Name = "chkPorcionExtra", Text = "Porción extra (+RD$30)", Location = new Point(20, 282), AutoSize = true };

            btnCalcular = new Button { Name = "btnCalcular", Text = "Calcular total", Location = new Point(20, 325), Size = new Size(120, 35) };
            btnLimpiar = new Button { Name = "btnLimpiar", Text = "Nuevo pedido", Location = new Point(150, 325), Size = new Size(120, 35) };
            btnSalir = new Button { Name = "btnSalir", Text = "Salir", Location = new Point(280, 325), Size = new Size(95, 35) };

            btnAgregar = new Button { Name = "btnAgregar", Text = "Agregar al pedido", Location = new Point(695, 18), Size = new Size(170, 34) };

            lblEncabezado = new Label
            {
                Name = "lblEncabezado",
                Location = new Point(465, 62),
                Size = new Size(400, 20),
                Font = new Font("Consolas", 9.5f, FontStyle.Bold)
            };

            lstPedido = new ListBox
            {
                Name = "lstPedido",
                Location = new Point(465, 84),
                Size = new Size(400, 150),
                Font = new Font("Consolas", 9.5f)
            };

            Label t1 = new Label { Text = "Subtotal", Location = new Point(565, 252), AutoSize = true };
            Label t2 = new Label { Text = "Descuento", Location = new Point(565, 280), AutoSize = true };
            Label t3 = new Label { Text = "Empaque", Location = new Point(565, 308), AutoSize = true };
            Label t4 = new Label { Text = "ITBIS (18 %)", Location = new Point(565, 336), AutoSize = true };
            Label t5 = new Label { Text = "TOTAL A PAGAR", Location = new Point(565, 366), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };

            lblSubtotal = new Label { Name = "lblSubtotal", Location = new Point(725, 250), Size = new Size(140, 22), TextAlign = ContentAlignment.MiddleRight, BorderStyle = BorderStyle.FixedSingle };
            lblDescuento = new Label { Name = "lblDescuento", Location = new Point(725, 278), Size = new Size(140, 22), TextAlign = ContentAlignment.MiddleRight, BorderStyle = BorderStyle.FixedSingle };
            lblEmpaque = new Label { Name = "lblEmpaque", Location = new Point(725, 306), Size = new Size(140, 22), TextAlign = ContentAlignment.MiddleRight, BorderStyle = BorderStyle.FixedSingle };
            lblItbis = new Label { Name = "lblItbis", Location = new Point(725, 334), Size = new Size(140, 22), TextAlign = ContentAlignment.MiddleRight, BorderStyle = BorderStyle.FixedSingle };
            lblTotal = new Label { Name = "lblTotal", Location = new Point(725, 364), Size = new Size(140, 22), TextAlign = ContentAlignment.MiddleRight, BorderStyle = BorderStyle.FixedSingle, Font = new Font(this.Font, FontStyle.Bold) };

            this.Controls.AddRange(new Control[]
            {
                lblCli, txtCliente, chkFrecuente, lblFec, dtpFecha, lblProd, txtProducto,
                lblPre, txtPrecio, lblCant, nudCantidad, grpTam, grpServ, chkPorcionExtra,
                btnCalcular, btnLimpiar, btnSalir, btnAgregar, lblEncabezado, lstPedido,
                t1, t2, t3, t4, t5, lblSubtotal, lblDescuento, lblEmpaque, lblItbis, lblTotal
            });

            this.Load += frmPedidos_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnSalir.Click += btnSalir_Click;
        }

        string VerMonto(decimal n)
        {
            return "RD$ " + n.ToString("0.00");
        }

        void LimpiarDatosProd()
        {
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
            rbtNormal.Checked = true;
            chkPorcionExtra.Checked = false;
            txtProducto.Focus();
        }

        void BorrarTotales()
        {
            lblSubtotal.Text = VerMonto(0m);
            lblDescuento.Text = VerMonto(0m);
            lblEmpaque.Text = VerMonto(0m);
            lblItbis.Text = VerMonto(0m);
            lblTotal.Text = VerMonto(0m);
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            dtpFecha.Value = DateTime.Today;
            chkFrecuente.Checked = false;
            rbtLocal.Checked = true;
            lstPedido.Items.Clear();

            // Columnas con anchos 6, 24, 10 y 12
            lblEncabezado.Text = "Cant".PadRight(6) + "Producto".PadRight(24) + "Precio".PadLeft(10) + "Total".PadLeft(12);

            acumSub = 0m;
            BorrarTotales();
            LimpiarDatosProd();
            txtCliente.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string prod = txtProducto.Text.Trim();
            if (prod == "")
            {
                MessageBox.Show("Escribe el producto.");
                txtProducto.Focus();
                return;
            }

            decimal precioBase;
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out precioBase) || precioBase <= 0m)
            {
                MessageBox.Show("Digita un precio válido mayor que 0.");
                txtPrecio.Focus();
                return;
            }

            decimal pUnit = precioBase;
            string extraTexto = "Normal";

            if (rbtGrande.Checked)
            {
                pUnit += recGrande;
                extraTexto = "Grande";
            }

            if (chkPorcionExtra.Checked)
            {
                pUnit += recExtra;
                extraTexto = rbtGrande.Checked ? "Grande, Extra" : "Extra";
            }

            int cant = (int)nudCantidad.Value;
            decimal totalFila = pUnit * cant;

            string prodFinal = prod + " (" + extraTexto + ")";
            if (prodFinal.Length > 24)
                prodFinal = prodFinal.Substring(0, 24);

            string fila = cant.ToString().PadRight(6) +
                          prodFinal.PadRight(24) +
                          pUnit.ToString("0.00").PadLeft(10) +
                          totalFila.ToString("0.00").PadLeft(12);

            lstPedido.Items.Add(fila);
            acumSub += totalFila;
            lblSubtotal.Text = VerMonto(acumSub);

            LimpiarDatosProd();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (lstPedido.Items.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto primero.");
                return;
            }

            decimal desc = 0m;
            if (chkFrecuente.Checked)
                desc = acumSub * descFrec;

            decimal emp = 0m;
            if (rbtLlevar.Checked)
                emp = precioEmp;

            decimal baseImp = acumSub - desc + emp;
            decimal itbis = baseImp * tasaItbis;
            decimal total = baseImp + itbis;

            lblSubtotal.Text = VerMonto(acumSub);
            lblDescuento.Text = VerMonto(desc);
            lblEmpaque.Text = VerMonto(emp);
            lblItbis.Text = VerMonto(itbis);
            lblTotal.Text = VerMonto(total);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            frmPedidos_Load(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea salir del programa?", "Confirmar", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}