using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NicolasFernandezRiesen_WindowsFinal
{
    public partial class Form1 : Form
    {
        string nombre;
        string apellido;
        decimal sueldo;
        string puesto;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            sueldo = Convert.ToDecimal(txtSueldo.Text);
            puesto = txtPuesto.Text;
            int flag;

            flag = Validar(nombre, apellido);
            while (flag == 1)
            {
                MessageBox.Show("ERROR EN EL NOMBRE Y/O APELLIDO. REINGRESAR DATOS.");
                nombre = Interaction.InputBox("Ingrese su nombre.", "NOMBRE");
                apellido = Interaction.InputBox("Ingrese su apellido", "APELLIDO");
                flag = Validar(nombre, apellido);
            }

            flag = Validar(sueldo);
            while (flag == 1)
            {
                MessageBox.Show("ERROR SUELDO DEBE SER MAYOR A 0.");
                sueldo = Convert.ToDecimal(Interaction.InputBox("Ingrese su sueldo.", "SUELDO"));
                flag = Validar(sueldo);
            }

            flag = Validar(puesto);
            while (flag == 1)
            {
                MessageBox.Show("ERROR PUESTO NO ENCONTRADO. INGRESE PUESTO EXISTENTE.");
                puesto = Interaction.InputBox("Ingrese su puesto.", "PUESTO");
                flag = Validar(puesto);
            }

            MessageBox.Show("Datos validados correctamente");
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: " + nombre.ToUpper() + " - Apellido: " + apellido.ToUpper() + " - Puesto: " + puesto.ToUpper());
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            int[] horas = new int[5];

            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas el Lunes", "Horas - Lunes"));
                        break;

                    case 1:
                        horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas el Martes", "Horas - Martes"));
                        break;
                    case 2:
                        horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas el Miercoles", "Horas - Miercoles"));
                        break;
                    case 3:
                        horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas el Jueves", "Horas - Jueves"));
                        break;
                    case 4:
                        horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas el Viernes", "Horas - Viernes"));
                        break;
                }
            }

            Imprimir(horas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPuesto.Clear();
            txtSueldo.Clear();
        }

        #region Mis Metodos

        private int Validar(string nombre, string apellido)
        {
            int flag;

            if (nombre.Length > 2 && nombre.Length < 50)
            {
                if(apellido.Length > 2 && apellido.Length < 50)
                {
                    flag = 0;
                }
                else
                {
                    flag = 1;
                }         
            }
            else
            {
                flag = 1;
            }

            return flag;
        }

        private int Validar(decimal sueldo)
        {
            int flag;

            if (sueldo > 0)
            {
                flag = 0;
            }
            else
            {
                flag = 1;   
            }

            return flag;
        }
   
        private int Validar(string puesto)
        {
            int flag;

            if (puesto.ToUpper() == "SOPORTE TECNICO" || puesto.ToUpper() == "DBA" || puesto.ToUpper() == "DESARROLLADOR")
            {
                flag = 0;
            }
            else { flag = 1; }

            return flag;
        }

        private void Imprimir(int[] horas)
        {
            int horasTotal = 0;
            int promedio = 0;
            int cont = 0;

            foreach (int hora in horas)
            {
                horasTotal = horasTotal + hora;
                promedio = promedio + hora;
                if (hora < 4)
                {
                    cont++;
                }
            }

            promedio = promedio / 5;

            MessageBox.Show("Horas totales trabajadas: " + horasTotal.ToString() + ". Promedio: " + promedio.ToString() + ". Dias trabajados con 4 horas o menos horas: " + cont.ToString());
        }

        #endregion
    }
}
