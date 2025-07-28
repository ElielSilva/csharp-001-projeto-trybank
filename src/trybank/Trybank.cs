namespace Trybank.Lib;

public class TrybankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;

    public TrybankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    public void RegisterAccount(int number, int agency, int pass)
    {
        int lines = Bank.GetLength(0);

        for (int i = lines - 1; i >= 0; i--)
        {
            if (Bank[i, 0] == number)
            {
                throw new ArgumentException("A conta já está sendo usada!");
            }
        }

        Bank[registeredAccounts,0] = number;
        Bank[registeredAccounts,1] = agency;
        Bank[registeredAccounts,2] = pass;
        Bank[registeredAccounts,3] = 0;
        //Console.WriteLine("aqui "+ Bank[0,0]);
        registeredAccounts =+ 1;
    }

    public void Login(int number, int agency, int pass)
    {
        int lines = Bank.GetLength(0);
        int acount = -99;
        
        for (int i = 0; i < lines; i++)
        {
            if (Bank[i, 0] == number && Bank[i,1] == agency)
            {
                acount = i;
            }
        }
        
        if(Logged)
            throw new AccessViolationException("Usuário já está logado");
        
        if(acount != -99)
        {
            if (Bank[acount,2] == pass)
            {
                loggedUser = acount;
                Logged = true;
                return;
            }
            else
            {
                throw new ArgumentException("Senha incorreta");
            }
        }
        throw new ArgumentException("Agência + Conta não encontrada");
    }

    public void Logout()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        Logged = false;
        loggedUser = -99;
    }

    public int CheckBalance()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        return Bank[loggedUser,3]; 
    }

    public void Deposit(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        Bank[loggedUser,3] = Bank[loggedUser,3] + value; 
    }

    public void Withdraw(int value)
    {
        if (!Logged)
            throw new AccessViolationException("Usuário não está logado");
        
        if((Bank[loggedUser,3] - value) < 0)
            throw new InvalidOperationException("Saldo insuficiente");
        Bank[loggedUser,3] = Bank[loggedUser,3] - value;
    }

    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        if (!Logged)
            throw new AccessViolationException("Usuário não está logado");
        if((Bank[loggedUser,3] - value) < 0)
            throw new InvalidOperationException("Saldo insuficiente");
        
        int lines = Bank.GetLength(0);
        int acountDestiny = -1;

        for (int i = lines - 1; i >= 0; i--)
        {
            if (Bank[i, 0] == destinationNumber && Bank[i, 1] == destinationAgency)
            {
                acountDestiny = i;
            }
        }
        if(acountDestiny == -1)
            throw new ArgumentException("Agência + Conta não encontrada");

        Bank[loggedUser,3] = Bank[loggedUser,3] - value;
        Bank[acountDestiny,3] = Bank[acountDestiny,3] + value;
        Console.WriteLine(Bank[destinationNumber,1]);
    }

   
}
