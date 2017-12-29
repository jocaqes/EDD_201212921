using System.Windows.Forms;
using AppCliente.NavalService;

namespace AppCliente
{
    public partial class AgregarUnidades : Form
    {
        private NavalWarsServiceClient servicio;
        private int max_unidades;
        private int filas, columnas;
        private int count_unidades;
        private int count_submarino;
        private int count_fragata, count_crucero;
        private int count_helicoptero, count_bombardero, count_caza;
        private int count_satelite;
        private int id;
        Nodo yo;

        private void boton_insertar_Click(object sender, System.EventArgs e)//agregar una unidad
        {
            if (yo!=null)//si soy el jugador de la izquierda
            {
                if (columnaToInt(text_columna.Text) > columnas / 2)//si quiero ubicar algo despues de la mitad del tablero
                {
                    MessageBox.Show("No puede colocar unidades en area enemiga");
                }else
                {
                    string nombre_unidad = setNombreUnidad(combo_unidades.SelectedItem.ToString());
                    if (servicio.insertarUnidad(servicio.newUnidad(nombre_unidad, text_columna.Text, int.Parse(text_fila.Text), yo.key,1),
                        int.Parse(text_fila.Text),text_columna.Text)){//si se logro insertar
                        count_unidades++;
                        //servicio.graficarTablero("tablero.dot", "tablero.png", 1, 1);
                        MessageBox.Show("Unidad Agregada");
                        text_columna.Text = "";
                        text_fila.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ese espacio esta ocupado");
                    }
                }
            }

            if (count_unidades == max_unidades)
                boton_insertar.Enabled = false;
        }

        public AgregarUnidades(NavalWarsServiceClient servicio,Nodo yo)//constructor
        {
            this.servicio = servicio;
            this.yo = yo;
            max_unidades=servicio.getNoUnidades();
            //label_limite.Text = max_unidades.ToString();
            filas = servicio.getNoFilas();
            columnas = servicio.getNoColumnas();
            InitializeComponent();
        }

        private void AgregarUnidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void setContadores()
        {
            count_unidades = 0;
            count_submarino = 0;
            count_fragata = 0;
            count_crucero = 0;
            count_helicoptero = 0;
            count_bombardero = 0;
            count_caza = 0;
            count_satelite = 0;
        }

        private int columnaToInt(string palabra) {

            char[] aux = palabra.ToCharArray();
            int numero;
            int lenght = aux.Length;
            if (lenght > 1)
                numero = (aux[0] - 64) + (aux[1] - 64) * 26 * (lenght - 1);//ZZ seria el maximo con 702 columnas
            else
                numero = aux[0] - 64;
            return numero;

        }

        private string setNombreUnidad(string tipo)
        {
            switch (tipo)
            {
                case "Submarino":
                    return tipo + count_submarino;
                case "Fragata":
                    return tipo + count_fragata;
                case "Crucero":
                    return tipo + count_crucero;
                case "Helicoptero de Combate":
                    return tipo + count_helicoptero;
                case "Caza":
                    return tipo + count_caza;
                case "Bombardero":
                    return tipo + count_bombardero;
                case "NeoSatelite":
                    return tipo + count_satelite;
                default:
                    return tipo+"rayos";
            }
        }
        private void incrementarUnidad(string tipo)
        {
            switch (tipo)
            {
                case "Submarino":
                    count_submarino++;
                    break;
                case "Fragata":
                    count_fragata++;
                    break;
                case "Crucero":
                    count_crucero++;
                    break;
                case "Helicoptero de Combate":
                    count_helicoptero++;
                    break;
                case "Caza":
                    count_caza++;
                    break;
                case "Bombardero":
                    count_bombardero++;
                    break;
                case "NeoSatelite":
                    count_satelite++;
                    break;
            }
        }
    }
}
