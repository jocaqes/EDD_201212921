namespace WSproyecto1.Objetos
{
    [System.Serializable]
    public class Unidad
    {
        private string tipo;
        private string nombre;
        private string x;
        private int y;
        private string duenyo;
        private int movimiento;
        private int alcance;
        private int alcance_;
        private int danyo;
        private int hp;
        private bool visible;
        private bool vivo;
        private int z;

        public Unidad(string nombre, string x, int y, string duenyo, int vivo = 1)
        {
            setTipo(nombre);
            this.x = x;
            this.y = y;
            this.duenyo = duenyo;
            if (vivo == 1)
                this.vivo = true;
            else
                this.vivo = false;
            setPropiedades(tipo);
        }

        #region getters y setters
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

        public string X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
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

        public int Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
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
        #endregion


        public bool mover(int x, int y)
        {
            return false;
        }
        public bool atacar(int x, int y, int z)
        {
            return false;
        }
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
                    Z = 3;
                    break;
                case "Bombardero":
                    Tipo = tipo;
                    Movimiento = 7;
                    Alcance = 0;
                    Danyo = 5;
                    Hp = 10;
                    Z = 2;
                    break;
                case "Caza":
                    Tipo = tipo;
                    Movimiento = 9;
                    Alcance = 1;
                    Danyo = 2;
                    Hp = 20;
                    Z = 2;
                    break;
                case "Helicoptero de Combate":
                    Tipo = "Helicoptero\nde Combate";
                    Movimiento = 9;
                    Alcance = 1;
                    Danyo = 3;
                    Hp = 25;
                    Z = 2;
                    break;
                case "Fragata":
                    Tipo = tipo;
                    Movimiento = 5;
                    Alcance = 6;
                    Alcance_ = 2;
                    Danyo = 3;
                    Hp = 10;
                    Z = 1;
                    break;
                case "Crucero":
                    Tipo = tipo;
                    Movimiento = 6;
                    Alcance = 1;
                    Danyo = 3;
                    Hp = 15;
                    Z = 1;
                    break;
                case "Submarino":
                    Tipo = tipo;
                    Movimiento = 5;
                    Alcance = 1;
                    Danyo = 2;
                    Hp = 10;
                    visible = false;
                    Z = 0;
                    break;
            }
        }
        #endregion

        #region Tipo
        private void setTipo(string nombre)
        {
            if (nombre.Contains("Submarino"))
            {
                Tipo = "Submarino";
            }
            else if (nombre.Contains("NeoSatelite"))
            {
                Tipo = "NeoSatelite";
            }
            else if (nombre.Contains("Fragata"))
            {
                Tipo = "Fragata";
            }
            else if (nombre.Contains("Crucero"))
            {
                Tipo = "Crucero";
            }
            else if (nombre.Contains("Caza"))
            {
                Tipo = "Caza";
            }
            else if (nombre.Contains("Helicoptero de Combate"))
            {
                Tipo = "Helicoptero de Combate";
            }
            else if (nombre.Contains("Bombardero"))
            {
                Tipo = "Bombardero";
            }

        }
        #endregion
    }
}