using System;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin.Usuarios
{
    public partial class AgregarUnidades : System.Web.UI.Page
    {
        NavalWarsWSSoapClient servicio;
        private int max_columnas;
        private int max_unidades;
        private int satelites;
        private int caza, helicopteros, bombarderos;
        private int cruceros, fragata;
        private int submarinos;
        private int no_jugador;
        private string mi_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            hayUsuarioConectado();//reviso si entre con un usuario
            servicio = new NavalWarsWSSoapClient();//nuevo servicio
            hayReglasSeteadas();//revisamos que el admin haya puesto reglas
            cargarTableros();//cargamos las imagenes de los tableros
            setContadores();//iniciamos todos los contadores con 1, estos se usan para los nombres de las unidades
            max_unidades = servicio.ortogonalUnidades();//seteamos el contador de unidades
            mi_id = Session["user"].ToString();
        }

        #region Cargar Tableros
        private void cargarTableros()
        {
            label_tablero_satelites.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_satelite.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_aviones.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_aviones.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_barcos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_barcos.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_submarinos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_submarinos.png\" heigh=\"500\" width=\"500\"/>";
        }
        #endregion

        #region Revisar Reglas
        private void hayReglasSeteadas()
        {
            if (!servicio.ortogonalAreRulesSet())
            {
                Response.Write("<script>window.alert('No hay reglas de juego seteadas, contactese con el Administrador');window.location='../Usuario.aspx';</script>");
            }
        }
        private void hayUsuarioConectado()
        {
            if(string.IsNullOrEmpty(Session["user"].ToString()))
                Response.Write("<script>window.alert('Debe ingresar con su usuario primero');window.location='../Home.aspx';</script>");
        }


        #endregion

        #region Agregar Unidades
        private bool estaEnMiTerritorio()//revisamos si el movimiento es legal dentro del territorio
        {
            int val_columna = servicio.columnaAEntero(text_coordenada_x.Text);
            int limite = max_columnas / 2;
            if (mi_id.Equals(servicio.getUsuarioEnTurno()))//agrego unidades del lado izq
            {
                if (val_columna >= limite)
                    return false;
                return true;
            }
            if (val_columna < limite)//agrego unidades del lado der
                return false;
            return true;
        }
        protected void boton_agregar_unidad_Click(object sender, EventArgs e)//aqui intentamos agregar a la unidad
        {
            if (estaEnMiTerritorio())//si el movimiento esta dentro del territorio permitido
            {
                if (!servicio.ortogonalFueraDelTablero(text_coordenada_x.Text, int.Parse(text_coordenada_y.Text)))//si no se sale del tablero
                {
                    string nombre_unidad = drop_tipo_unidades.SelectedValue + contador_aUsar();
                    if (servicio.ortogonalInsertar(nombre_unidad, text_coordenada_x.Text, int.Parse(text_coordenada_y.Text), mi_id))//si se logro insertar
                    {
                        aumentarContador();//aumento el contador correspondiente
                        recargarTablero();//en teoria recargamos el tablero que corresponde
                        updateUnidadesRestantes();//cambio el texto de un label
                        max_unidades--;//reduzco las unidades que quedan por insertar
                        msj_insertar.Text = "Unidad Insertada";
                    }else//seguramente el espacio esta ocupado
                    {
                        msj_insertar.Text = "Espacio Ocupado";
                    }
                }else
                {
                    msj_insertar.Text = "Inserción se sale del tablero";
                }
            }else
            {
                msj_insertar.Text = "No puede insertar en territorio enemigo";
            }
        }
        #endregion

        #region Usuario en turno
        private void setTurno()
        {
            if (servicio.getUsuarioEnTurno().Equals("admin"))
                servicio.setUsuarioEnTurno(mi_id);
        }
        #endregion

        #region Recargar Tablero
        private void recargarTablero()
        {
            int nivel = drop_tipo_unidades.SelectedIndex;
            switch (nivel)
            {
                case 0:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_submarinos.dot", "tablero_submarinos.png", 0);
                    label_tablero_submarinos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_submarinos.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                case 1:
                    servicio.ortogonalTableroDeJuego(MapPath("..Imagenes"), "tablero_barcos.dot", "tablero_barcos.png", 1);
                    label_tablero_barcos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_barcos.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                case 2:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_barcos.dot", "tablero_barcos.png", 1);
                    label_tablero_barcos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_barcos.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                case 3:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_aviones.dot", "tablero_aviones.png", 2);
                    label_tablero_aviones.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_aviones.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                case 4:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_aviones.dot", "tablero_aviones.png", 2);
                    label_tablero_aviones.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_aviones.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                case 5:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_aviones.dot", "tablero_aviones.png", 2);
                    label_tablero_aviones.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_aviones.png\" heigh=\"500\" width=\"500\"/>";
                    break;
                default:
                    servicio.ortogonalTableroDeJuego(MapPath("../Imagenes"), "tablero_satelite.dot", "tablero_satelite.png", 3);
                    label_tablero_satelites.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_satelite.png\" heigh=\"500\" width=\"500\"/>";
                    break;
            }
        }
        #endregion

        #region Aux
        private void setContadores()
        {
            satelites = caza = helicopteros = bombarderos = fragata = cruceros = submarinos = 1;
        }
        private int contador_aUsar()
        {
            string valor = drop_tipo_unidades.SelectedValue;
            switch (valor)
            {
                case "Submarino":
                    return submarinos;
                case "Fragata":
                    return fragata;
                case "Crucero":
                    return cruceros;
                case "Helicoptero de Combate":
                    return helicopteros;
                case "Bombardero":
                    return bombarderos;
                case "Caza":
                    return caza;
                case "Neosatelite":
                    return satelites;
                default:
                    return 1;
            }
        }
        private void aumentarContador()
        {
            string valor = drop_tipo_unidades.SelectedValue;
            switch (valor)
            {
                case "Submarino":
                    submarinos++;
                    break;
                case "Fragata":
                    fragata++;
                    break;
                case "Crucero":
                    cruceros++;
                    break;
                case "Helicoptero de Combate":
                    helicopteros++;
                    break;
                case "Bombardero":
                    bombarderos++;
                    break;
                case "Caza":
                    caza++;
                    break;
                case "Neosatelite":
                    satelites++;
                    break;
                default:
                    break;
            }
        }
        private void updateUnidadesRestantes()
        {
            label_unidades_restantes.Text = "Unidades Restantes:" + max_unidades;
        }
        #endregion

    }
}