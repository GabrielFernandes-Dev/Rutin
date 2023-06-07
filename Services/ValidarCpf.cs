namespace Services;

public class ValidarCpf
{

    public ValidarCpf()
    {       
    }

    private int CalculaVerificador(int peso, List<int> cpf)
    {

        int soma = 0, j = 0;

        for (int i = peso; i > 1; i--)
        {
            soma += (cpf[j++] * i);
        }

        return (11 - (soma % 11) > 10) ? 0 : (11 - (soma % 11));

    }

    public bool Validar(string Cpf)
    {

        List<int> cpf = new List<int>();

        foreach (char i in Cpf)
        {
            if (char.IsDigit(i))
            {
                cpf.Add(Convert.ToInt32(char.ToString(i)));
            }
        }

        if(cpf.Count == 11) 
        {
            int verificador = CalculaVerificador(10, cpf);

            if (verificador != cpf[9])
            {
                return false;
            }

            verificador = CalculaVerificador(11, cpf);

            if (verificador != cpf[10])
            {
                return false;
            }

            return true;
        }

        return false;

    }

}
