namespace AugustosFashion.Entidades.Telefone
{
    public class TelefoneModel
    {
        public TelefoneModel(string numero, TipoTelefone tipoTelefone)
        {
            Numero = numero;
            TipoTelefone = tipoTelefone;
        }
        public TelefoneModel()
        {

        }
        public int IdTelefone { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
