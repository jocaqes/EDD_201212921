using ClienteAdmin.NWwervice;
namespace ClienteAdmin.Clases_aux
{
    public static class Tabla
    {
        #region Juegos de Usuario
        public static string tablaUsuarios(Persona usuario)
        {
            string codigo= "<table style=\"width: 40 %; \">\n";
            codigo += "<tr>\n"
                    + "<td>Oponente</td>\n"
                    + "<td>Unidades Desplegadas</td>\n"
                    + "<td>Unidades Sobrevivientes</td>\n"
                    + "<td>Unidades Destruidas</td>\n"
                    + "<td>Gano(1=si,0=no)</td>\n"
                    + "</tr>\n";
            NodoDOfJuego aux = usuario.juegos.raiz;
            while (aux != null)
            {
                codigo += "<tr>\n";
                codigo += "<td>" +aux.Item.Oponente+ "</td>\n";
                codigo += "<td>" + aux.Item.Unidades_desplegadas + "</td>\n";
                codigo += "<td>" + aux.Item.Unidades_sobrevivientes+ "</td>\n";
                codigo += "<td>" + aux.Item.Unidades_destruidas_por_mi + "</td>\n";
                if (aux.Item.Gane)
                    codigo += "<td>" + 1 + "</td>\n";
                else
                    codigo += "<td>" + 0 + "</td>\n";
                codigo += "</tr>\n";
                aux = aux.siguiente;
            }
            codigo += "</table>\n";
            return codigo;
        }
        #endregion


    }

}