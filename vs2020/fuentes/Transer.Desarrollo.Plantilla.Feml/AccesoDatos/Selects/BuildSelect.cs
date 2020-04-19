using AccesoDatos.Selects.Implementacion;
using System;
using System.Text;

namespace AccesoDatos.Selects
{
    public partial class BuildSelect: IBuildSelect
    {
        public string _select { get; set; }
        private string _Bloque;
        private StringBuilder builder;
        public BuildSelect()
        {
            builder = new StringBuilder();
        }
        public BuildSelect(string bloque)
        {
            builder = new StringBuilder();
            _Bloque = bloque;
        }

        public string Select(string bloque, string instruccion)
        {
            switch (bloque)
            {
                case "Milenio":
                    {
                        break;
                    }
                case "Ministerio":
                    {
                        break;
                    }
                case "Facturacion":
                    {
                        break;
                    }
                case "Bavaria":
                    {
                        break;
                    }
                case "Osp":
                    {
                        break;
                    }
                case "Varios":
                    {
                        _select = Varios(instruccion);
                        break;
                    }
                default:
                    {
                        _select = "El bloque : " + bloque + " no se encuentra definido";
                    break;
                    }
            }
            return _select;
        }

        public string Select(string instruccion)
        {
            switch (_Bloque)
            {
                case "Milenio":
                    {
                        break;
                    }
                case "Ministerio":
                    {
                        break;
                    }
                case "Facturacion":
                    {
                        break;
                    }
                case "Bavaria":
                    {
                        break;
                    }
                case "Osp":
                    {
                        break;
                    }
                case "Varios":
                    {
                        _select = Varios(instruccion);
                        break;
                    }
                default:
                    {
                        _select = "El bloque : " + _Bloque + " no se encuentra definido";
                        break;
                    }
            }
            return _select;
        }

        private string Varios(string instruccion)
        {
            string select = string.Empty;
            switch (instruccion)
            {
                case "GetOficinas":
                    {
                        select = VariosGetOficinas();
                        break;
                    }
                case "GetOficina":
                    {
                        select = VariosGetOficina();
                        break;
                    }
                default:
                    {
                        _select = "La instruccion : " + instruccion + " no se encuentra definida";
                        break;
                    }
            }
            return select;
        }
    }
}
