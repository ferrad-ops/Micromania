namespace Micromania.Console
{
    public class ClientDto
    {        
        public long Id { get; private set; }
        public decimal MoneyInWallet { get; private set; }

        public ClientDto(long id, decimal moneyInside)
        {
            Id = id;
            MoneyInWallet = moneyInside;
        }        
    }
}