using ConsultaCEP;
using System.Threading.Tasks;


class Program
{
    static async Task Main()
    {
        await CepCodigo.CEPConsult();
    }
}
