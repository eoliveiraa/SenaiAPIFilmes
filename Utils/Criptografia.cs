namespace api_filmes_senai.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(String senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(String senhaInformada, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
        }


    } 
}
