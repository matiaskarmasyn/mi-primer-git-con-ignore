namespace WebApplication4
{
    public class Usuariosesion
    {
        string userName;
        string password;
        int idrol;
        string apellido;
        string nombre;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int IdRol { get => idrol; set => idrol = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }


        public Usuariosesion(string Us, string pass, int idr, string ape, string nom)
        {
            userName = Us;
            password = pass;
            idrol = idr;
            apellido = ape;
            nombre = nom;
        }
    }



}