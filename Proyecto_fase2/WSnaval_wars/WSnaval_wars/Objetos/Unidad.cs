namespace WSnaval_wars.Objetos
{
    [System.Serializable]
    public class Unidad
    {
        private string tipo;
        private string nombre;
        private string col_x;
        private int fila_y;
        private string duenyo;
        private int movimiento;
        private int alcance;
        private int alcance_;
        private int danyo;
        private int hp;
        private bool visible;
        private bool vivo;
        private int nivel_z;

        #region GyS
        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Col_x
        {
            get
            {
                return col_x;
            }

            set
            {
                col_x = value;
            }
        }

        public int Fila_y
        {
            get
            {
                return fila_y;
            }

            set
            {
                fila_y = value;
            }
        }

        public string Duenyo
        {
            get
            {
                return duenyo;
            }

            set
            {
                duenyo = value;
            }
        }

        public int Movimiento
        {
            get
            {
                return movimiento;
            }

            set
            {
                movimiento = value;
            }
        }

        public int Alcance
        {
            get
            {
                return alcance;
            }

            set
            {
                alcance = value;
            }
        }

        public int Alcance_
        {
            get
            {
                return alcance_;
            }

            set
            {
                alcance_ = value;
            }
        }

        public int Danyo
        {
            get
            {
                return danyo;
            }

            set
            {
                danyo = value;
            }
        }

        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
            }
        }

        public bool Vivo
        {
            get
            {
                return vivo;
            }

            set
            {
                vivo = value;
            }
        }

        public int Nivel_z
        {
            get
            {
                return nivel_z;
            }

            set
            {
                nivel_z = value;
            }
        }
        #endregion

        #region Propiedades
        private void setPropiedades(string tipo)
        {
            switch (tipo)
            {
                case "NeoSatelite":
                    Tipo = tipo;
                    Movimiento = 6;
                    Alcance = 0;
                    Danyo = 2;
                    Hp = 10;
                    Nivel_z = 3;
                    break;
                case "Bombardero":
                    Tipo = tipo;
                    Movimiento = 7;
                    Alcance = 0;
                    Danyo = 5;
                    Hp = 10;
                    Nivel_z = 2;
                    break;
                case "Caza":
                    Tipo = tipo;
                    Movimiento = 9;
                    Alcance = 1;
                    Danyo = 2;
                    Hp = 20;
                    Nivel_z = 2;
                    break;
                case "Helicoptero de Combate":
                    Tipo = "Helicoptero\nde Combate";
                    Movimiento = 9;
                    Alcance = 1;
                    Danyo = 3;
                    Hp = 25;
                    Nivel_z = 2;
                    break;
                case "Fragata":
                    Tipo = tipo;
                    Movimiento = 5;
                    Alcance = 6;
                    Alcance_ = 2;
                    Danyo = 3;
                    Hp = 10;
                    Nivel_z = 1;
                    break;
                case "Crucero":
                    Tipo = tipo;
                    Movimiento = 6;
                    Alcance = 1;
                    Danyo = 3;
                    Hp = 15;
                    Nivel_z = 1;
                    break;
                case "Submarino":
                    Tipo = tipo;
                    Movimiento = 5;
                    Alcance = 1;
                    Danyo = 2;
                    Hp = 10;
                    visible = false;
                    Nivel_z = 0;
                    break;
            }
        }
        #endregion

        #region Tipo
        private void setTipo(string nombre)
        {
            nombre = nombre.ToLower();
            if (nombre.Contains("submarino"))
            {
                Tipo = "Submarino";
            }
            else if (nombre.Contains("neosatelite"))
            {
                Tipo = "NeoSatelite";
            }
            else if (nombre.Contains("fragata"))
            {
                Tipo = "Fragata";
            }
            else if (nombre.Contains("crucero"))
            {
                Tipo = "Crucero";
            }
            else if (nombre.Contains("caza"))
            {
                Tipo = "Caza";
            }
            else if (nombre.Contains("helicoptero de combate"))
            {
                Tipo = "Helicoptero de Combate";
            }
            else if (nombre.Contains("bombardero"))
            {
                Tipo = "Bombardero";
            }

        }
        #endregion

        #region Acciones
        public bool puedoMover(int x, int y)
        {
            return x + y <= movimiento;
        }
        public bool recibirDanyo(int danyo)
        {
            hp -= danyo;
            if (hp <= 0)
            {
                hp = 0;
                Vivo = false;
            }
            return vivo;
        }
        #endregion

        public Unidad() { }

        public Unidad(string nombre, string col_x, int fila_y, string duenyo, string vivo="1")
        {
            this.nombre = nombre;
            this.col_x = col_x;
            this.fila_y = fila_y;
            this.duenyo = duenyo;
            if (vivo.Equals("1"))
                this.vivo = true;
            else
                this.vivo = false;
        }
    }
}