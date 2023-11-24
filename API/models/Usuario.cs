namespace API.models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Nivel { get; set; }
        public string Estado { get; set; }

        public static implicit operator Usuario(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}
