using PortafolioNETMVC.Models;

namespace PortafolioNETMVC.Servicios;

public class RepositorioProyecto
{
    public List<Proyecto> ObtenerProyectos()
    {
        return new List<Proyecto>()
        {
            new Proyecto()
            {
                Titulo = "Amazon",
                Descripcion = "E-Commerce realizado en ASP.NET Core",
                Link = "https://amazon.com",
                ImagenURL = "/imagenes/amazon.png"
            },
            new Proyecto()
            {
                Titulo = "New York Times",
                Descripcion = "Página de noticias en Angular",
                Link = "https://nytimes.com",
                ImagenURL = "/imagenes/nyt.png"
            },
            new Proyecto()
            {
                Titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                Link = "https://reddit.com",
                ImagenURL = "/imagenes/reddit.png"
            },new Proyecto()
            {
                Titulo = "Steam",
                Descripcion = "Tienda en linea para comprar video juegos",
                Link = "https://steam.com",
                ImagenURL = "/imagenes/steam.png"
            },
            
        };
    }

}