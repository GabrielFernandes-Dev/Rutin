namespace Services;

public class ValidarCpf
{

    public ValidarCpf()
    {
        
    }

    private bool hasSpecialCharacters(string s)
    {

        bool r = true;

        for(int i = 0; i < s.Length; i++)
        {
            //064.324.575-80
            if(i == 3 || i == 7)
            {
                r = s[i] == '.';
            }

            if(i == 11)
            {
                r = s[i] == '-';
            }

        }

        return r;

    }

    public bool Validar(string Cpf)
    {

        if (Cpf != null)
        {
            if(Cpf.Length == 11 || Cpf.Length == 14) 
            {
                int numerosSomados = 0;
                int peso = 10;
                int soma = 0;
                int primeiroDigitoVerificador, segundoDigitoVerificador;
                if(Cpf.Length == 11 && !hasSpecialCharacters(Cpf))
                {
                    primeiroDigitoVerificador = Convert.ToInt32(Convert.ToString(Cpf[9]));
                    segundoDigitoVerificador = Convert.ToInt32(Convert.ToString(Cpf[10]));
                }

                else if(Cpf.Length == 14 && hasSpecialCharacters(Cpf))
                {
                    
                    primeiroDigitoVerificador = Convert.ToInt32(Convert.ToString(Cpf[12]));
                    segundoDigitoVerificador = Convert.ToInt32(Convert.ToString(Cpf[13]));

                }
                else
                {
                    return false;
                }

                int primeiroDigito, segundoDigito;

                for (int i = 0; i < Cpf.Length && numerosSomados < 9; i++)
                {

                    if (char.IsDigit(Cpf[i]))
                    {
                        soma += Convert.ToInt32(Convert.ToString(Cpf[i])) * peso--;
                        numerosSomados++;
                    }

                }

                primeiroDigito = 11 - (soma % 11);

                if (primeiroDigito > 10)
                {
                    primeiroDigito = 0;
                }

                if (primeiroDigitoVerificador != primeiroDigito)
                {
                    return false;
                }

                numerosSomados = 0;
                peso = 11;
                soma = 0;
                for (int i = 0; i < Cpf.Length && numerosSomados < 10; i++)
                {

                    if (char.IsDigit(Cpf[i]))
                    {
                        soma += Convert.ToInt32(Convert.ToString(Cpf[i])) * peso--;
                        numerosSomados++;
                    }

                }

                segundoDigito = 11 - (soma % 11);

                if (segundoDigito > 10)
                {
                    segundoDigito = 0;
                }

                if (segundoDigitoVerificador != segundoDigito)
                {
                    return false;
                }

                return true;
            }
            

        }

        return false;

    }

}
