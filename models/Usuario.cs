namespace API.models
{
    public class Usuario
    {
        public EstadoUsuario Estado { get; set; }
        public int IntentosFallidos { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Nivel { get; set; }
  

        public enum EstadoUsuario
        {
            Activo,
            Inactivo,
            Bloqueado
        }
  
}
}