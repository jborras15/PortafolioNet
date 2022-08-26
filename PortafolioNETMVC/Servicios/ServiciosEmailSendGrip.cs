using PortafolioNETMVC.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortafolioNETMVC.Servicios;

public interface IservicioEmail
{
    Task Enviar(ContactoViewModel contactoViewModel);
}
public class ServiciosEmailSendGrip: IservicioEmail
{
    private readonly IConfiguration _configuration;

    public ServiciosEmailSendGrip(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task Enviar(ContactoViewModel contactoViewModel)
    {
        var apikey = _configuration.GetValue<string>("SENDRID_API_KEY");
        var email = _configuration.GetValue<string>("SENDRID_FROM");
        var nombre = _configuration.GetValue<string>("SENDRID_NOMBRE");

        var cliente = new SendGridClient(apikey);
        var from = new EmailAddress(email, nombre);
        var subject = $"El cliente {contactoViewModel.Email} quiere contactarme";
        var to = new EmailAddress(email, nombre);
        var mensajeTextoPlano = contactoViewModel.Mensaje;
        var contenidoHtml = @$"De: {contactoViewModel.Nombre}
                                Email: {contactoViewModel.Email}
                                Mensaje: {contactoViewModel.Mensaje}";
        var singleEmail = MailHelper.CreateSingleEmail(from, to, subject,
            mensajeTextoPlano, contenidoHtml);
        var respuesta = await cliente.SendEmailAsync(singleEmail);
    }
}

